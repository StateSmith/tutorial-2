#!/usr/bin/env dotnet-script
#r "nuget: StateSmith, 0.9.2-alpha"

using StateSmith.Output.UserConfig;
using StateSmith.Runner;

SmRunner runner = new(diagramPath: "LightSm.drawio.svg", new LightSmRenderConfig(), transpilerId: TranspilerId.JavaScript);
runner.Run();

///////////////////////////////////////////////////////////////////////////////////////

// This class gives StateSmith the info it needs to generate working code. This class can have any name.
public class LightSmRenderConfig : IRenderConfig
{
    // `FileTop` text will appear at the top of the generated file(s). Use for comments, copyright notices, code...
    string IRenderConfig.FileTop => """
        // Copyright: turtles, turtles, turtles...
        // You can include other files/modules specific to your programming language here
        let x = 55; // You can even output raw code...
        """;

    // the variables section is useful for inputs, outputs, and internal variables.
    string IRenderConfig.VariableDeclarations => """
        count: 0,            // a state machine variable
        switch_state: false, // an input to state machine
        light_state: false,  // an output from state machine
        """;
}

// if you want, you can setup vscode to debug .csx files and provide intellisense.
// See https://github.com/StateSmith/StateSmith/wiki/Using-c%23-script-files-(.CSX)-instead-of-solutions-and-projects
