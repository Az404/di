using System.Collections.Generic;

namespace TagsCloudVisualization.Measurers
{
    public interface IWordsMeasurer
    {
        Result<IEnumerable<MeasuredWord>> MeasureWords(IEnumerable<string> words);
    }
}