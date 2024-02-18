#!/usr/bin/env dotnet-script
// This is a c# script file. It can have any name, but should end with .csx

#r "nuget: StateSmith, 0.9.9-alpha" // this line specifies which version of StateSmith to use and download from c# nuget web service.

using StateSmith.Runner;
SmRunner runner = new(diagramPath: "LightSm.drawio.svg", transpilerId: TranspilerId.JavaScript);
runner.Run();

// You can generate code for multiple state machines in a single `.csx` file if you want. Just make a new `SmRunner` for each one.

// If you want, you can setup vscode to debug .csx files and provide intellisense.
// See https://github.com/StateSmith/StateSmith/wiki/Using-c%23-script-files-(.CSX)-instead-of-solutions-and-projects
