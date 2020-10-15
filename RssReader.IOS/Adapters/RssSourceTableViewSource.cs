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
        private readonly UIViewController context;

        public RssSourceTableViewSource(UIViewController context, List<RssSource> data)
        {
            this.context = context;
            this.data = data;
        }

        public RssSource this[int position] => data[position];

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("rsssourcecell");

            cell.TextLabel.Text = data[indexPath.Row].Title;
            cell.DetailTextLabel.Text = $"Created at {data[indexPath.Row].CreatedAt:dd/MM/yyyy}";

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

        //public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        //{
        //    var item = data[indexPath.Row];

        //    var ctrl = context.Storyboard.InstantiateViewController(nameof(RssItemsViewController)) as RssItemsViewController;

        //    ctrl.Id = item.Id;

        //    context.NavigationController.PushViewController(ctrl, true);
        //}
    }
}
