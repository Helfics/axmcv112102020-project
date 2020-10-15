using Foundation;
using RssReader.Common.Services;
using System;
using UIKit;

namespace RssReader.IOS.ViewControllers
{
    public partial class AddRssSourceViewController : UIViewController, IUITextFieldDelegate
    {
        private readonly RssReaderService rssReaderService;

        public Action<int> OnSuccess { get; set; }

        public AddRssSourceViewController (IntPtr handle) : base (handle)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            titletextfield.Delegate = this;
            urltextfield.Delegate = this;

            savebtn.TouchUpInside += Savebtn_TouchUpInside;
        }

        [Export("textFieldShouldReturn:")]
        public bool ShouldReturn(UITextField uITextField)
        {
            uITextField.EndEditing(true);

            return true;
        }

        private void Savebtn_TouchUpInside(object sender, EventArgs e)
        {
            var id = rssReaderService.AddRssSource(titletextfield.Text, urltextfield.Text);

            NavigationController.PopViewController(true);

            OnSuccess?.Invoke(id);
        }
    }
}