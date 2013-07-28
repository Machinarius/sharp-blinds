using System;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;

namespace BlindsPort {
	/// <summary>
	/// This is a port of the BlindsView class built by Sony and explained at 
	/// http://developer.sonymobile.com/knowledge-base/tutorials/ui-graphics/use-the-blindsview-effect-from-the-xperia-lockscreen/
	/// 
	///
	/// Copyright (c) 2013, Sony Mobile Communications AB
	/// All rights reserved.

	///	Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
	/// * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
	/// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
	/// * Neither the name of Sony Mobile nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
	///	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

	/// @author Johan Henricson
	/// ported to Xamarin.Android by German "Machinarius" Valencia
	/// </summary>
	public class BlindsContainer : LinearLayout {

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

		protected override void DispatchDraw (Canvas canvas) {
			OriginalBitmap = Bitmap.CreateBitmap (Width, Height, Bitmap.Config.Argb8888);
			OriginalCanvas = new Canvas (OriginalBitmap);
			if (BackgroundDrawable != null) {
				BackgroundDrawable.Draw (canvas);
			}

			base.DispatchDraw (canvas);
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