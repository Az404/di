using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Renderers
{
    public class TagsRenderer : IImageRenderer
    {
        public Bitmap Render(IEnumerable<Tag> tags, ImageSettings settings)
        {
            var bitmap = new Bitmap(settings.ImageSize.Width, settings.ImageSize.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                foreach (var tag in tags)
                {
                    graphics.DrawRectangle(new Pen(settings.Palette.SecondaryColor), tag.Rectangle);
                    var boundingRect = new Rectangle(tag.Rectangle.Location,
                        tag.Rectangle.Size + new Size(settings.BorderSize, settings.BorderSize));
                    graphics.DrawString(tag.Word, tag.Font, new SolidBrush(settings.Palette.PrimaryColor), boundingRect);
                }
            }
            return bitmap;
        }
    }
}