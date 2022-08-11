using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using WebGame.Core.Model.Account;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;


namespace WebGame.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ISet<User> _users = new HashSet<User>();
        private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();
        private readonly IJwtTokenHelper _jwtHelper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(IJwtTokenHelper jwtHelper, 
            IPasswordHasher<User> passwordHasher)
        {
            _jwtHelper = jwtHelper;
            _passwordHasher = passwordHasher;
        }

        public void SignUp(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception($"Username can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception($"Password can not be empty.");
            }
            if (GetUser(username) != null)
            {
                throw new Exception($"Username '{username}' is already in use.");
            }
            _users.Add(new User { Username = username, Password = password } );
        }

        public JsonWebToken SignIn(string username, string password)
        {
            var user = GetUser(username);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            var jwt = _jwtHelper.Create(user.Username);
            var refreshToken = _passwordHasher.HashPassword(user, Guid.NewGuid().ToString())
                .Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);
            jwt.RefreshToken = refreshToken;
            _refreshTokens.Add(new RefreshToken { Username = username, Token = refreshToken });

            return jwt;
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            var refreshToken = GetRefreshToken(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh token was revoked");
            }
            var jwt = _jwtHelper.Create(refreshToken.Username);;
            jwt.RefreshToken = refreshToken.Token;

            return jwt;
        }

        public void RevokeRefreshToken(string token)
        {
            var refreshToken = GetRefreshToken(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh token was already revoked.");
            }
            refreshToken.Revoked = true;
        }

        private User GetUser(string username)
            => _users.SingleOrDefault(x => string.Equals(x.Username, username, StringComparison.InvariantCultureIgnoreCase));

        private RefreshToken GetRefreshToken(string token)
            => _refreshTokens.SingleOrDefault(x => x.Token == token);
    }
}