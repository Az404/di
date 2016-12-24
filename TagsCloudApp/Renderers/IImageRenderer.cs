using System.Drawing;
using ResultOf;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Renderers
{
    public interface IImageRenderer
    {
        Result<Bitmap> Render(ITagsCloud cloud);
    }
}