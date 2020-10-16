using Foundation;
using RssReader.Common.Entities;
using RssReader.Common.Services;
using RssReader.IOS.Adapters;
using System;
using System.Threading.Tasks;
using UIKit;

namespace RssReader.IOS
{
    public partial class RssItemsViewController : UIViewController
    {
        private readonly RssReaderService rssReaderService;
        private RssSource item;
        private UIRefreshControl refreshControl;

        public int Id { get; set; }

        public RssItemsViewController (IntPtr handle) : base (handle)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            item = rssReaderService.GetRssSourceById(Id);

            Title = item.Title;

            refreshControl = new UIRefreshControl();

            refreshControl.ValueChanged += RefreshControl_ValueChanged;

            rssitemslistview.Add(refreshControl);

            var _ = Load();
        }

        private void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            Load();
        }

        private async Task Load()
        {
            refreshControl.BeginRefreshing();

            var items = await rssReaderService.GetAllRssItems(item.Url);

            rssitemslistview.Source = new RssItemTableViewSource(items);

            refreshControl.EndRefreshing();
        }
    }
}