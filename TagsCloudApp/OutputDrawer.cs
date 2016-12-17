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
            // CR: Can be extract to an interface with injected dependencies
            // Bascially from the renderer perspective you only care about measured words
            // + don't extract words in the constructor
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