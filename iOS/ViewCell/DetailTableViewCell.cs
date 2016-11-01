using Foundation;
using System;
using UIKit;

namespace Analyzer.iOS
{
    public partial class DetailTableViewCell : UITableViewCell
    {

		public DetailTableViewCell(IntPtr handle) : base (handle)
        {
		}

		public DetailTableViewCell(NSString cellId, string desc, string name) : base (UITableViewCellStyle.Default, cellId)
 	    {
			detailDescLabel.LineBreakMode = UILineBreakMode.WordWrap;
			detailDescLabel.Text = desc;
			detailNameLabel.Text = name;
		}

		 public void updateCellData(string desc, string name)
		{
			detailDescLabel.Text = desc;
			detailNameLabel.Text = name;
		}
    }
}