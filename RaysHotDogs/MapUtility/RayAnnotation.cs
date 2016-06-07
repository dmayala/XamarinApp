using System;
using MapKit;
using CoreLocation;

namespace RaysHotDogs
{
	public class RayAnnotation: MKAnnotation
	{
		public RayAnnotation ()
		{
		}

		private string title;
		CLLocationCoordinate2D coordinate;

		public RayAnnotation (string title, CLLocationCoordinate2D coordinate)
		{
			this.title = title;
			this.coordinate = coordinate;
		}

		public override string Title 
		{
			get 
			{
				return title;
			}
		}

		public override CLLocationCoordinate2D Coordinate 
		{
			get 
			{
				return coordinate;
			}
		}
	}
}

