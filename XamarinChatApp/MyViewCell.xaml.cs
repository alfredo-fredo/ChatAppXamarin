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

        public MyViewCell(String Name, String Message, String TimeStamp)
        {
            InitializeComponent();
            this.Name = Name;
            this.Message = Message;
            this.TimeStamp = TimeStamp;

        }

        public MyViewCell()
        {
            InitializeComponent();
        }
    }
}
