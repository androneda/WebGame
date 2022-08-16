﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebGame.Common
{
    public class AuthOptions
    {
        public string ISSUER { get; set; }
        public string AUDIENCE { get; set; }
        public string KEY { get; set; }
        public int LIFETIME { get; set; }
    }
}
