using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Preprocessors;
using TagsCloudVisualization.Renderers;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization
{
    public class Client : IClient
    {
        public ImageSettings ImageSettings { get; set; }
        public FontSettings FontSettings { get; set; }

        private readonly IEnumerable<string> words;
        private readonly IWordsLayouter layouter;
        private readonly IImageRenderer renderer;

        public Client(IDataSource source, IWordPreprocessor[] preprocessors, IWordsLayouter layouter, IImageRenderer renderer, ImageSettings imageSettings, FontSettings fontSettings)
        {
            this.layouter = layouter;
            this.renderer = renderer;
            FontSettings = fontSettings;
            ImageSettings = imageSettings;
            words = PrepareWords(source, preprocessors);
        }

        public Bitmap DrawImage()
        {
            return renderer.Render(layouter.PutWords(words, FontSettings), ImageSettings);
        }

        private static IEnumerable<string> PrepareWords(IDataSource source, IWordPreprocessor[] preprocessors)
        {
            var words = source.GetWords().ToArray();
            foreach (var wordPreprocessor in preprocessors.OrderBy(p => p.Priority))
            {
                words = wordPreprocessor.ProcessWords(words).ToArray();
            }
            return words;
        }
    }
}