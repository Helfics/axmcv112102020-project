using System;
using System.Collections.Generic;
using Foundation;
using RssReader.Common.Entities;
using UIKit;

namespace RssReader.IOS.Adapters
{
    public class RssSourceTableViewSource : UITableViewSource
    {
        private readonly List<RssSource> data;

        public RssSourceTableViewSource(List<RssSource> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("rsssourcecell");

            cell.TextLabel.Text = data[indexPath.Row].Title;
            cell.DetailTextLabel.Text =  $"Created at {data[indexPath.Row].CreatedAt:dd/MM/yyyy}";

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return data.Count;
        }

        public void Add(RssSource item)
        {
            data.Add(item);
        }
    }
}
