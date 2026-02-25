using CsBases.Examples;

// Entry point for C# Learning Examples
Console.WriteLine("╔════════════════════════════════════════════════╗");
Console.WriteLine("║   C# LANGUAGE FUNDAMENTALS & OOP EXAMPLES     ║");
Console.WriteLine("╚════════════════════════════════════════════════╝\n");

Console.WriteLine("Select which examples to run:");
Console.WriteLine("1. Core Syntax & Data Types");
Console.WriteLine("2. Object-Oriented Programming (OOP)");
Console.WriteLine("3. Run All Examples");
Console.Write("\nEnter your choice (1-3): ");

string choice = Console.ReadLine() ?? "3";

switch (choice)
{
    case "1":
        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   CORE SYNTAX & DATA TYPES");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var coreSyntax = new CoreSyntaxExamples();
        coreSyntax.RunAllExamples();
        break;

    case "2":
        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   OBJECT-ORIENTED PROGRAMMING (OOP)");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var oop = new OopExamples();
        oop.RunAllExamples();
        break;

    case "3":
        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   CORE SYNTAX & DATA TYPES");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var coreSyntaxAll = new CoreSyntaxExamples();
        coreSyntaxAll.RunAllExamples();

        Console.WriteLine("\n\n═══════════════════════════════════════════════");
        Console.WriteLine("   OBJECT-ORIENTED PROGRAMMING (OOP)");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var oopAll = new OopExamples();
        oopAll.RunAllExamples();
        break;

    default:
        Console.WriteLine("Invalid choice. Running all examples...");
        var defaultCoreSyntax = new CoreSyntaxExamples();
        defaultCoreSyntax.RunAllExamples();
        var defaultOop = new OopExamples();
        defaultOop.RunAllExamples();
        break;
}