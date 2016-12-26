using System.Collections.Generic;

namespace TagsCloudVisualization.DataSources
{
    public interface IDataSource
    {
        Result<IEnumerable<string>> GetWords();
    }
}