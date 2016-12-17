using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.Measurers
{
    // CR: WordCounter but IWordsMeasurer
    public class WordCounter : IWordsMeasurer
    {
        public IEnumerable<MeasuredWord> MeasureWords(IEnumerable<string> words)
        {
            return words.GroupBy(word => word).Select(group => new MeasuredWord(group.Key, group.Count()));
        }
    }
}