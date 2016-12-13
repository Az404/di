namespace TagsCloudVisualization.UI
{
    public class ClInterface : IUserInterface
    {
        private readonly IClient client;
        private readonly string outputFileName;

        public ClInterface(AppOptions options, IClient client)
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