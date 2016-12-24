using System.Collections.Generic;
using ResultOf;
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

        public Result<IEnumerable<MeasuredWord>> GetPreparedWords()
        {
            var result = source.GetWords();
            foreach (var wordPreprocessor in preprocessors)
            {
                result = result.Then(words => wordPreprocessor.ProcessWords(words));
            }
            return result.Then(words => wordsMeasurer.MeasureWords(words));
        }
    }
}