using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Xamarin.Media;
using System.Threading.Tasks;

namespace RaysHotDogs
{
	partial class TakePictureViewController : UIViewController
	{
		private MediaPicker mediaPicker = new MediaPicker();
		private TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

		private UIAlertView alertView;
		private MediaPickerController mediaPickerController;

		public TakePictureViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TakePictureButton.TouchUpInside += (object sender, EventArgs e) => {
				if (!mediaPicker.IsCameraAvailable) 
				{
					alertView = new UIAlertView ("Ray's Hot Dogs", "Sadly, you can't take pictures with your device :-(", 
						new UIAlertViewDelegate(), "OK");
					alertView.Show();

					return;
				}

				mediaPickerController = mediaPicker.GetTakePhotoUI(new StoreCameraMediaOptions {
					Name = "hotdogselfie.jpg",
					Directory = "RaysHotDogsSelfies"
				});

				PresentViewController(mediaPickerController, true, null);

				mediaPickerController.GetResultAsync().ContinueWith(t => {
					HotDogImage.Image = UIImage.FromFile(t.Result.Path);
					DismissViewController(true, null);
				}, uiScheduler);
			};
		}
	}
}
