using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Social;

namespace RaysHotDogs
{
	partial class TweetViewController : UIViewController
	{
		private SLComposeViewController slComposerViewController;

		public TweetViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SendTweetButton.TouchUpInside += (object sender, EventArgs e) => {
				if (SLComposeViewController.IsAvailable(SLServiceKind.Twitter)) 
				{
					slComposerViewController = SLComposeViewController.FromService(SLServiceKind.Twitter);

					slComposerViewController.SetInitialText(TweetTextView.Text);

					slComposerViewController.CompletionHandler += (result) => {
						InvokeOnMainThread(() => {
							DismissViewController(true, null);

							UIAlertView messageBox = new UIAlertView("Ray's Hot Dogs", "Tweet sent successfully", null, "OK", null);

							messageBox.Show();
						});
					};

					PresentViewController(slComposerViewController, true, null);
				}
				else 
				{
					UIAlertView messageBox = new UIAlertView ("Ray's Hot Dogs", "Twitter not configured on your device", null, "OK", null);
					messageBox.Show();
				}
			};
		}
	}
}
