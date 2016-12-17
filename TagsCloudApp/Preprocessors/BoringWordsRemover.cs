using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.Preprocessors.WordDictionaries;

namespace TagsCloudVisualization.Preprocessors
{
    // CR: Don't commit such names into the repo
    public class BoringWordsRemover : IWordPreprocessor
    {
        public int Priority { get; } = 10;

        private static readonly SpeechPart[] BoringSpeechParts = {SpeechPart.Preposition, SpeechPart.Pronoun};

        private readonly HashSet<string> boringWords;

        public BoringWordsRemover(IWordDictionary dictionary)
        {
            boringWords = new HashSet<string>(BoringSpeechParts.SelectMany(dictionary.GetWords));
        }

        public IEnumerable<string> ProcessWords(IEnumerable<string> words)
        {
            return words.Where(word => !boringWords.Contains(word));
        }
    }
}