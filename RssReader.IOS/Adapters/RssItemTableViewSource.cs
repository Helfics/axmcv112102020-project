using System;
using System.Collections.Generic;
using FFImageLoading;
using Foundation;
using RssReader.Common.Entities;
using UIKit;

namespace RssReader.IOS.Adapters
{
    public class RssItemTableViewSource : UITableViewSource
    {
        private readonly List<RssItem> data;

        public RssItemTableViewSource(List<RssItem> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("rssitemcell") as RssItemCell;

            cell.Title = data[indexPath.Row].Title;
            cell.Content = data[indexPath.Row].Description;

            ImageService.Instance.LoadUrl(data[indexPath.Row].ImageUrl).Into(cell.Image);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {

            return new UITableViewRowAction[]
            {
                UITableViewRowAction.Create(UITableViewRowActionStyle.Normal, "Open", OpenInBrowser)
            };

        }

        private void OpenInBrowser(UITableViewRowAction action, NSIndexPath indexPath)
        {
            var item = data[indexPath.Row];

            UIApplication.SharedApplication.OpenUrl(new NSUrl(item.Url));
        }
    }
}
