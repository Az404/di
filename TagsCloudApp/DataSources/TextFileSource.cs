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

        public Result<IEnumerable<string>> GetWords()
        {
            return Result.Of(() => File.ReadLines(fileName))
                .RefineError("Can't read words from text file");
        }
    }
}