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
    [Register ("DetailTableViewCell")]
    partial class DetailTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detailDescLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detailNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detailDescLabel != null) {
                detailDescLabel.Dispose ();
                detailDescLabel = null;
            }

            if (detailNameLabel != null) {
                detailNameLabel.Dispose ();
                detailNameLabel = null;
            }
        }
    }
}