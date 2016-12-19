using System.Drawing;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Preparers;
using TagsCloudVisualization.Renderers;

namespace TagsCloudVisualization
{
    public class TagsCloudVisualiser : IVisualiser
    {
        private readonly IWordsPreparer preparer;
        private readonly IWordsLayouter layouter;
        private readonly IImageRenderer renderer;

        public TagsCloudVisualiser(IWordsPreparer preparer, IWordsLayouter layouter, IImageRenderer renderer)
        {
            this.preparer = preparer;
            this.layouter = layouter;
            this.renderer = renderer;
        }

        public Bitmap DrawImage()
        {
            var measuredWords = preparer.GetPreparedWords();
            var tagCloud = layouter.CreateCloud(measuredWords);
            return renderer.Render(tagCloud);
        }
    }
}