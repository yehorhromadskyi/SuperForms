using CoreGraphics;
using SuperForms.Controls;
using SuperForms.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Border), typeof(BorderRenderer))]
namespace SuperForms.iOS.Renderers
{
    public class BorderRenderer : VisualElementRenderer<BoxView>
    {
        public BorderRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((Border)Element).CornerRadius / 2.0f;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Border.CornerRadiusProperty.PropertyName)
            {
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            var border = (Border)Element;
            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetFillColor(border.Color.ToCGColor());
                context.SetStrokeColor(border.BorderColor.ToCGColor());
                context.SetLineWidth((float)border.BorderWidth);

                var rCorner = Bounds.Inset((int)border.BorderWidth / 2, (int)border.BorderWidth / 2);

                var radius = (nfloat)border.CornerRadius;
                radius = (nfloat)Math.Max(0, Math.Min(radius, Math.Max(rCorner.Height / 2, rCorner.Width / 2)));

                var path = CGPath.FromRoundedRect(rCorner, radius, radius);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);
            }
        }
    }
}
