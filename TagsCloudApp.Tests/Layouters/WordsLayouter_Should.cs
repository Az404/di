using System.Drawing;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualizationTests.Layouters
{
    [TestFixture]
    public class WordsLayouter_Should
    {
        private IRectangleLayouter rectLayouter;
        private WordsLayouter layouter;

        [SetUp]
        public void SetUp()
        {
            rectLayouter = A.Fake<IRectangleLayouter>();
            layouter = new WordsLayouter(() => rectLayouter, new FontSettings());
        }

        [Test]
        public void UseRectangleLayouter_ForPuttingWords()
        {
            var words = new[] {new MeasuredWord("a", 0.5), new MeasuredWord("b", 1), new MeasuredWord("c", 0.3)};
            layouter.CreateCloud(words);
            A.CallTo(() => rectLayouter.PutNextRectangle(A<Size>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Times(words.Length));
        }

        [Test]
        public void SelectFontSize_ByWeight()
        {
            var words = new[]
            {
                new MeasuredWord("a", 0.3), new MeasuredWord("b", 0.7), new MeasuredWord("c", 0.4), new MeasuredWord("d", 1)
            };
            var tags = layouter.CreateCloud(words).GetValueOrThrow().Tags;
            tags.OrderBy(t => t.Font.Size)
                .Select(t => t.Word)
                .Should()
                .BeEquivalentTo(words.OrderBy(w => w.Weight).Select(w => w.Value));
        }
    }
}