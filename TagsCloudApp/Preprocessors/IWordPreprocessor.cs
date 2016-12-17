using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors
{
    public interface IWordPreprocessor
    {
        // CR: This should not be a part of the interface,
        // but a part of implementation. I can imagine different
        // situation with the same set of preprocessors re-arranged
        int Priority { get; }
        IEnumerable<string> ProcessWords(IEnumerable<string> words);
    }
}