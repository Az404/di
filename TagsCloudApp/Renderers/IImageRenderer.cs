using System.Drawing;

namespace TagsCloudVisualization.Renderers
{
    public interface IImageRenderer
    {
        Bitmap Render(ITags tags);
    }
}