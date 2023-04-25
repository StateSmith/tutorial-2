# C# - Welcome!
Full disclosure, I'm an embedded C developer that really enjoys C#. I think the C# language has a ton to offer and absolutely love the open source Roslyn compiler. That's why I wrote StateSmith in C#.

If you like StateSmith and want to help improve it, your help would be very much appreciated! StateSmith is a pretty decent tool right now, but it is going to take a team larger than 1 to elevate it to the next level.

https://github.com/StateSmith/StateSmith/wiki/Contributing

# Assumptions ✅
This lesson assumes you've covered the previous ones.

# Run The Code Gen
```
dotnet-script LightSm.csx
```

Or actually just build the `LightController` project normally from the command line or Visual Studio. While not required, the [LightController.csproj](./LightController.csproj) has been modified to automatically run the StateSmith code generation before building the regular project. Feel free to remove. Probably nice for small projects, but bad for large ones as it uses `DisableFastUpToDateCheck`.

```
> dotnet build
MSBuild version 17.4.1+9a89d02ff for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  
  StateSmith Runner - Compiling file: `LightSm.drawio.svg` (no state machine name specified).
  StateSmith Runner - State machine `LightSm` selected.
  StateSmith Runner - Writing to file `LightSm.cs`
  StateSmith Runner - Finished normally.
  ...
```

# Run The Example Project
Use `dotnet run` or GUI. Note that it runs the code gen first so there's a bit of a delay.

# See .csx File
See [LightSm.csx](./LightSm.csx).

Discord or github if you have any problems or questions.

Thanks! - Adam

# Want a more complicated example?
See https://github.com/StateSmith/StateSmith-examples
