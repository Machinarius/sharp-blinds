using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BlindsPort
{
	[Activity (Label = "BlindsPort", MainLauncher = true)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			BlindsContainer blindsContainer = FindViewById<BlindsContainer> (Resource.Id.blindsContainer);
			blindsContainer.SetBackgroundResource (Resource.Drawable.dandelion);
		}
	}
}


