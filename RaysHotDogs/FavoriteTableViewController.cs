using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class FavoriteTableViewController : BaseUITableViewController
	{
		private HotDogDataService dataService = new HotDogDataService();

		public FavoriteTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var favorites = dataService.GetFavoriteHotDogs();
			TableView.Source = new HotDogDataSource(favorites, this);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.ParentViewController.NavigationItem.Title = "Ray's Favorites";
		}
	}
}
