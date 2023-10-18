using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OnlineStore
{
    public class AuthOptions
    {
        public const string Issuer = "AuthServer";
        public const string Audience = "AuthClient";
        const string Key = "1FDh$3tkd!32hjHjdf";
        public static SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
