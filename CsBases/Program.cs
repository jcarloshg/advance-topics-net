using CsBases.Examples;

// Entry point for C# Learning Examples
await Main();

async Task Main()
{
    Console.WriteLine("╔════════════════════════════════════════════════════╗");
    Console.WriteLine("║   C# LANGUAGE FUNDAMENTALS EXAMPLES                ║");
    Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

    Console.WriteLine("Select which examples to run:");
    Console.WriteLine("1. Core Syntax & Data Types");
    Console.WriteLine("2. Object-Oriented Programming (OOP)");
    Console.WriteLine("3. Async/Await & Threading");
    Console.WriteLine("4. Memory & Resource Management");
    Console.WriteLine("5. Run All Examples");
    Console.Write("\nEnter your choice (1-5): ");

    string choice = Console.ReadLine() ?? "5";

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
        Console.WriteLine("   ASYNC/AWAIT & THREADING");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var asyncAwait = new AsyncAwaitExamples();
        await asyncAwait.RunAllExamplesAsync();
        break;

    case "4":
        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   MEMORY & RESOURCE MANAGEMENT");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var memory = new MemoryResourceManagementExamples();
        await memory.RunAllExamplesAsync();
        break;

    case "5":
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

        Console.WriteLine("\n\n═══════════════════════════════════════════════");
        Console.WriteLine("   ASYNC/AWAIT & THREADING");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var asyncAwaitAll = new AsyncAwaitExamples();
        await asyncAwaitAll.RunAllExamplesAsync();

        Console.WriteLine("\n\n═══════════════════════════════════════════════");
        Console.WriteLine("   MEMORY & RESOURCE MANAGEMENT");
        Console.WriteLine("═══════════════════════════════════════════════\n");
        var memoryAll = new MemoryResourceManagementExamples();
        await memoryAll.RunAllExamplesAsync();
        break;

    default:
        Console.WriteLine("Invalid choice. Running all examples...");
        var defaultCoreSyntax = new CoreSyntaxExamples();
        defaultCoreSyntax.RunAllExamples();
        var defaultOop = new OopExamples();
        defaultOop.RunAllExamples();
        var defaultAsyncAwait = new AsyncAwaitExamples();
        await defaultAsyncAwait.RunAllExamplesAsync();
        var defaultMemory = new MemoryResourceManagementExamples();
        await defaultMemory.RunAllExamplesAsync();
        break;
}
}