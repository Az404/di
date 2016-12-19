using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordsPreprocessor
    {
        IEnumerable<string> ProcessWords(IEnumerable<string> words);
    }
}