﻿using System;

namespace LightController;

public class Program
{
    static void Main()
    {
        LightSm sm = new();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("USAGE:");
        Console.WriteLine("  type i <enter> to send INCREASE event to state machine.");
        Console.WriteLine("  type d <enter> to send DIM event to state machine.");
        Console.WriteLine("  type o <enter> to send OFF event to state machine.");
        Console.WriteLine("");
        Console.WriteLine("Hit <enter> to start");
        Console.ReadLine();
        Console.ResetColor();

        sm.Start();

        while (true)
        {
            ReadInputRunSm(sm);
        }
    }

    private static void ReadInputRunSm(LightSm sm)
    {
        var line = Console.ReadLine();
        char c = '\0';

        if (line.Length > 0)
            c = line[0];

        RunSmForChar(sm, c);
    }

    private static void RunSmForChar(LightSm sm, char c)
    {
        bool validInput = true;
        LightSm.EventId eventId = LightSm.EventId.OFF;

        switch (c)
        {
            case 'i': eventId = LightSm.EventId.INCREASE; break;
            case 'd': eventId = LightSm.EventId.DIM; break;
            case 'o': eventId = LightSm.EventId.OFF; break;
            default: validInput = false; break;
        }

        if (validInput)
        {
            sm.DispatchEvent(eventId);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What you trying to pull!? I ain't not silly AI. Feed me proper input please :)");
            Console.ResetColor();
        }
    }
}
