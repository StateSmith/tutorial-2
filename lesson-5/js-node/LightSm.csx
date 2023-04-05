#!/usr/bin/env dotnet-script
// This is a c# script file

#r "nuget: StateSmith, 0.8.13-alpha" // this line specifies which version of StateSmith to use and download from c# nuget web service.

using StateSmith.Input.Expansions;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;

SmRunner runner = new(diagramPath: "LightSm.drawio.svg", new LightSmRenderConfig(), transpilerId: TranspilerId.JavaScript);
runner.Run();

// You can code gen multiple state machines in this script file. Just create a new SmRunner for each one.

///////////////////////////////////////////////////////////////////////////////////////

// ignore C# guidelines for script stuff below
#pragma warning disable IDE1006, CA1050 

// This class gives StateSmith the info it needs to generate working code.
public class LightSmRenderConfig : IRenderConfigJavaScript
{
    string IRenderConfig.AutoExpandedVars => """
        count : 0, // variable for state machine
        """;

    string IRenderConfig.FileTop => """
        "use strict";    
        // any text you put in IRenderConfig.FileTop (like this comment) will be written to the generated .h file
        import { LightSmBase } from "./LightSmBase.js";
        """;

    // Base class not needed. Sometimes handy though so showing it here.
    string IRenderConfigJavaScript.ExtendsSuperClass => "LightSmBase";

    // Enable if you want generated state machine class like `export class LightSm...` 
    bool IRenderConfigJavaScript.UseExportOnClass => true;

    // This is used to prefix state machine private members. Use "#" if targeting new js versions.
    // Use "_" if targeting old js.
    string IRenderConfigJavaScript.PrivatePrefix => "#";

    // This nested class creates expansions. This class can have any name.
    public class MyExpansions : UserExpansionScriptBase
    {
        public string lightBlue()   => """console.log("BLUE")""";
        public string lightYellow() => $"""this.{AutoNameCopy()}()"""; // comes out as `this.lightYellow()`. Implemented in base class.
        public string lightRed() => $"""this.{AutoNameCopy()}()"""; // comes out as `this.lightRed()`. Implemented in base class.
    }
}
