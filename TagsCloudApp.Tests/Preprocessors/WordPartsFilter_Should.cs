using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Preprocessors;
using TagsCloudVisualization.WordDictionaries;

namespace TagsCloudVisualizationTests.Preprocessors
{
    [TestFixture]
    public class WordPartsFilter_Should
    {
        private SimpleDictionary dictionary;
        private WordPartsFilter filter;

        [SetUp]
        public void SetUp()
        {
            dictionary = new SimpleDictionary();
            filter = new WordPartsFilter(dictionary);
        }

        [Test]
        public void LeaveUnmatchedWords()
        {
            var words = new[] {"123", "qwer", "йцукен", "дом", "белый", "делать"};
            filter.ProcessWords(words).Should().BeEquivalentTo(words);
        }

        [Test]
        public void FilterWordsFromDictionary()
        {
            var words = new[] { "в", "к", "дом", "он", "делать" };
            filter.ProcessWords(words).Should().BeEquivalentTo("дом", "делать");
        }
    }
}