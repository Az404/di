using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Measurers;
using TagsCloudVisualization.Preparers;
using TagsCloudVisualization.Preprocessors;

namespace TagsCloudVisualizationTests.Preparers
{
    [TestFixture]
    public class WordsPreparer_Should
    {
        private WordsPreparer preparer;
        private IDataSource dataSource;
        private IList<IWordsPreprocessor> preprocessors;
        private IWordsMeasurer wordsMeasurer;

        [SetUp]
        public void SetUp()
        {
            dataSource = A.Fake<IDataSource>();
            preprocessors = A.CollectionOfFake<IWordsPreprocessor>(2);
            wordsMeasurer = A.Fake<IWordsMeasurer>();
            preparer = new WordsPreparer(dataSource, preprocessors, wordsMeasurer);
        }

        [Test]
        public void ReadWordsFromDataSource()
        {
            preparer.GetPreparedWords();
            A.CallTo(() => dataSource.GetWords()).MustHaveHappened();
        }

        [Test]
        public void ApplyAllPreprocessorsToWords()
        {
            preparer.GetPreparedWords();
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

            preparer.GetPreparedWords();

            A.CallTo(() => preprocessors[0].ProcessWords(source)).MustHaveHappened();
            A.CallTo(() => preprocessors[1].ProcessWords(reduced)).MustHaveHappened();
        }

        [Test]
        public void MeasureWords_AfterLastPreprocessor()
        {
            var words = new[] {"a", "b"};
            A.CallTo(() => preprocessors[1].ProcessWords(A<IEnumerable<string>>.Ignored)).Returns(words);

            preparer.GetPreparedWords();

            A.CallTo(() => wordsMeasurer.MeasureWords(words)).MustHaveHappened();
        }

        [Test]
        public void ReturnMeasuredWords()
        {
            var measuredWords = new[] {new MeasuredWord("a", 1), new MeasuredWord("b", 2)};
            A.CallTo(() => wordsMeasurer.MeasureWords(A<IEnumerable<string>>.Ignored)).Returns(measuredWords);

            preparer.GetPreparedWords().ShouldBeEquivalentTo(measuredWords);
        }
    }
}