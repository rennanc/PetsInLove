﻿using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using PetsInLove.Helpers;
using PetsInLove.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace PetsInLove.Service
{
    public class AzureService
    {
        static readonly string AppUrl = "https://petsinlove.azurewebsites.net";

        private const string uriScheme = "petsinlove://easyauth.callback";

        public MobileServiceClient Client { get; set; }

        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            try
            {
                Client = new MobileServiceClient(AppUrl);
            }catch(Exception e)
            {
                String a = e.Message;
            }

            if(!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync(MobileServiceAuthenticationProvider mobileServiceAuthenticationProvider)
        {
            Initialize();

            var auth = DependencyService.Get<IAuthenticate>();
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add( "uriScheme", uriScheme );
            var user = await auth.LoginAsync(Client, mobileServiceAuthenticationProvider, parameters);

            if(user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
                });
                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}
