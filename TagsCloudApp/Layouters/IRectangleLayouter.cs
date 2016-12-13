using System.Drawing;

namespace TagsCloudVisualization.Layouters
{
    public interface IRectangleLayouter
    {
        Rectangle PutNextRectangle(Size rectangleSize);
    }
}