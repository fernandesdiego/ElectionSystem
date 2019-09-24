using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace PainelCipa
{
    internal class ConfigureCookie : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        public ConfigureCookie()
        {
        }
        public void Configure(string name, CookieAuthenticationOptions options)
        {
            //configure schemes
        }

        public void Configure(CookieAuthenticationOptions options) => Configure(Options.DefaultName, options);        

    }
}
