using System.Drawing;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Renderers
{
    public interface IImageRenderer
    {
        Bitmap Render(ITagsCloud cloud);
    }
}