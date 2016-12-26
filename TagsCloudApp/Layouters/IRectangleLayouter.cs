using System.Drawing;

namespace TagsCloudVisualization.Layouters
{
    public interface IRectangleLayouter
    {
        Result<Rectangle> PutNextRectangle(Size rectangleSize);
    }
}