using System.Collections.Generic;

namespace TagsCloudVisualization.WordDictionaries
{
    public interface IWordDictionary
    {
        IEnumerable<string> GetWords(SpeechPart speechPart);
    }
}