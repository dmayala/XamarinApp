using System;
using UIKit;
using System.Collections.Generic;
using RaysHotDogs.Core;
using Foundation;

namespace RaysHotDogs
{
	public class HotDogDataSoruce : UITableViewSource
	{
		private List<HotDog> hotDogs;
		NSString cellIdentifier = new NSString("HotDogCell");

		public HotDogDataSoruce(List<HotDog> hotDogs, UITableViewController callingController)
		{
			this.hotDogs = hotDogs;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return hotDogs.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(cellIdentifier) as HotDogListCell;

			if (cell == null)
			{
				cell = new HotDogListCell(cellIdentifier);
			}

			cell.UpdateCell(hotDogs[indexPath.Row].Name,
				hotDogs[indexPath.Row].Price.ToString(),
				UIImage.FromFile($"Images/hotdog{hotDogs[indexPath.Row].HotDogId}.jpg")
			);

			return cell;∂
		}
	}
}

