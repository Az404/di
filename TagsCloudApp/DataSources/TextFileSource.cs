using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.DataSources
{
    public class TextFileSource : IDataSource
    {
        private readonly string fileName;

        public TextFileSource(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<string> GetWords()
        {
            return File.ReadLines(fileName);
        }
    }
}