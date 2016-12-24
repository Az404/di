using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using ResultOf;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Renderers
{
    public class TagsRenderer : IImageRenderer
    {
        public ImageSettings Settings { get; set; }

        public TagsRenderer(ImageSettings settings)
        {
            Settings = settings;
        }

        public Result<Bitmap> Render(ITagsCloud cloud)
        {
            return cloud.Validate(IsCloudFitsInImage, "Cloud is larger than image")
                .Then(DoRender)
                .RefineError("Can't render image");
        }

        public Bitmap DoRender(ITagsCloud cloud)
        {
            var bitmap = new Bitmap(Settings.Width, Settings.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                foreach (var tag in cloud.Tags)
                {
                    graphics.DrawRectangle(new Pen(Settings.Palette.SecondaryColor), tag.Rectangle);
                    var boundingRect = new Rectangle(tag.Rectangle.Location,
                        tag.Rectangle.Size + new Size(Settings.BorderSize, Settings.BorderSize));
                    graphics.DrawString(tag.Word, tag.Font, new SolidBrush(Settings.Palette.PrimaryColor), boundingRect);
                }
            }
            return bitmap;
        }

        public bool IsCloudFitsInImage(ITagsCloud cloud)
        {
            if (cloud.Tags.Length == 0)
                return true;
            var minX = cloud.Tags.Min(tag => tag.Rectangle.Left);
            var minY = cloud.Tags.Min(tag => tag.Rectangle.Top);
            var maxX = cloud.Tags.Max(tag => tag.Rectangle.Right);
            var maxY = cloud.Tags.Max(tag => tag.Rectangle.Bottom);
            return minX >= 0 && minY >= 0 && maxX <= Settings.Width && maxY <= Settings.Height;
        }
    }
}