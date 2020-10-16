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
    [Register ("RssItemCell")]
    partial class RssItemCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel content { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel title { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (content != null) {
                content.Dispose ();
                content = null;
            }

            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (title != null) {
                title.Dispose ();
                title = null;
            }
        }
    }
}