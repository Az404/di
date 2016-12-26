using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Measurers;

namespace TagsCloudVisualizationTests.Measurers
{
    [TestFixture]
    public class Counter_Should
    {
        [Test]
        public void Count_WordStats()
        {
            var wordsCounter = new WordsCounter();
            wordsCounter.MeasureWords(new[] {"a", "b", "c", "b", "b", "b"})
                .GetValueOrThrow()
                .Should()
                .BeEquivalentTo(new MeasuredWord("a", 0.25), new MeasuredWord("b", 1), new MeasuredWord("c", 0.25));
        }
    }
}