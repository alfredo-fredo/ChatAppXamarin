using System;
using Xamarin.Forms;
namespace XamarinChatApp
{
    public class ListViewTemplate
    {
        public Image ProfilePicture { get; set; }
        public String Name { get; set; }
        public String MessageHint { get; set; }
        public String MessageTime { get; set; }

        public ListViewTemplate()
        {
        }
    }
}
