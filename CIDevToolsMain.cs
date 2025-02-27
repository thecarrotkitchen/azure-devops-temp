using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using Spectre.Console;

namespace CIDevTools;
class CIDevTools
{
    static async Task<int> Main(string[] args)
    {
        var generateReportOption = new Option<bool>(
            name: "--htmlReport",
            description: "Generates an html report of the build's pipeline failures.",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    Console.WriteLine("result.Tokens.Count " + result.Tokens.Count);
                    return true;
                }
                else
                {
                    Console.WriteLine(result.Tokens[0].ToString());
                    return false;
                }
            });
        var appjsonfile = new Option<FileInfo?>(
            name: "--file",
            description: "The app's setting json file to configure app settings.");
        var getAllLatest = new Option<string?>(
            name: "--latestBuilds",
            description: "Print all latest CI Builds") {IsHidden = true };

        var rootCommand = new RootCommand("CI Pipeline Console App Reporting Tool.");
        rootCommand.AddOption(generateReportOption);
        rootCommand.AddOption(appjsonfile);
        rootCommand.AddOption(getAllLatest);

        rootCommand.SetHandler((htmlreport, file, latestBuilds) => 
        { 
            GenerateHTMLReport(htmlreport);
            FileHandling.ReadFile(file);
            GetAllLatestBuilds(latestBuilds);
        },
        generateReportOption,
        appjsonfile,
        getAllLatest);   

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

    static void GetAllLatestBuilds(string latestBuilds)
    {
        if (latestBuilds.ToLower() == "true")
        {
            Console.WriteLine("Call the Get All Latest API!");
        }
    }
    static void GenerateHTMLReport(bool htmlreport)
    {
        //if (htmlreport.ToLower() == "true")
        if (htmlreport)
        {
            Console.WriteLine("Call the Generate HTML Pipeline Report");
        }
    }
    
}