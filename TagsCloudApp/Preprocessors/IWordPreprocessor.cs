using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordPreprocessor
    {
        IEnumerable<string> ProcessWords(IEnumerable<string> words);
    }
}