using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Preprocessors;
using TagsCloudVisualization.Renderers;

namespace TagsCloudVisualization
{
    public class OutputDrawer : IOutputDrawer
    {
        private readonly IEnumerable<MeasuredWord> words;
        private readonly IWordsLayouter layouter;
        private readonly IImageRenderer renderer;

        public OutputDrawer(IDataSource source, IEnumerable<IWordPreprocessor> preprocessors, IWordsLayouter layouter, IImageRenderer renderer, IWordsMeasurer wordsMeasurer)
        {
            this.layouter = layouter;
            this.renderer = renderer;
            words = PrepareWords(source, preprocessors, wordsMeasurer);
        }

        public Bitmap DrawImage()
        {
            return renderer.Render(layouter.PutWords(words));
        }

        private static IEnumerable<MeasuredWord> PrepareWords(IDataSource source, IEnumerable<IWordPreprocessor> preprocessors, IWordsMeasurer wordsMeasurer)
        {
            var words = source.GetWords();
            foreach (var wordPreprocessor in preprocessors)
            {
                words = wordPreprocessor.ProcessWords(words);
            }
            return wordsMeasurer.MeasureWords(words);
        }
    }
}