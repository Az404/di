using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization.Settings
{
    public class ImageSettings
    {

        public ImageSettings(ImageFormat imageFormat, Palette palette, Size imageSize)
        {
            ImageFormat = imageFormat;
            Palette = palette;
            ImageSize = imageSize;
        }

        public ImageFormat ImageFormat { get; }
        public Palette Palette { get; }
        public Size ImageSize { get; set; }
        public int BorderSize { get; } = 10;
    }
}