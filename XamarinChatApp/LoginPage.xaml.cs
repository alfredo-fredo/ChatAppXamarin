using System;
using System.Collections.Generic;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XamarinChatApp
{
    public partial class LoginPage : ContentPage
    {
        readonly String apiKey = "AIzaSyB19roUyLOHHuASYMMlIFdIiwydYwyzulE";

        public LoginPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(System.Object sender, System.EventArgs e)
        {
            //firebase auth login

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailText.Text, PasswordText.Text);
                var user = auth.User.Email.Split('@');
                Preferences.Set("user", user[0]);
                Console.WriteLine(user[0]);
                //var content = await auth.GetFreshAuthAsync();
                //var serializedContent = JsonConvert.SerializeObject(content);

                try
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());             
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error alert", ex.Message, "OK");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Failed to login.", "OK");
            }
        }

        async void New_Clicked(System.Object sender, System.EventArgs e)
        {
            //create new account

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailText.Text, PasswordText.Text);
                string getToken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", "Account successfully created.", "Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Provide a valid email.", "OK");
            }
        }
    }
}
