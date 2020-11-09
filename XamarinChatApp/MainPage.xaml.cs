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

            MainListView.ItemsSource = new List<ListViewTemplate>
            {
            new ListViewTemplate
                {
                ProfilePicture = null,
                Name = "Farah",
                    MessageHint = "I'm doing well! How about you?",
                    MessageTime = "8:28 pm"               
               },
               new ListViewTemplate
                {
                ProfilePicture = null,
                Name = "William",
                    MessageHint = "I'm doing well! How about you?",
                    MessageTime = "9:32 am"
               },
               new ListViewTemplate
                {
                ProfilePicture = null,
                Name = "Alfred",
                    MessageHint = "I'm doing well! How about you?",
                    MessageTime = "1:02 am"
               },
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
