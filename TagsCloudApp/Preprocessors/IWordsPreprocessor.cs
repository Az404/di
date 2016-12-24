using System.Collections.Generic;
using ResultOf;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordsPreprocessor
    {
        Result<IEnumerable<string>> ProcessWords(IEnumerable<string> words);
    }
}