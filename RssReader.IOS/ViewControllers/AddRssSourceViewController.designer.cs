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

namespace RssReader.IOS.ViewControllers
{
    [Register ("AddRssSourceViewController")]
    partial class AddRssSourceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField titletextfield { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField urltextfield { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (titletextfield != null) {
                titletextfield.Dispose ();
                titletextfield = null;
            }

            if (urltextfield != null) {
                urltextfield.Dispose ();
                urltextfield = null;
            }
        }
    }
}