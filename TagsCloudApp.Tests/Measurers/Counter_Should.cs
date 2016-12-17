using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization;
using TagsCloudVisualization.Measurers;

namespace TagsCloudVisualizationTests.Measurers
{
    [TestFixture]
    public class Counter_Should
    {
        [Test]
        public void Count_WordStats()
        {
            var wordCounter = new WordCounter();
            wordCounter.MeasureWords(new[] {"a", "b", "c", "b", "c", "b"})
                .Should()
                .BeEquivalentTo(new MeasuredWord("a", 1), new MeasuredWord("b", 3), new MeasuredWord("c", 2));
        }
    }
}