using System.Drawing;
using ResultOf;

namespace TagsCloudVisualization
{
    public interface IVisualiser
    {
        Result<Bitmap> DrawImage();
    }
}