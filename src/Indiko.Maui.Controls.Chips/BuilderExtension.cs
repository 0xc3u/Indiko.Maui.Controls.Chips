using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Indiko.Maui.Controls.Chips;

public static class BuilderExtension
{
    public static MauiAppBuilder UseChipsView(this MauiAppBuilder builder)
    {
        return builder.UseSkiaSharp();
    }
}
