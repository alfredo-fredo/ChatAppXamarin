using System;
using Xamarin.Forms;
namespace XamarinChatApp
{
    public class CustomMessageCell : ViewCell
    {
        //The cell that will be displayed in a list of active chats. Includes image, name, text preview, timestamp.

        Image ProfilePicture;
        String Name;
        String MessageHint;
        String MessageSentTime;

        public CustomMessageCell(Image ProfilePicture, String Name, String MessageHint, String MessageSentTime)
        {
            this.ProfilePicture = ProfilePicture;
            this.Name = Name;
            this.MessageHint = MessageHint;
            this.MessageSentTime = MessageSentTime;

            //instantiate each of our views
            Image image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label nameLabel = new Label();
            Label messageHintLabel = new Label();
            Label messageSentTimeLabel = new Label();

            //set bindings
            image.SetBinding(Image.SourceProperty, "ProfilePicture");
            nameLabel.SetBinding(Label.ScaleProperty, "Name");
            messageHintLabel.SetBinding(Label.ScaleProperty, "MessageHint");
            messageSentTimeLabel.SetBinding(Label.ScaleProperty, "MessageTime");

            //Set properties for desired design
            //image
            //nameLabel.TextType
            //messageHintLabel
            //messageSentTimeLabel

            cellWrapper.BackgroundColor = Color.FromHex("#f4f4f4");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            /*right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");*/

            //add views to the view hierarchy
            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(nameLabel);
            horizontalLayout.Children.Add(messageHintLabel);
            horizontalLayout.Children.Add(messageSentTimeLabel);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}
