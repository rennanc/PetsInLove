using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PetsInLove.Service;
using PetsInLove.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace PetsInLove.Droid
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}