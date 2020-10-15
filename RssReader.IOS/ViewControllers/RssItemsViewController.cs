using Foundation;
using RssReader.Common.Services;
using RssReader.IOS.Adapters;
using System;
using UIKit;

namespace RssReader.IOS
{
    public partial class RssItemsViewController : UIViewController
    {
        private readonly RssReaderService rssReaderService;

        public int Id { get; set; }

        public RssItemsViewController (IntPtr handle) : base (handle)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var item = rssReaderService.GetRssSourceById(Id);

            Title = item.Title;

            var items = await rssReaderService.GetAllRssItems(item.Url);

            rssitemslistview.Source = new RssItemTableViewSource(items);
        }
    }
}