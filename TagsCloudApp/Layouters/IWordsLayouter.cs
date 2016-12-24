using System.Collections.Generic;
using ResultOf;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Layouters
{
    public interface IWordsLayouter
    {
        Result<ITagsCloud> CreateCloud(IEnumerable<MeasuredWord> words);
    }
}