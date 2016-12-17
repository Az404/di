namespace TagsCloudVisualization.UI
{
    public class ClInterface
    {
        private readonly IOutputDrawer client;
        private readonly string outputFileName;

        public ClInterface(AppOptions options, IOutputDrawer client)
        {
            this.client = client;
            outputFileName = options.ImageFileName;
        }

        public void Run()
        {
            using (var bitmap = client.DrawImage())
            {
                bitmap.Save(outputFileName);
            }
        }
    }
}