using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	public partial class HotDogTableViewController : UITableViewController
	{
		HotDogDataService dataService = new HotDogDataService();

		public HotDogTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var hotDogs = dataService.GetAllHotDogs();
			var datasource = new HotDogDataSource(hotDogs, this);

			TableView.Source = datasource;

			this.NavigationItem.Title = "Ray's Hot Dog Menu";
		}

		public async void HotDogSelected(HotDog selectedHotDog)
		{
			HotDogDetailViewController hotDogDetailViewController = 
				this.Storyboard.InstantiateViewController("HotDogDetailViewController") as HotDogDetailViewController;
			if (hotDogDetailViewController != null) 
			{
				hotDogDetailViewController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;
				hotDogDetailViewController.SelectedHotDog = selectedHotDog;

				await PresentViewControllerAsync(hotDogDetailViewController, true);
			}
		}
			
	}
}
