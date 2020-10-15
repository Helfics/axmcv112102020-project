using System;
using System.Collections.Generic;
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
            var cell = tableView.DequeueReusableCell("rssitemcell");

            cell.TextLabel.Text = data[indexPath.Row].Title;
            cell.DetailTextLabel.Text = data[indexPath.Row].Title;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}
