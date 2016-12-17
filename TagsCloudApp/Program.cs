using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Fclp;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.UI;

namespace TagsCloudVisualization
{
    internal class Program
    {
        // CR: Should not be part of the program class
        private const int Width = 2000;
        private const int Height = 1000;
        // CR: Same
        private static readonly Point Center = new Point(Width / 2, Height / 2);

        private static void Main(string[] args)
        {
            var appOptions = ProcessArgs(args);
            var assembly = Assembly.GetAssembly(typeof(Program));

            // CR: At least wrap in function
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            builder.RegisterInstance(appOptions).AsSelf();
            builder.RegisterInstance(new Palette(Color.Green, Color.LightGreen));
            var imageSize = new Size(Width, Height);
            builder.Register(c => new ImageSettings(ImageFormat.Png, c.Resolve<Palette>(), imageSize));
            builder.RegisterInstance(new FontSettings());
            builder.RegisterInstance(new TextFileSource(appOptions.TagsFileName)).As<IDataSource>();
            builder.RegisterInstance(new CircularCloudLayouter(Center)).As<IRectangleLayouter>();
            var container = builder.Build();

            container.Resolve<IUserInterface>().Run();
        }

        // CR: This function build parser AND executes it, bad pattern
        private static AppOptions ProcessArgs(string[] args)
        {
            var commandLineParser = new FluentCommandLineParser<AppOptions>();

            commandLineParser
                .Setup(options => options.TagsFileName)
                .As('t')
                .Required()
                .WithDescription("Path to tags file");

            commandLineParser
                .Setup(options => options.ImageFileName)
                .As('i')
                .Required()
                .WithDescription("Path to output image");

            // CR: This can be extracted to a field
            var usage = $"Usage: {AppDomain.CurrentDomain.FriendlyName} [ -h | -help ] -t tags-file -i image-file";

            commandLineParser
                .SetupHelp("h", "help")
                .WithHeader(usage)
                .Callback(text => Console.WriteLine(text));

            var result = commandLineParser.Parse(args);

            var exit = result.HelpCalled;

            if (result.HasErrors)
            {
                Console.WriteLine(usage);
                exit = true;
            }

            if (!File.Exists(commandLineParser.Object.TagsFileName))
            {
                Console.WriteLine("File not found");
                exit = true;
            }

            if (exit)
                Application.Exit();

            return commandLineParser.Object;
        }
    }
}