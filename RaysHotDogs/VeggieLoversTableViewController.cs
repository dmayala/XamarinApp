using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class VeggieLoversTableViewController : BaseUITableViewController
	{
		private HotDogDataService dataService = new HotDogDataService();

		public VeggieLoversTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var veggieLovers = dataService.GetHotDogsForGroup((int)HotDogGroupOptions.VeggieLovers);
			TableView.Source = new HotDogDataSource(veggieLovers, this);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.ParentViewController.Title = "Veggie Lovers";
		}
	}
}
