using FitnessProject.Web.Domain;
using FitnessProject.Web.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Compuskills.Projects.TotalTimesheetPro.Mvc.Identity
{
    public static class IdentityExtensions
    {
        public static AppUserManager CreateUserManager(this IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var userStore = new UserStore<User>(context.Get<FitnessAppContext>());
            var manager = AppUserManager.Create(userStore);

            // Register two factor authentication providers. 
            // The default Microsoft MVC template uses Phone and Emails as a step of receiving a code for verifying the user
            // Disabled in this sample project
            //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<TtpUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<TtpUser>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }
}