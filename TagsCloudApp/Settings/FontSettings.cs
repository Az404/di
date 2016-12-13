using System.Drawing;

namespace TagsCloudVisualization.Settings
{
    public class FontSettings
    {
        public FontFamily FontFamily { get; set; } = FontFamily.GenericSansSerif;
        public int MinSize { get; set; } = 14;
        public int MaxSize { get; set; } = 28;

        public FontSettings() { }

        public FontSettings(FontFamily fontFamily, int minSize, int maxSize)
        {
            FontFamily = fontFamily;
            MinSize = minSize;
            MaxSize = maxSize;
        }
    }
}