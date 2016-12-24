using System.Collections.Generic;
using ResultOf;
using TagsCloudVisualization.Measurers;

namespace TagsCloudVisualization.Preparers
{
    public interface IWordsPreparer
    {
        Result<IEnumerable<MeasuredWord>> GetPreparedWords();
    }
}