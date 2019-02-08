using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Fen_Test.Authorization.Users;
using Fen_Test.MultiTenancy;

namespace Fen_Test.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}