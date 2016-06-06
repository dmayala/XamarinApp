using System;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	public class BaseUITableViewController: UITableViewController
	{
		public BaseUITableViewController () : base("BaseUITableViewController", null)
		{
		}

		public BaseUITableViewController (IntPtr handle) : base (handle)
		{
		}
			
		public async void HotDogSelected(HotDog selectedHotDog)
		{
			HotDogDetailViewController hotDogDetailViewController = 
				this.Storyboard.InstantiateViewController("HotDogDetailViewController") as HotDogDetailViewController;
			if (hotDogDetailViewController != null)
			{
				hotDogDetailViewController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;
				hotDogDetailViewController.SelectedHotDog = selectedHotDog;

				await PresentViewControllerAsync (hotDogDetailViewController, true);
			}
		}	
	}
}

		