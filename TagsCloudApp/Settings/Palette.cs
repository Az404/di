using System.Drawing;

namespace TagsCloudVisualization.Settings
{
    public class Palette
    {
        public Palette(Color primaryColor, Color secondaryColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        public Color PrimaryColor { get; }
        public Color SecondaryColor { get; }
    }
}