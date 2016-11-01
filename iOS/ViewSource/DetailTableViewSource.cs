using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace Analyzer.iOS
{
	public class DetailTableViewSource : UITableViewSource
	{
		readonly List<ClientItemModel> sourceList;
		string CellIdentifier = "TableCell";
		string CellColorIdentifier = "TableColorCell";
		public DetailTableViewSource(List<ClientItemModel> sourceList)
		{
			this.sourceList = sourceList;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (DetailTableViewCell)tableView.DequeueReusableCell(CellIdentifier);
			var cellColor = (TableViewColorCell)tableView.DequeueReusableCell(CellColorIdentifier);

			var item = sourceList[indexPath.Row];

			if (item.itemDesc.Contains("#") && item.itemDesc.Length == 7)
			{
				if (cellColor == null)
				{
					cellColor = new TableViewColorCell(new NSString(CellColorIdentifier), item.itemDesc, item.itemName + " : ");
				}
				cellColor.updateCellData(item.itemDesc, item.itemName);
				return cellColor;
			}

			if (cell == null)
			{
				cell = new DetailTableViewCell(new NSString(CellIdentifier), item.itemDesc, item.itemName + " : ");
				//return cell;
			}
			cell.updateCellData(item.itemDesc, item.itemName + " : ");
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return sourceList.Count;
		}


	}
}
