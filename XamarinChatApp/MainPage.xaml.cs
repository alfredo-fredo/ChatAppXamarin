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
        Image image = new Image();
        String Name;
        String MessageHint;
        String MessageSentTime;

        public MainPage()
        {
            InitializeComponent();

            MainListView.ItemsSource = new List<CustomMessageCell>
            {
                new CustomMessageCell(image, "Alfred", MessageHint, MessageSentTime),
                new CustomMessageCell(image, "Farah", MessageHint, MessageSentTime),
                new CustomMessageCell(image, "William", MessageHint, MessageSentTime),
           };
        }

        /*async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as ListViewTemplate;

            switch (Selected.OrderNumber)
            {
                case 1:
                    await Navigation.PushAsync(new MyPage());
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

         ((ListView)sender).SelectedItem = null;


        }*/
    }
}
