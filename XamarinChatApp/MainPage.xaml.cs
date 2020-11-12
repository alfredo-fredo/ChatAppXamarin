using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinChatApp
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();

            DisplayMessages();
        }

        async void Send_Clicked(System.Object sender, System.EventArgs e)
        {
            if(SendChatRoomText.Text.Length > 0)
            {
                FirebaseHelper firebaseHelper = new FirebaseHelper();

                await firebaseHelper.SendMessage("Alfred", SendChatRoomText.Text);
            }
        }

        async void DisplayMessages()
        {
            FirebaseHelper firebaseHelper = new FirebaseHelper();
            List<MessageData> messageDatas = await firebaseHelper.GetMessages();

            if (messageDatas.Count > 0)
            {
                MainListView.ItemsSource = new List<MyViewCell>
                {
                new MyViewCell(messageDatas[0].SenderID, messageDatas[0].Message, messageDatas[0].TimeStamp),
                };
            }
            else
            {
                MainListView.ItemsSource = new List<MyViewCell>
                {
                
                new MyViewCell("Wille", "Hahha", "23:09"),
                new MyViewCell("Wille", "Hahha", "23:09"),
                new MyViewCell("Wille", "Hahha", "23:09"),

                };
            }

            
        }

    }
}
