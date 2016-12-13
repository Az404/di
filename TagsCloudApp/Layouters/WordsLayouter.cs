using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Layouters
{
    public class WordsLayouter : IWordsLayouter
    {
        private readonly IRectangleLayouter layouter;

        public WordsLayouter(IRectangleLayouter layouter)
        {
            this.layouter = layouter;
        }

        public IEnumerable<Tag> PutWords(IEnumerable<string> words, FontSettings fontSettings)
        {
            var wordsArray = words as string[] ?? words.ToArray();
            var stats = GetWordStats(wordsArray);
            var maxCount = stats.Max(kv => kv.Value);
            return wordsArray.Select(word =>
            {
                var font = new Font(fontSettings.FontFamily, CalcFontSize(fontSettings, stats, maxCount, word));
                var size = TextRenderer.MeasureText(word, font);
                var rect = layouter.PutNextRectangle(size);
                return new Tag(rect, word, font);
            });
        }

        private static int CalcFontSize(FontSettings fontSettings, Dictionary<string, int> wordStats, int maxCount, string word)
        {
            return fontSettings.MinSize + (fontSettings.MaxSize - fontSettings.MinSize)*(wordStats[word]/maxCount);
        }

        private static Dictionary<string, int> GetWordStats(IEnumerable<string> words)
        {
            return words.GroupBy(word => word).ToDictionary(group => group.Key, group => group.Count());
        }
    }
}