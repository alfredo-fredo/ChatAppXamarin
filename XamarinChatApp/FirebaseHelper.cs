using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace XamarinChatApp
{
    public class FirebaseHelper
    {
        FirebaseClient firebaseClient;

        readonly String childRef = "chatroom1";

        readonly String DBRef = "https://chat-app-cbd3c.firebaseio.com/";

        public FirebaseHelper()
        {
            firebaseClient = new FirebaseClient(DBRef);
        }

        public async Task SendMessage(string sender, string message)
        {
            String timeStamp = DateTime.Now.ToString("HH:mm tt");

            await firebaseClient
                .Child(childRef)
                .PostAsync(new MessageData() { SenderID = sender, Message = message, TimeStamp = timeStamp });
        }

        public async Task<List<MessageData>> GetMessages()
        {
            return (await firebaseClient
                .Child(childRef)
                .OnceAsync<MessageData>()).Select(item => new MessageData

                {
                    SenderID = item.Object.SenderID,
                    Message = item.Object.Message,
                    TimeStamp = item.Object.TimeStamp
                }).ToList();
        }

        public void DbChangeListener(ListView mainListView)
        {
            firebaseClient.Child(DBRef).AsObservable<MessageData>().Subscribe(async job =>
            {

                Console.WriteLine("Change in db");
                /*List<MessageData> messageDatas = await GetMessages();

                List<MyViewCell> myViewCells = new List<MyViewCell>();

                foreach (MessageData m in messageDatas)
                {
                    myViewCells.Add(new MyViewCell(m.SenderID, m.Message, m.TimeStamp));
                }

                if (myViewCells.Count > 0)
                {
                    mainListView.ItemsSource = myViewCells;

                }
                else
                {
                    mainListView.ItemsSource = new List<MyViewCell>
                    {

                    };
                }*/
            });
        }
    }
}
