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
    [Register ("AnalyzeViewController")]
    partial class AnalyzeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView indicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel progressText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (indicatorView != null) {
                indicatorView.Dispose ();
                indicatorView = null;
            }

            if (progressText != null) {
                progressText.Dispose ();
                progressText = null;
            }
        }
    }
}