using System.Drawing;
using System.Drawing.Text;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Renderers
{
    public class TagsRenderer : IImageRenderer
    {
        public ImageSettings Settings { get; set; }

        public TagsRenderer(ImageSettings settings)
        {
            Settings = settings;
        }

        public Bitmap Render(ITags tags)
        {
            var bitmap = new Bitmap(Settings.Width, Settings.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                foreach (var tag in tags)
                {
                    graphics.DrawRectangle(new Pen(Settings.Palette.SecondaryColor), tag.Rectangle);
                    var boundingRect = new Rectangle(tag.Rectangle.Location,
                        tag.Rectangle.Size + new Size(Settings.BorderSize, Settings.BorderSize));
                    graphics.DrawString(tag.Word, tag.Font, new SolidBrush(Settings.Palette.PrimaryColor), boundingRect);
                }
            }
            return bitmap;
        }
    }
}