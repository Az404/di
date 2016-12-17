using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Renderers
{
    public interface IImageRenderer
    {
        // Nit: Passing settings as a parameters doesn't seems like a good idea, but OK
        // CR: Wrap IEnumerable<Tag> in one object, bad pattern passing pure collections
        // between interfaces, not extensible
        Bitmap Render(IEnumerable<Tag> tags, ImageSettings settings);
    }
}