using Android.Graphics;
using SuperForms.Controls;
using SuperForms.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Border), typeof(BorderRenderer))]
namespace SuperForms.Droid.Renderers
{
    public class BorderRenderer : VisualElementRenderer<BoxView>
    {
        public BorderRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            SetWillNotDraw(false);

            Invalidate();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Border.CornerRadiusProperty.PropertyName)
            {
                Invalidate();
            }
        }

        public override void Draw(Canvas canvas)
        {
            var border = Element as Border;

            base.Draw(canvas);

            var paint = new Paint();
            paint.StrokeWidth = (float)border.BorderWidth;
            paint.SetStyle(Paint.Style.Stroke);
            paint.SetARGB(ConvertTo255ScaleColor(border.BorderColor.A), ConvertTo255ScaleColor(border.BorderColor.R), ConvertTo255ScaleColor(border.BorderColor.G), ConvertTo255ScaleColor(border.BorderColor.B));

            SetLayerType(Android.Views.LayerType.Software, paint);

            var number = (float)border.BorderWidth / 2;
            var leftTopNumber = number <= 0 ? -1 : number;
            var rectF = new RectF(
                        leftTopNumber, // left
                        leftTopNumber, // top
                        canvas.Width - number, // right
                        canvas.Height - number // bottom
                );


            canvas.DrawRoundRect(rectF, 0, 0, paint);
        }

        private int ConvertTo255ScaleColor(double color)
        {
            return (int)Math.Ceiling(color * 255);
        }
    }
}