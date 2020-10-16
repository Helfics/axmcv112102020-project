using Foundation;
using System;
using UIKit;

namespace RssReader.IOS
{
    public partial class RssItemCell : UITableViewCell
    {
        public RssItemCell (IntPtr handle) : base (handle)
        {
        }

        public string Title
        {
            set { title.Text = value; }
        }

        public string Content
        {
            set { content.Text = value; }
        }

        public UIImageView Image
        {
            get => image;
        }
    }
}