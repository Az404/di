using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors.WordDictionaries
{
    public interface IWordDictionary
    {
        IEnumerable<string> GetWords(SpeechPart speechPart);
    }
}