using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public class Tags : List<Tag>, ITags
    {
        public Tags(IEnumerable<Tag> collection) : base(collection)
        {
        }
    }
}