#!/usr/bin/env dotnet-script
// This is a c# script file

#r "nuget: StateSmith, 0.9.3-alpha" // this line specifies which version of StateSmith to use and download from c# nuget web service.

using StateSmith.Input.Expansions;
using StateSmith.Output.Gil.C99;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;
using StateSmith.SmGraph;

SmRunner runner = new(diagramPath: "LightSm.drawio.svg", new LightSmRenderConfig(), transpilerId: TranspilerId.C99);
runner.Run();

// You can build multiple state machines in this script file. Just create a new SmRunner for each one.


// ------------

// ignore C# guidelines for script stuff below
#pragma warning disable IDE1006, CA1050 

// This class gives StateSmith the info it needs to generate working C code.
// It adds user code to the generated .c/.h files, declares user variables,
// and provides diagram code expansions. This class can have any name.
public class LightSmRenderConfig : IRenderConfigC
{
    // NOTE!!! Idiomatic C++ code generation is coming. This will improve.
    // See https://github.com/StateSmith/StateSmith/issues/126
    string IRenderConfigC.CFileExtension => ".cpp"; // the generated StateSmith C code is also valid C++ code
    string IRenderConfigC.HFileExtension => ".h";   // could also be .hh, .hpp or whatever you like
    string IRenderConfigC.CEnumDeclarer => "typedef enum __attribute__((packed)) {enumName}";   // save RAM by packing enum type to smallest int type

    string IRenderConfig.AutoExpandedVars => """
        uint8_t count; // variable for state machine
        """;

    string IRenderConfigC.HFileTop => """
        // user IRenderConfigC.HFileTop: whatever you want to put in here.
        """;

    string IRenderConfigC.CFileTop => """
        // user IRenderConfigC.CFileTop: whatever you want to put in here.
        #include <iostream> // user include. required for printf.
        """;

    string IRenderConfigC.HFileIncludes => """
        // user IRenderConfigC.HFileIncludes: whatever you want to put in here.
        """;

    string IRenderConfigC.CFileIncludes => """
        // user IRenderConfigC.CFileIncludes: whatever you want to put in here.
        """;


    // This nested class creates expansions. It can have any name.
    public class MyExpansions : UserExpansionScriptBase
    {
        public string light_blue()   => """std::cout << "BLUE\n";""";
        public string light_yellow() => """std::cout << "YELL-OH\n";""";
        public string light_red()    => """std::cout << "RED\n";""";
    }
}
