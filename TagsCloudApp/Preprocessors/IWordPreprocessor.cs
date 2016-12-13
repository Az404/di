using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordPreprocessor
    {
        int Priority { get; }
        IEnumerable<string> ProcessWords(IEnumerable<string> words);
    }
}