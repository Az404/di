using System.Collections.Generic;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Preprocessors;

namespace TagsCloudVisualization.Preparers
{
    public class WordsPreparer : IWordsPreparer
    {
        private readonly IDataSource source;
        private readonly IEnumerable<IWordsPreprocessor> preprocessors;
        private readonly IWordsMeasurer wordsMeasurer;

        public WordsPreparer(IDataSource source, IEnumerable<IWordsPreprocessor> preprocessors, IWordsMeasurer wordsMeasurer)
        {
            this.source = source;
            this.preprocessors = preprocessors;
            this.wordsMeasurer = wordsMeasurer;
        }

        public IEnumerable<MeasuredWord> GetPreparedWords()
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