namespace WebGame.Core.Services.Interfaces
{
    public interface IPasswordService
    {
        string GenerateSaltedHash(string password);
    }
}
