using System;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;

namespace BlindsPort {
	/// <summary>
	/// This is a port of the BlindsView class built by Sony and explained at 
	/// http://developer.sonymobile.com/knowledge-base/tutorials/ui-graphics/use-the-blindsview-effect-from-the-xperia-lockscreen/
	/// 
	/// All credits go to them for the ideas and Machinarius for the port.
	/// </summary>
	public class BlindsContainer : ViewGroup {

		private Color BackgroundColor = Color.Rgb (250, 50, 50);
		private Color ForegroundColor = Color.Rgb (50, 75, 75);
		private Paint ForegroundPaint;

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

			canvas.DrawColor (BackgroundColor);
			canvas.DrawCircle (Width / 2, Height / 2, Width / 3, ForegroundPaint);
		}
	}
}