using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization
{
    public interface IClient
    {
        ImageSettings ImageSettings { get; set; }
        FontSettings FontSettings { get; set; }
        Bitmap DrawImage();
    }
}