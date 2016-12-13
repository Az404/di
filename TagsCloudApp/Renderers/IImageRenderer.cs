using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Renderers
{
    public interface IImageRenderer
    {
        Bitmap Render(IEnumerable<Tag> tags, ImageSettings settings);
    }
}