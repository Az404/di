using System;
using System.Drawing;
using System.Reflection;
using Autofac;
using Fclp;
using TagsCloudVisualization;
using TagsCloudVisualization.DataSources;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Settings;

namespace TagsCloudApp.CLI
{
    internal class Program
    {
        private static readonly string Usage = $"Usage: {AppDomain.CurrentDomain.FriendlyName} [ -h | -help ] -t tags-file -i image-file";

        private static void Main(string[] args)
        {
            var appOptions = ProcessArgs(BuildCommandLineParser(), args);
            
            var container = BuildContainer(appOptions);

            var visualiser = container.Resolve<IVisualiser>();

            visualiser.DrawImage()
                .Then(bitmap =>
                {
                    using (bitmap)
                        bitmap.Save(appOptions.ImageFileName);
                })
                .OnFail(Console.WriteLine);
        }

        private static IContainer BuildContainer(AppOptions appOptions)
        {
            var assembly = Assembly.GetAssembly(typeof(TagsCloudVisualiser));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(appOptions).AsSelf();
            builder.RegisterInstance(new Palette(Color.Green, Color.LightGreen));
            builder.RegisterInstance(new TextFileSource(appOptions.TagsFileName)).As<IDataSource>();
            builder.Register(c => new CircularCloudLayouter(c.Resolve<ImageSettings>().Center)).As<IRectangleLayouter>();
            return builder.Build();
        }
        
        private static AppOptions ProcessArgs(IFluentCommandLineParser<AppOptions> parser, string[] args)
        {
            var result = parser.Parse(args);

            if (!result.HelpCalled && !result.HasErrors)
                return parser.Object;

            Console.WriteLine(Usage);
            Environment.Exit(1);
            return null;
        }

        private static FluentCommandLineParser<AppOptions> BuildCommandLineParser()
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

            commandLineParser
                .SetupHelp("h", "help")
                .WithHeader(Usage)
                .Callback(text => Console.WriteLine(text));
            return commandLineParser;
        }
    }
}