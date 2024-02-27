using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace Indiko.Maui.Controls.Chips;
public class XSymbolView : SKCanvasView
{
    public static readonly BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor), typeof(Color), typeof(XSymbolView), Colors.Black, propertyChanged: RedrawCanvas);

    public Color LineColor
    {
        get => (Color)GetValue(LineColorProperty);
        set => SetValue(LineColorProperty, value);
    }

    private static void RedrawCanvas(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as XSymbolView;
        view?.InvalidateSurface();
    }

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		InvalidateSurface();
	}

	protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);
        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        SKCanvas canvas = surface.Canvas;

        const float padding = 2;

        canvas.Clear();

        using SKPaint paint = new();
        paint.Style = SKPaintStyle.Stroke;
        paint.Color = LineColor.ToSKColor();
        paint.StrokeWidth = 3;
        paint.IsAntialias = true;

        canvas.DrawLine(padding, padding, info.Width - padding, info.Height - padding, paint);
        canvas.DrawLine(info.Width - padding, padding, padding, info.Height - padding, paint);
    }
}