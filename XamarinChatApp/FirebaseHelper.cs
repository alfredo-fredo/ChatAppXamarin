using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;

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

        public async void Listener()
        {
            var childQ = firebaseClient.Child(DBRef);
            childQ.AsObservable<MessageData>().Subscribe(job =>
            {

            });
        }
    }
}
