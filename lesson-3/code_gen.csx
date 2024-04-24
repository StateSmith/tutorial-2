#!/usr/bin/env dotnet-script
#r "nuget: StateSmith, 0.9.10-alpha"

using StateSmith.Input.Expansions;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;

SmRunner runner = new(diagramPath: "LightSm.drawio.svg", new LightSmRenderConfig(), transpilerId: TranspilerId.JavaScript);
runner.Run();


//////////////////////////////////////////////////////////////////////////////////////////////////////////

// NOTE!
// If you want, you can setup vscode to debug .csx files and provide intellisense.
// This can be really helpful. You can debug your expansions and code generation.
// See https://github.com/StateSmith/StateSmith/wiki/Using-c%23-script-files-(.CSX)-instead-of-solutions-and-projects

//////////////////////////////////////////////////////////////////////////////////////////////////////////


// This class gives StateSmith the info it needs to generate working code. This class can have any name.
public class LightSmRenderConfig : IRenderConfig
{
    // covered in previous lesson
    string IRenderConfig.FileTop => """
        // Copyright: turtles, turtles, turtles...
        """;

    // This section is parsed according to the target language to automatically create expansions
    // for the variables declared in it. I prefer to use this section over `VariableDeclarations`
    // whenever possible. You can't put nested classes/structs in here.
    string IRenderConfig.AutoExpandedVars => """
        on_count: 0,
        """;

    // This can have nested classes/structs.
    string IRenderConfig.VariableDeclarations => """
        off_count: 0,
        """;

    // This nested class creates expansions because it is inside your render config class.
    // It can have any name.
    public class MyExpansions : UserExpansionScriptBase
    {
        // ignore C# guidelines for naming below
        #pragma warning disable IDE1006, CA1050 

        string show(string message) => $"""window.alert({message})""";
        string off_count => AutoVarName();
        // note that `on_count` doesn't need an expansion here because it is in `AutoExpandedVars`.
    }
}

