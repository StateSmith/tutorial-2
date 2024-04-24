#!/usr/bin/env dotnet-script
#r "nuget: StateSmith, 0.9.10-alpha"

using StateSmith.Common;
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
    // We declare `t1_start_ms` in regular `VariableDeclarations` so that we can reference the user expansion for it
    // in other expansions. We couldn't do that if we used `AutoExpandedVars`.
    string IRenderConfig.VariableDeclarations => @"
        t1StartMs: 0, // tracks when timer was started
    ";

    // This nested class creates expansions because it is inside your render config class.
    public class MyExpansions : UserExpansionScriptBase
    {
        #pragma warning disable IDE1006, IDE0051, CA1050  // ignore C# guidelines for stuff below

        string show(string message) => $"""appendToOutput({message} + "\n")""";

        // This is an example of an event based timeout.
        // It sets up a JavaScript timeout which will dispatch the TIMEOUT event
        // to the state machine. Something similar can be done in other languages/frameworks.
        string setTimeout(string timeStr) => $"startSmTimeout({TimeStrToMs(timeStr)})";

        // The following expansions are useful for state machines that are polled to check for
        // timeout events. This style can be used anywhere as long as there is a way to get the current time.
        string nowMs => $"Date.now()";
        string t1StartMs => AutoVarName();
        string t1Restart() => $"{t1StartMs} = {nowMs}";
        string t1ElapsedMs => $"{nowMs} - {t1StartMs}";
        string t1After(string timeStr) => $"{t1ElapsedMs} >= {TimeStrToMs(timeStr)}";
    }

    // this method takes a string like "1.2s" and converts it to `1200` for milliseconds.
    public static string TimeStrToMs(string timeStr)
    {
        return TimeStringParser.ElapsedTimeStringToMs(timeStr).ToString();
    }
}
