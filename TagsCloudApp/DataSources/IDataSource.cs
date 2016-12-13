using System.Collections.Generic;

namespace TagsCloudVisualization.DataSources
{
    public interface IDataSource
    {
        IEnumerable<string> GetWords();
    }
}