using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.WordDictionaries;

namespace TagsCloudVisualization.Preprocessors
{
    public class WordPartsFilter : IWordsPreprocessor
    {
        public SpeechPart[] FilteredSpeechParts { get; set; }= {SpeechPart.Preposition, SpeechPart.Pronoun};

        private readonly HashSet<string> boringWords;

        public WordPartsFilter(IWordDictionary dictionary)
        {
            boringWords = new HashSet<string>(FilteredSpeechParts.SelectMany(dictionary.GetWords));
        }

        public IEnumerable<string> ProcessWords(IEnumerable<string> words)
        {
            return words.Where(word => !boringWords.Contains(word.ToLower()));
        }
    }
}