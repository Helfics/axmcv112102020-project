using Foundation;
using RssReader.Common.Services;
using RssReader.IOS.Adapters;
using System;
using UIKit;

namespace RssReader.IOS.ViewControllers
{
    public partial class ViewController : UIViewController
    {
        private readonly RssReaderService rssReaderService;

        private RssSourceTableViewSource rsssourceAdapter;

        public ViewController(IntPtr handle) : base(handle)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            rsssourceAdapter = new RssSourceTableViewSource(rssReaderService.GetAllRssSources());

            rsssourcestableview.Source = rsssourceAdapter;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var ctrl = segue.DestinationViewController as AddRssSourceViewController;

            ctrl.OnSuccess = OnRssSourceAdded;

            base.PrepareForSegue(segue, sender);
        }

        private void OnRssSourceAdded(int id)
        {
            var item = rssReaderService.GetRssSourceById(id);


            rsssourceAdapter.Add(item);

            rsssourcestableview.ReloadData();
        }
    }
}