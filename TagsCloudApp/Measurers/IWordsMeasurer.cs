using System.Collections.Generic;

namespace TagsCloudVisualization.Measurers
{
    public interface IWordsMeasurer
    {
        IEnumerable<MeasuredWord> MeasureWords(IEnumerable<string> words);
    }
}