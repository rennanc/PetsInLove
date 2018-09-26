﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using PetsInLove.Service;
using Xamarin.Forms;
using PetsInLove.Helpers;
using PetsInLove.Droid.Service;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace PetsInLove.Droid.Service
{
    public class SocialAuthentication : IAuthenticate
    {

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider, "petsinlove");
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}