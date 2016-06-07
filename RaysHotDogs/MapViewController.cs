using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MapKit;
using CoreLocation;

namespace RaysHotDogs
{
	partial class MapViewController : UIViewController
	{
		private MKMapView mapView;
		private CLLocationManager locationManager = new CLLocationManager();

		public MapViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			mapView = new MKMapView(View.Bounds);	
			mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			mapView.MapType = MKMapType.Standard;
			View.AddSubview(mapView);

			double latitude = 50.846732;
			double longitude = 4.352413;

			var raysPlace = new CLLocationCoordinate2D(latitude, longitude);

			var zoomRegion = MKCoordinateRegion.FromDistance(raysPlace, 2000, 2000);

			mapView.CenterCoordinate = raysPlace;
			mapView.Region = zoomRegion;

			mapView.Delegate = new RayMapDelegate();

			locationManager.RequestWhenInUseAuthorization();

			mapView.ShowsUserLocation = true;

			mapView.AddAnnotation(new MKPointAnnotation() {
				Title = "Ray's Hot Dogs",
				Coordinate = new CLLocationCoordinate2D(latitude, longitude)
			});

			mapView.AddAnnotation(new RayAnnotation("Ray's Hot Dogs", raysPlace));
		}
	}
}
