using System.Collections.Generic;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Layouters
{
    public interface IWordsLayouter
    {
        IEnumerable<Tag> PutWords(IEnumerable<string> words, FontSettings fontSettings);
    }
}