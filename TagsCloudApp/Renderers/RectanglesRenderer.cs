using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Renderers
{
    public class RectanglesRenderer
    {
        public ImageSettings Settings { get; set; }

        public RectanglesRenderer(ImageSettings settings)
        {
            Settings = settings;
        }

        public Bitmap Render(IEnumerable<Rectangle> rectangles)
        {
            var bitmap = new Bitmap(Settings.Width, Settings.Height);
            using (var graphics = Graphics.FromImage(bitmap))
                foreach (var rect in rectangles)
                    graphics.DrawRectangle(new Pen(Settings.Palette.SecondaryColor), rect);
            return bitmap;
        }
    }
}