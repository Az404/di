﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ResultOf;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Layouters
{
    public class WordsLayouter : IWordsLayouter
    {
        // CR: IRectangleLayouter is stateful => one-time object
        // Better replace with IRectangleLayouterFactory and
        // create for each CreateCloud call
        private readonly IRectangleLayouter layouter;
        private readonly FontSettings fontSettings;

        public WordsLayouter(IRectangleLayouter layouter, FontSettings fontSettings)
        {
            this.layouter = layouter;
            this.fontSettings = fontSettings;
        }

        public Result<ITagsCloud> CreateCloud(IEnumerable<MeasuredWord> measuredWords)
        {
            // To avoid doing this, you can encapsulate normalized weight into MeasuredWord
            var wordsArray = measuredWords as MeasuredWord[] ?? measuredWords.ToArray();
            var maxWeight = wordsArray.Length > 0 ? wordsArray.Max(w => w.Weight) : 1;
            // CR: I can imagine failures in IRectangleLayouter
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