using System.Collections.Generic;
using TagsCloudVisualization.Measurers;

namespace TagsCloudVisualization.Preparers
{
    public interface IWordsPreparer
    {
        IEnumerable<MeasuredWord> GetPreparedWords();
    }
}