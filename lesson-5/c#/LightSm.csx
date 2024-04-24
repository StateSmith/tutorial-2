#!/usr/bin/env dotnet-script
// This is a c# script file

#r "nuget: StateSmith, 0.9.10-alpha" // this line specifies which version of StateSmith to use and download from c# nuget web service.

using StateSmith.Input.Expansions;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;

SmRunner runner = new(diagramPath: "LightSm.drawio.svg", new LightSmRenderConfig(), transpilerId: TranspilerId.CSharp);
runner.Run();

// You can code gen multiple state machines in this script file. Just create a new SmRunner for each one.

/////////////////////////////////////////////////////////////////////////////

// If you want, you can setup vscode to debug .csx files and provide intellisense.
// See https://github.com/StateSmith/StateSmith/wiki/Using-c%23-script-files-(.CSX)-instead-of-solutions-and-projects


// This class gives StateSmith the info it needs to generate working code.
public class LightSmRenderConfig : IRenderConfigCSharp
{
    string IRenderConfig.FileTop => """
        // Whatever you put in the IRenderConfig.FileTop section ends up at the top of the file.
        """;

    // If true, it will output `#nullable enable` near the file top.
    bool IRenderConfigCSharp.UseNullable => true;

    // Usings for your state machine so that it can access other code.
    string IRenderConfigCSharp.Usings => """
        using System; // User `using` specified in `IRenderConfigCSharp.Usings`
        """;

    // Namespace for your generated state machine class.
    // If this ends with a ";" it will use a top level namespace instead of using braces.
    string IRenderConfigCSharp.NameSpace => "LightController;";

    // Makes the generated state machine extend user provided class `LightSmBase`.
    // Not required, but can be handy if you don't want to use expansions.
    string IRenderConfigCSharp.BaseList => "LightSmBase";

    // Instead of extending a base class, you could mark the generated state machine class
    // as a partial class. You could do both if you want.
    bool IRenderConfigCSharp.UsePartialClass => false;

    // You can use regular variables as detailed in previous lessons, but we are going to put
    // the variables in the LightSmBase instead. Allows us to protect variables better too.
    // string IRenderConfig.AutoExpandedVars => """
    //     public int count; // variable for state machine
    //     """;

    // Question?
    // vscode can provide intellisense in this file. Handy for IRenderConfig properties.
    // Does anyone know how to get that intellisense working in regular Visual Studio?

    // This nested class creates expansions. This class can have any name.
    public class MyExpansions : UserExpansionScriptBase
    {
        // No need for these expansions because they are implemented nicer in the user LightSmBase class instead.
        // public string LightBlue()   => """Console.WriteLine("BLUE")""";
        // public string LightYellow() => """Console.WriteLine("YELLOW")""";
        // public string LightRed()    => """Console.WriteLine("RED")""";
    }
}


