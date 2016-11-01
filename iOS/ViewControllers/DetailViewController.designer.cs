// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Analyzer.iOS
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView detailTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView strecthImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detailTableView != null) {
                detailTableView.Dispose ();
                detailTableView = null;
            }

            if (strecthImageView != null) {
                strecthImageView.Dispose ();
                strecthImageView = null;
            }
        }
    }
}