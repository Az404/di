using System.Drawing;

namespace TagsCloudVisualization
{
    public interface IVisualiser
    {
        Result<Bitmap> DrawImage();
    }
}