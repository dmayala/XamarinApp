// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RaysHotDogs
{
	[Register ("TweetViewController")]
	partial class TweetViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SendTweetButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TweetTextView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SendTweetButton != null) {
				SendTweetButton.Dispose ();
				SendTweetButton = null;
			}
			if (TweetTextView != null) {
				TweetTextView.Dispose ();
				TweetTextView = null;
			}
		}
	}
}
