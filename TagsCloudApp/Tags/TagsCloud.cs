using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.Tags
{
    public class TagsCloud : ITagsCloud
    {
        public Tag[] Tags { get; }

        public TagsCloud(IEnumerable<Tag> tags)
        {
            Tags = tags.ToArray();
        }
    }
}