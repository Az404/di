using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using TagsCloudVisualization;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Preprocessors;
using TagsCloudVisualization.Renderers;

namespace TagsCloudVisualizationTests
{
    [TestFixture]
    public class OutputDrawer_Should
    {
        private OutputDrawer drawer;
        private IDataSource dataSource;
        private IList<IWordPreprocessor> preprocessors;
        private IWordsLayouter layouter;
        private IImageRenderer renderer;
        private IWordsMeasurer wordsMeasurer;

        [SetUp]
        public void SetUp()
        {
            dataSource = A.Fake<IDataSource>();
            preprocessors = A.CollectionOfFake<IWordPreprocessor>(2);
            layouter = A.Fake<IWordsLayouter>();
            renderer = A.Fake<IImageRenderer>();
            wordsMeasurer = A.Fake<IWordsMeasurer>();
        }

        public void CreateDrawer()
        {
            drawer = new OutputDrawer(dataSource, preprocessors, layouter, renderer, wordsMeasurer);
            drawer.DrawImage();
        }

        [Test]
        public void ReadWordsFromDataSource()
        {
            CreateDrawer();
            A.CallTo(() => dataSource.GetWords()).MustHaveHappened();
        }

        [Test]
        public void ApplyAllPreprocessorsToWords()
        {
            CreateDrawer();
            foreach (var wordPreprocessor in preprocessors)
                A.CallTo(() => wordPreprocessor.ProcessWords(A<IEnumerable<string>>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void ApplyPreprocessorsToWords_Sequientally()
        {
            var source = new[] {"a", "b", "c"};
            var reduced = new[] {"a", "c"};
            A.CallTo(() => dataSource.GetWords()).Returns(source);
            A.CallTo(() => preprocessors[0].ProcessWords(source)).Returns(reduced);

            CreateDrawer();

            A.CallTo(() => preprocessors[0].ProcessWords(source)).MustHaveHappened();
            A.CallTo(() => preprocessors[1].ProcessWords(reduced)).MustHaveHappened();
        }

        [Test]
        public void MeasureWords_AfterLastPreprocessor()
        {
            var words = new[] {"a", "b"};
            A.CallTo(() => preprocessors[1].ProcessWords(A<IEnumerable<string>>.Ignored)).Returns(words);

            CreateDrawer();

            A.CallTo(() => wordsMeasurer.MeasureWords(words)).MustHaveHappened();
        }
    }
}