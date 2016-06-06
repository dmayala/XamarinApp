using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class MeatLoversTableViewController : BaseUITableViewController
	{
		private HotDogDataService dataService = new HotDogDataService();

		public MeatLoversTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var meatLovers = dataService.GetHotDogsForGroup((int)HotDogGroupOptions.MeatLovers);
			TableView.Source = new HotDogDataSource(meatLovers, this);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.ParentViewController.Title = "Meat Lovers";
		}
	}
}
