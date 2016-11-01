using System;

using UIKit;
using CoreGraphics;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using System.Threading;

namespace Analyzer.iOS
{
	public partial class AnalyzeViewController : UIViewController
	{
		ClientHelper clientHelper = new ClientHelper();
		UIImagePickerController pickerController;
		List<ClientModel> clientModelList = new List<ClientModel>();

		public UIStackView stackView;
		public UIButton cameraButton;
		public UIButton imageButton;


		public AnalyzeViewController(IntPtr handle) : base (handle)
        {
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			NavigationItem.Title = "Analyzer";

			createButtons();

			setupProgress(false);


			pickerController = new UIImagePickerController();


			pickerController.FinishedPickingMedia += async (object s, UIImagePickerMediaPickedEventArgs e) =>
			{
				setupProgress(true);
				await pickerController.DismissViewControllerAsync(true);
				new Thread(() => InvokeOnMainThread(() => showProgress())).Start();
				var result = ScaledImage(e.OriginalImage,500,500);
				var imageStream = result.AsPNG().AsStream();
				await analyseImage(imageStream).ContinueWith((arg) =>
				{
					InvokeOnMainThread(() =>
					{
						setupProgress(false);
						var controller = this.Storyboard.InstantiateViewController("DetailViewController") as DetailViewController;
						controller.clientModelList = clientModelList;
						controller.uiImage = result;
						NavigationController.PushViewController(controller, true);

					});
				});


			};

			pickerController.Canceled += async delegate
			{
				await pickerController.DismissViewControllerAsync(true);
			};


		}

		public async Task analyseImage(Stream stream)
		{
			clientModelList = await clientHelper.GetImageDescription(stream,clientModelList).ConfigureAwait(false);
		}

		public void showProgress()
		{
			progressText.Hidden = false;
			indicatorView.Hidden = false;
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		UIImage ScaledImage(UIImage image, nfloat maxWidth, nfloat maxHeight)
		{
			var maxResizeFactor = Math.Min(maxWidth / image.Size.Width, maxHeight / image.Size.Height);
			var width = maxResizeFactor * image.Size.Width;
			var height = maxResizeFactor * image.Size.Height;
			return image.Scale(new CGSize(width, height));
		}

		public void createButtons()
		{ 
			stackView = new UIStackView(new CGRect(0, 0, View.Bounds.Width - 40, View.Bounds.Width / 4));
			stackView.Axis = UILayoutConstraintAxis.Vertical;
			stackView.Spacing = 10;
			stackView.Distribution = UIStackViewDistribution.FillProportionally;


			cameraButton = new UIButton(new CGRect(0, 0, View.Bounds.Width / 2, View.Bounds.Width / 2));
			cameraButton.SetTitle("Capture a new photo", UIControlState.Normal);
			cameraButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			cameraButton.Layer.BorderWidth = 1;
			cameraButton.Layer.CornerRadius = 3;
			cameraButton.Layer.BorderColor = UIColor.Black.CGColor;
			cameraButton.BackgroundColor = UIColor.White;

			cameraButton.TouchUpInside += (sender, e) =>
			{ 
				pickerController.SourceType = UIImagePickerControllerSourceType.Camera;
				pickerController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
				PresentViewController(pickerController, true, null);
			};


			imageButton = new UIButton(new CGRect(0, 0, View.Bounds.Width / 2, View.Bounds.Width / 2));
			imageButton.SetTitle("Choose from gallery", UIControlState.Normal);
			imageButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			imageButton.Layer.BorderWidth = 1;
			imageButton.Layer.CornerRadius = 3;
			imageButton.Layer.BorderColor = UIColor.Black.CGColor;
			imageButton.BackgroundColor = UIColor.White;

			imageButton.TouchUpInside += (sender, e) =>
			{ 
				pickerController.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
				pickerController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
				PresentViewController(pickerController, true, null);
			};

			stackView.Center = View.Center;

			stackView.AddArrangedSubview(cameraButton);
			stackView.AddArrangedSubview(imageButton);

			View.Add(stackView);

		}


		public void setupProgress(bool isprogress)
		{
			if (isprogress)
			{
				progressText.Hidden = false;
				indicatorView.Hidden = false;
				imageButton.Hidden = true;
				cameraButton.Hidden = true;
			}
			else
			{ 
				progressText.Hidden = true;
				indicatorView.Hidden = true;
				imageButton.Hidden = false;
				cameraButton.Hidden = false;
			}
		}



	}
}

