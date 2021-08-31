namespace CyaraCodingTest.Core.Token
{
    public interface IAccessTokenProvider
    {
        string GenerateToken(string userName);
    }
}
