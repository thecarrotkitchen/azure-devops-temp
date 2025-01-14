using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Parsing;
using Spectre.Console;

namespace CIDevTools;
class CIDevTools
{
    static async Task<int> Main(string[] args)
    {
        var generateReportOption = new Option<string?>(
            name: "--htmlReport",
            description: "Generates an html report of the build's pipeline failures.",
            getDefaultValue: () => "false");
        var appjsonfile = new Option<FileInfo?>(
            name: "--file",
            description: "The app's setting json file to configure app settings.");

        var rootCommand = new RootCommand("CI Pipeline Console App Reporting Tool.");
        rootCommand.AddOption(generateReportOption);
        rootCommand.AddOption(appjsonfile);

        rootCommand.SetHandler((htmlreport, file) => 
        { 
            GenerateHTMLReport(htmlreport);
            FileHandling.ReadFile(file!); 
        },
        generateReportOption,
        appjsonfile);   

        var parser = new CommandLineBuilder(rootCommand)
        .UseDefaults()
        .UseHelp(ctx =>
        {
            ctx.HelpBuilder.CustomizeLayout(
                _ =>
                    HelpBuilder.Default
                        .GetLayout()
                        .Skip(1) // Skip the default command description section.
                        .Prepend(
                            _ => Spectre.Console.AnsiConsole.Write(
                                new FigletText(rootCommand.Description!))
                ));
        })
        .Build();
        return await parser.InvokeAsync(args);

        //return await rootCommand.InvokeAsync(args);
    }

    static void GenerateHTMLReport(string htmlreport)
    {
        if (htmlreport.ToLower() == "true")
        {
            Console.WriteLine("Call the Generate HTML Pipeline Report");
        }
    }
    
}