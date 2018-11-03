

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using UskudarDenetim.UI.Identity;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(UskudarDenetim.UI.App_Start.Startup))]

namespace UskudarDenetim.UI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new IdentityContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<RoleManager<IDRole>>((options, context) =>
                new RoleManager<IDRole>(
                    new RoleStore<IDRole>(context.Get<IdentityContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });

        }
    }
}
