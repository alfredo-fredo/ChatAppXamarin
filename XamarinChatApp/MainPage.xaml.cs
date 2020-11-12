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

        FirebaseHelper firebaseHelper;

        public MainPage()
        {
            InitializeComponent();

            firebaseHelper = new FirebaseHelper();

            firebaseHelper.DbChangeListener(MainListView);


            DisplayMessages();
        }

        async void Send_Clicked(System.Object sender, System.EventArgs e)
        {
            if(SendChatRoomText.Text.Length > 0)
            {
                firebaseHelper = new FirebaseHelper();

                await firebaseHelper.SendMessage("Alfred", SendChatRoomText.Text);

                SendChatRoomText.Text = "";
            }
        }

        public async void DisplayMessages()
        {
            firebaseHelper = new FirebaseHelper();
            List<MessageData> messageDatas = await firebaseHelper.GetMessages();

            List<MyViewCell> myViewCells = new List<MyViewCell>();

            foreach(MessageData m in messageDatas)
            {
                myViewCells.Add(new MyViewCell(m.SenderID, m.Message, m.TimeStamp));
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

            
        }

    }
}
