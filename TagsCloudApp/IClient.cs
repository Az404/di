using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization
{
    // CR: It's not client, come up with a meaningful name
    public interface IClient
    {
        ImageSettings ImageSettings { get; set; }
        FontSettings FontSettings { get; set; }
        Bitmap DrawImage();
    }
}