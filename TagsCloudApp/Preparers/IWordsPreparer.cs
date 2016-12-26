using System.Collections.Generic;
using TagsCloudVisualization.Measurers;

namespace TagsCloudVisualization.Preparers
{
    public interface IWordsPreparer
    {
        Result<IEnumerable<MeasuredWord>> GetPreparedWords();
    }
}