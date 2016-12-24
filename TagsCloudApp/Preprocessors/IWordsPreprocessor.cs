using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordsPreprocessor
    {
        Result<IEnumerable<string>> ProcessWords(IEnumerable<string> words);
    }
}