using System.Collections.Generic;
using System.Linq;
using ResultOf;
using TagsCloudVisualization.WordDictionaries;

namespace TagsCloudVisualization.Preprocessors
{
    public class WordPartsFilter : IWordsPreprocessor
    {
        public SpeechPart[] FilteredSpeechParts { get; set; }= {SpeechPart.Preposition, SpeechPart.Pronoun};

        private readonly HashSet<string> filteredWords;

        public WordPartsFilter(IWordDictionary dictionary)
        {
            filteredWords = new HashSet<string>(FilteredSpeechParts.SelectMany(dictionary.GetWords));
        }

        public Result<IEnumerable<string>> ProcessWords(IEnumerable<string> words)
        {
            return Result.Ok(words.Where(word => !filteredWords.Contains(word.ToLower())));
        }
    }
}