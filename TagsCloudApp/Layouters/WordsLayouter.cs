using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Layouters
{
    public class WordsLayouter : IWordsLayouter
    {
        private readonly Func<IRectangleLayouter> layouterFactory;
        private readonly FontSettings fontSettings;

        public WordsLayouter(Func<IRectangleLayouter> layouterFactory, FontSettings fontSettings)
        {
            this.layouterFactory = layouterFactory;
            this.fontSettings = fontSettings;
        }

        public Result<ITagsCloud> CreateCloud(IEnumerable<MeasuredWord> measuredWords)
        {
            var layouter = layouterFactory();
            var tags = new List<Tag>();
            foreach (var measuredWord in measuredWords)
            {
                var font = new Font(fontSettings.FontFamily, CalcFontSize(measuredWord.Weight));
                var size = TextRenderer.MeasureText(measuredWord.Value, font);
                var rectResult = layouter.PutNextRectangle(size);
                if (!rectResult.IsSuccess)
                    return rectResult
                        .TranslateFail<Rectangle, ITagsCloud>()
                        .RefineError($"Can't put bounding rectangle for '{measuredWord.Value}'");
                tags.Add(new Tag(rectResult.Value, measuredWord.Value, font));
            }
            return new TagsCloud(tags);
        }

        private int CalcFontSize(double weight)
        {
            return (int)(fontSettings.MinSize + (fontSettings.MaxSize - fontSettings.MinSize) * weight);
        }
    }
}