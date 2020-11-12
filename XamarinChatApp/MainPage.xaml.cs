using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XamarinChatApp
{
    public partial class MainPage : ContentPage
    { 

        FirebaseHelper firebaseHelper;

        Location location;

        String userID;

        public MainPage()
        {
            InitializeComponent();

            userID = Preferences.Get("user", "null");

            firebaseHelper = new FirebaseHelper();

            DisplayMessages();

            GetLocation();
        }

        async void Send_Clicked(System.Object sender, System.EventArgs e)
        {
            if(SendChatRoomText.Text.Length > 0)
            {
                firebaseHelper = new FirebaseHelper();

                await firebaseHelper.SendMessage(userID, SendChatRoomText.Text);

                SendChatRoomText.Text = "";
            }
        }

        public async void DisplayMessages()
        {
            Console.WriteLine("DisplayMessages called.");

            Console.WriteLine("UserID is: " + userID);
            firebaseHelper = new FirebaseHelper();
            List<MessageData> messageDatas = await firebaseHelper.GetMessages();

            List<MyViewCell> myViewCells = new List<MyViewCell>();

            foreach(MessageData m in messageDatas)
            {
                int myMsgs = 0;
                if(m.SenderID.ToLower().Equals(userID))
                {
                    myViewCells.Add(new MyViewCell(m.SenderID, m.Message, m.TimeStamp, true));
                    myMsgs++;
                }
                else
                {
                    myViewCells.Add(new MyViewCell(m.SenderID, m.Message, m.TimeStamp, false));
                }
                Console.WriteLine(userID + " contributes to " + myMsgs + " messages in this chat.");
            }

            if (myViewCells.Count > 0)
            {
                MainListView.ItemsSource = myViewCells;

            }
            else
            {
                MainListView.ItemsSource = new List<MyViewCell>
                {

                };
            }

            DisplayMessages();
        }

        public async void GetLocation()
        {
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }

                Console.WriteLine(location);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

    }
}
