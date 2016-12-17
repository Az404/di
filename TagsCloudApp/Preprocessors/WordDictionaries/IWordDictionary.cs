using System.Collections.Generic;

namespace TagsCloudVisualization.Preprocessors.WordDictionaries
{
    // CR: Extract from TagsCloudVisualization.Preprocessors, this is generic stuff
    public interface IWordDictionary
    {
        IEnumerable<string> GetWords(SpeechPart speechPart);
    }
}