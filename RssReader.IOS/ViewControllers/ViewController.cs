using Foundation;
using RssReader.Common.Entities;
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

            rsssourceAdapter = new RssSourceTableViewSource(this, rssReaderService.GetAllRssSources());

            rsssourcestableview.Source = rsssourceAdapter;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            switch (segue.DestinationViewController)
            {
                case AddRssSourceViewController arsvc:
                    arsvc.OnSuccess = OnRssSourceAdded;
                    break;

                case RssItemsViewController rivc:
                    var item = rsssourceAdapter[rsssourcestableview.IndexPathForSelectedRow.Row];
                    rivc.Id = item.Id;
                    break;
            }

            base.PrepareForSegue(segue, sender);
        }

        private void OnRssSourceAdded(int id)
        {
            var item = rssReaderService.GetRssSourceById(id);


            rsssourceAdapter.Add(item);

            rsssourcestableview.ReloadData();
        }

        public void OnRssSourceDeleted(RssSource item)
        {
            rssReaderService.DeleteRssSource(item.Id);

            rsssourcestableview.ReloadData();
        }
    }
}