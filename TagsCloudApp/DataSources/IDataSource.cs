using System.Collections.Generic;
using ResultOf;

namespace TagsCloudVisualization.DataSources
{
    public interface IDataSource
    {
        Result<IEnumerable<string>> GetWords();
    }
}