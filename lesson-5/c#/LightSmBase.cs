using System;

namespace LightController;

// user code extended by generated state machine. Nicer than expansions in most cases.
public class LightSmBase
{
    public void LightBlue() => Console.WriteLine("BLUE");
    public void LightYellow() => Console.WriteLine("YELL-OW!");
    public void LightRed() => Console.WriteLine("RED");

    protected int count;
}
