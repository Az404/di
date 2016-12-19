using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Layouters
{
    public class WordsLayouter : IWordsLayouter
    {
        private readonly IRectangleLayouter layouter;
        private readonly FontSettings fontSettings;

        public WordsLayouter(IRectangleLayouter layouter, FontSettings fontSettings)
        {
            this.layouter = layouter;
            this.fontSettings = fontSettings;
        }

        public ITagsCloud CreateCloud(IEnumerable<MeasuredWord> measuredWords)
        {
            var wordsArray = measuredWords as MeasuredWord[] ?? measuredWords.ToArray();
            var maxWeight = wordsArray.Max(w => w.Weight);
            return new TagsCloud(wordsArray.Select(word =>
            {
                var font = new Font(fontSettings.FontFamily, CalcFontSize(word.Weight, maxWeight, fontSettings));
                var size = TextRenderer.MeasureText(word.Value, font);
                var rect = layouter.PutNextRectangle(size);
                return new Tag(rect, word.Value, font);
            }));
        }

        private static int CalcFontSize(int weight, int maxWeight, FontSettings fontSettings)
        {
            return fontSettings.MinSize + (fontSettings.MaxSize - fontSettings.MinSize)*(weight/maxWeight);
        }
    }
}