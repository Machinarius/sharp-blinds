using System;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace BlindsPort {
	/// <summary>
	/// This is a port of the BlindsView class built by Sony and explained at 
	/// http://developer.sonymobile.com/knowledge-base/tutorials/ui-graphics/use-the-blindsview-effect-from-the-xperia-lockscreen/
	/// 
	/// All credits go to them for the ideas and Machinarius for the port.
	/// </summary>
	public class BlindsContainer : ViewGroup {

		private static Color BackgroundColor {
			get { return Color.Rgb (250, 50, 50); }
		}

		private Color ForegroundColor { 
			get { return Color.Rgb (50, 75, 75); }
		}

		private Paint ForegroundPaint;
		private Bitmap OriginalBitmap;
		private Canvas OriginalCanvas;
		private BitmapDrawable BackgroundDrawable;

		public BlindsContainer (Context context, IAttributeSet attrs,
		                       int defStyle) : base(context, attrs, defStyle) {
			init ();
		}

		public BlindsContainer (Context context, IAttributeSet attrs) : base(context, attrs) {
			init ();
		}

		public BlindsContainer (Context context) : base(context) {
			init ();
		}

		private void init () {
			ForegroundPaint = new Paint () {
				Color = ForegroundColor
			};
		}

		protected override void OnLayout (bool changed, int left, int top, int right, int bottom) {

		}

		protected override void DispatchDraw (Canvas canvas) {
			base.DispatchDraw (canvas);

			OriginalBitmap = Bitmap.CreateBitmap (Width, Height, Bitmap.Config.Argb8888);
			OriginalCanvas = new Canvas (OriginalBitmap);
			if (BackgroundDrawable != null) {
				BackgroundDrawable.Draw (canvas);
			}
		}

		public override void SetBackgroundDrawable (Drawable drawable) {
			base.SetBackgroundDrawable (drawable);
			BackgroundDrawable = (BitmapDrawable) drawable;
			CenterBackground ();
		}

		public override void SetBackgroundResource (int resID) {
			base.SetBackgroundResource (resID);
			BackgroundDrawable = (BitmapDrawable) Resources.GetDrawable (resID);
			CenterBackground ();
		}

		private void CenterBackground() {
			if (BackgroundDrawable != null) {
				DisplayMetrics Metrics = Resources.DisplayMetrics;
				BackgroundDrawable.SetTargetDensity (Metrics);
				BackgroundDrawable.Gravity = GravityFlags.Center;
				BackgroundDrawable.SetBounds (0, 0, Metrics.WidthPixels, Metrics.HeightPixels);
			}

			Invalidate ();
		}
	}
}