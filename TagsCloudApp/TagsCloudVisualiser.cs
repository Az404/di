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

        public Result<Bitmap> DrawImage()
        {
            return preparer.GetPreparedWords()
                .Then(measuredWords => layouter.CreateCloud(measuredWords))
                .Then(tagsCloud => renderer.Render(tagsCloud));
        }
    }
}