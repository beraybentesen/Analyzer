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
    [Register ("TableViewColorCell")]
    partial class TableViewColorCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton colorButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel colorDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel colorName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (colorButton != null) {
                colorButton.Dispose ();
                colorButton = null;
            }

            if (colorDesc != null) {
                colorDesc.Dispose ();
                colorDesc = null;
            }

            if (colorName != null) {
                colorName.Dispose ();
                colorName = null;
            }
        }
    }
}