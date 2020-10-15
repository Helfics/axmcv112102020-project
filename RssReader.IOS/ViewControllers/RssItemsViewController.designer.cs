// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RssReader.IOS
{
    [Register ("RssItemsViewController")]
    partial class RssItemsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView rssitemslistview { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (rssitemslistview != null) {
                rssitemslistview.Dispose ();
                rssitemslistview = null;
            }
        }
    }
}