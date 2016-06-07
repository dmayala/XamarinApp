using System;
using MapKit;
using UIKit;

namespace RaysHotDogs
{
	public class RayMapDelegate : MKMapViewDelegate
	{
		string pId = "PinAnnotation";
		string mId = "RayAnnotation";

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
		{
			MKAnnotationView annotationView;

			if (annotation is MKUserLocation)
				return null; 

			if (annotation is RayAnnotation) 
			{

				annotationView = mapView.DequeueReusableAnnotation (mId);

				if (annotationView == null)
					annotationView = new MKAnnotationView (annotation, mId);

				annotationView.Image = UIImage.FromFile ("ray.png");
				annotationView.CanShowCallout = true;
				annotationView.Draggable = true;
				annotationView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);

			} 
			else 
			{
				annotationView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);

				if (annotationView == null)
					annotationView = new MKPinAnnotationView (annotation, pId);

				((MKPinAnnotationView)annotationView).PinColor = MKPinAnnotationColor.Red;
				annotationView.CanShowCallout = true;
			}

			return annotationView;
		}
	}
}