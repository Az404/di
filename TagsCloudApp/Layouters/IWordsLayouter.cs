using System.Collections.Generic;

namespace TagsCloudVisualization.Layouters
{
    public interface IWordsLayouter
    {
        // CR: But it doesn't make any sense?
        // Why layouting words gives you tags?
        ITags PutWords(IEnumerable<MeasuredWord> words);
    }
}