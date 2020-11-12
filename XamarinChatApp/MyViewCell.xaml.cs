using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyViewCell : ViewCell
    {
        public String Name { get; set; }
        public String Message { get; set; }
        public String TimeStamp { get; set; }


        public MyViewCell(String Name, String Message, String TimeStamp, bool isMyMessage)
        {
            InitializeComponent();
            this.Name = Name;
            this.Message = Message;
            this.TimeStamp = TimeStamp;

            if (isMyMessage)
            {
                MyLayout.BackgroundColor = Color.FromHex("#034078");  
            }
            else
            {
                MyLayout.BackgroundColor = Color.FromHex("#1282A2");
            }
        }

        public MyViewCell()
        {
            InitializeComponent();
        }
    }
}
