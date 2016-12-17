using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization.Settings
{
    public class ImageSettings
    {
        public ImageSettings(Palette palette)
        {
            Palette = palette;
        }

        public ImageFormat ImageFormat { get; set; } = ImageFormat.Png;
        public Palette Palette { get; set; }
        public int Width { get; set; } = 2000;
        public int Height { get; set; } = 1000;
        public int BorderSize { get; } = 10;
        public Point Center => new Point(Width / 2, Height / 2);
    }
}