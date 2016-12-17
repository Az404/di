using System.Collections.Generic;

namespace TagsCloudVisualization.Layouters
{
    public interface IWordsLayouter
    {
        ITags PutWords(IEnumerable<MeasuredWord> words);
    }
}