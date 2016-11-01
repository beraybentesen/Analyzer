using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using System.Threading.Tasks;
using System.Drawing;

namespace Analyzer.iOS
{
    public partial class DetailViewController : UIViewController
    {
		public List<ClientModel> clientModelList = new List<ClientModel>();
		List<UITableViewCell> cells = new List<UITableViewCell>();
		ClientHelper clientHelper = new ClientHelper();
		public UIImage uiImage;
		public nfloat headerViewHeight = 275;
		public UIView headerView;
		public List<ClientItemModel> clientModelItemList = new List<ClientItemModel>();

		public DetailViewController (IntPtr handle) : base (handle)
        {

        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			setupTableView();
			Title = "Analyze Result";
		}

		public void setupTableView()
		{
			clientModelItemList = clientHelper.GetResultList(clientModelList, clientModelItemList);

			var tableViewSource = new DetailTableViewSource(clientModelItemList);

			detailTableView.EstimatedRowHeight = 54f;
			detailTableView.RowHeight = UITableView.AutomaticDimension;

			detailTableView.SetNeedsLayout();
			detailTableView.LayoutIfNeeded();


			uiImage.Draw(new CGRect(
				0,0, detailTableView.Frame.Width, headerViewHeight));

			headerView = detailTableView.TableHeaderView;
			detailTableView.TableHeaderView = null;
			detailTableView.AddSubview(headerView);
			detailTableView.ContentInset = new UIEdgeInsets(headerViewHeight, 0, 0, 0);
			detailTableView.BackgroundColor = UIColor.Clear;

			strecthImageView.ContentMode = UIViewContentMode.ScaleToFill;
			strecthImageView.Image = uiImage;
			detailTableView.Source = tableViewSource;

			var deleg = new DescriptionDelegate(ref cells);
			deleg.DidScroll += UpdateHeaderView;
			detailTableView.Delegate = deleg;

		}

		void UpdateHeaderView()
		{
			var headerRect = new CGRect(0, -headerViewHeight, detailTableView.Frame.Width, headerViewHeight);
			if (detailTableView.ContentOffset.Y < -headerViewHeight)
			{
				headerRect.Location = new CGPoint(headerRect.Location.X, detailTableView.ContentOffset.Y);
				headerRect.Size = new CGSize(headerRect.Size.Width, -detailTableView.ContentOffset.Y);
			}
			headerView.Frame = headerRect;
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
    }

	class DescriptionDelegate : UITableViewDelegate
	{
		public List<UITableViewCell> cells = new List<UITableViewCell>();

		public DescriptionDelegate(ref List<UITableViewCell> cells)
		{
			this.cells = cells;
		}

		public override void Scrolled(UIScrollView scrollView)
		{
			DidScroll();
		}

		public delegate void DidScrollEventHandler();
		public event DidScrollEventHandler DidScroll;
	}


}