using Foundation;
using System;
using UIKit;

namespace Analyzer.iOS
{
    public partial class TableViewColorCell : UITableViewCell
    {
        public TableViewColorCell (IntPtr handle) : base (handle)
        {
        }

		public TableViewColorCell(NSString cellId, string desc, string name) : base (UITableViewCellStyle.Default, cellId)

		 {
			colorDesc.LineBreakMode = UILineBreakMode.WordWrap;
			colorName.Text = name;
			colorDesc.Text = desc;
		 }

		public void updateCellData(string desc, string name)
		{
			colorName.Text = name;
			colorDesc.Text = desc;
			colorButton.Layer.BackgroundColor = getColor(desc).CGColor;
		}

		public UIColor getColor(string hex)
		{
			string colour = hex;
			UIColor uiColor;
			try
			{
				colour = colour.Replace("#", "");
				float R = Convert.ToInt32(colour.Substring(0, 2), 16) / 255f;
				float G = Convert.ToInt32(colour.Substring(2, 2), 16) / 255f;
				float B = Convert.ToInt32(colour.Substring(4, 2), 16) / 255f;
				nfloat r = R;
				nfloat g = G;
				nfloat b = B;
				uiColor = UIColor.FromRGB(r, g, b);
			}
			catch
			{
				return UIColor.White;
			}
			return uiColor;
		}

   }
}