namespace CsBases.Examples
{
    /// <summary>
    /// Demonstrates C# Language Fundamentals: Core Syntax & Data Types
    /// Covers value types, reference types, type inference, nullable types, and memory management
    /// </summary>
    public class CoreSyntaxExamples
    {
        // =====================================================
        // 1. VALUE TYPES vs REFERENCE TYPES
        // =====================================================

        /// <summary>
        /// Value Types: Stored on the STACK
        /// Includes: int, double, decimal, bool, struct, enum
        /// </summary>
        public void ValueTypesExample()
        {
            // Primitive value types
            int age = 25;                    // Integer (4 bytes)
            double temperature = 98.6;      // Floating-point (8 bytes)
            decimal price = 19.99m;         // Precise decimal (16 bytes)
            bool isActive = true;           // Boolean

            // When you assign a value type, it COPIES the value
            int x = 10;
            int y = x;           // y gets a copy of x's value
            y = 20;              // Changing y doesn't affect x
            Console.WriteLine($"x = {x}, y = {y}");  // Output: x = 10, y = 20

            // Struct example (also a value type)
            Point point1 = new Point { X = 5, Y = 10 };
            Point point2 = point1;  // Copy of the struct
            point2.X = 100;         // Doesn't affect point1
        }

        /// <summary>
        /// Reference Types: Stored on the HEAP
        /// Includes: class, string, array, interface, delegate
        /// </summary>
        public void ReferenceTypesExample()
        {
            // Classes are reference types
            Person person1 = new Person { Name = "Alice", Age = 30 };
            Person person2 = person1;      // Both point to the SAME object

            person2.Name = "Bob";          // Changes the shared object
            Console.WriteLine(person1.Name);  // Output: Bob (same reference!)

            // Strings are reference types, but they are IMMUTABLE
            string str1 = "Hello";
            string str2 = str1;
            str2 = str2 + " World";        // Creates a NEW string, doesn't modify str1
            Console.WriteLine(str1);       // Output: Hello (unchanged)

            // Array example (reference type)
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = arr1;             // Both reference the same array
            arr2[0] = 100;                 // Modifies the shared array
            Console.WriteLine(arr1[0]);    // Output: 100
        }

        // =====================================================
        // 2. NULLABLE TYPES & NULL-COALESCING OPERATOR
        // =====================================================

        /// <summary>
        /// Nullable Types: Allow value types to be null
        /// Syntax: TypeName? (e.g., int?, double?, bool?)
        /// </summary>
        public void NullableTypesExample()
        {
            // Without nullable: int cannot be null
            int regularInt = 0;  // Must have a value

            // With nullable: int? can be null
            int? nullableInt = null;     // Valid!
            int? age = 25;

            // Check if nullable type has a value
            if (nullableInt.HasValue)
            {
                int value = nullableInt.Value;  // Get the value
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Value is null");
            }

            // Shorter syntax: null-coalescing operator (??)
            // Returns the left value if it's not null, otherwise the right value
            int? maybeAge = null;
            int defaultAge = 18;
            int result = maybeAge ?? defaultAge;  // result = 18
            Console.WriteLine($"Age: {result}");

            // Chaining null-coalescing
            int? value1 = null;
            int? value2 = null;
            int? value3 = 42;
            int finalValue = value1 ?? value2 ?? value3 ?? 0;  // finalValue = 42

            // Null-coalescing assignment operator (??=) - C# 8.0+
            string? userInput = null;
            userInput ??= "default value";  // Assigns only if null
            Console.WriteLine(userInput);   // Output: default value
        }

        // =====================================================
        // 3. TYPE INFERENCE: VAR & DYNAMIC
        // =====================================================

        /// <summary>
        /// VAR: Implicitly typed local variable
        /// Type is determined at COMPILE TIME (type-safe)
        /// </summary>
        public void VarExample()
        {
            // Type is inferred from the assignment
            var name = "John";              // Inferred as string
            var count = 42;                 // Inferred as int
            var price = 19.99;              // Inferred as double
            var items = new List<int>();   // Inferred as List<int>

            // var is resolved at compile-time, so it's still type-safe
            // This would cause a COMPILE ERROR:
            // var result = name + count;  // Can't add string + int
            // count = "text";             // Type error - count is int

            // Best practice: Use var when the type is obvious from context
            var numbers = new[] { 1, 2, 3, 4, 5 };  // Type is int[]
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// DYNAMIC: Runtime type resolution
        /// Type is determined at RUNTIME (less type-safe)
        /// Use sparingly - sacrifices type safety
        /// </summary>
        public void DynamicExample()
        {
            // dynamic can hold any type, determined at runtime
            dynamic dynamicValue = "Hello";
            dynamicValue = 42;              // Valid - type changes at runtime
            dynamicValue = 3.14;            // Valid

            // This compiles but may fail at runtime:
            dynamic obj = "text";
            // obj.NonExistentMethod();     // No compile error, but RUNTIME ERROR!

            // Dynamic is useful for:
            // 1. COM interop
            // 2. Reflection-based code
            // 3. Working with dynamic languages (e.g., JavaScript in Node.js)

            // Compare var vs dynamic:
            var varString = "Hello";       // Compile-time: type is string
            // varString = 42;              // COMPILE ERROR

            dynamic dynamicString = "Hello";  // Runtime: can be anything
            dynamicString = 42;                // No compile error (but risky!)
        }

        // =====================================================
        // 4. DECIMAL vs DOUBLE
        // =====================================================

        /// <summary>
        /// DOUBLE: 64-bit floating-point (IEEE 754)
        /// Use for: Scientific calculations, performance-critical code
        /// Precision: ~15-17 decimal digits
        /// Range: ±1.7e±308
        /// </summary>
        public void DoubleExample()
        {
            double pi = 3.141592653589793;
            double largeNumber = 1.5e+100;
            double smallNumber = 1.5e-100;

            // Careful with floating-point precision!
            double a = 0.1 + 0.2;
            double b = 0.3;
            Console.WriteLine($"0.1 + 0.2 = {a}");      // 0.30000000000000004
            Console.WriteLine($"Equals 0.3? {a == b}"); // False!

            // Best for: Physics, graphics, statistics
        }

        /// <summary>
        /// DECIMAL: 128-bit fixed-point (base 10)
        /// Use for: Financial calculations, money, precise decimals
        /// Precision: 28-29 significant digits
        /// Range: ±7.9e+28
        /// Syntax: Use 'm' suffix (e.g., 19.99m)
        /// </summary>
        public void DecimalExample()
        {
            decimal price = 19.99m;
            decimal tax = 0.08m;
            decimal total = price * (1 + tax);

            // Decimal is exact for base-10 numbers
            decimal a = 0.1m + 0.2m;
            decimal b = 0.3m;
            Console.WriteLine($"0.1m + 0.2m = {a}");      // 0.3
            Console.WriteLine($"Equals 0.3m? {a == b}");  // True!

            // Financial calculation example
            decimal accountBalance = 1000.00m;
            decimal interestRate = 0.025m;  // 2.5%
            decimal interest = accountBalance * interestRate;
            Console.WriteLine($"Interest earned: ${interest}");  // Exact

            // Best for: Banking, accounting, any money calculations
        }

        // =====================================================================
        // 5. STACK vs HEAP MEMORY (Visual Understanding)
        // =====================================================================

        /// <summary>
        /// Memory allocation patterns for value types (Stack) and reference types (Heap)
        /// </summary>
        public void StackVsHeapExample()
        {
            // VALUE TYPE (Stack allocation)
            int age = 30;           // Stored on stack: [30]

            // REFERENCE TYPE (Heap allocation)
            Person person = new Person { Name = "Charlie", Age = 30 };
            // Stack: [reference address]
            // Heap: [Name="Charlie", Age=30]

            // When passed as parameter:
            int ageParameter = age;
            // Stack receives a COPY: [30] (separate from original)

            ModifyPerson(person);   // Heap object is modified
            // The reference itself is copied, but both references point to same object

            Console.WriteLine($"Person name after method call: {person.Name}");
        }

        private void ModifyPerson(Person p)
        {
            p.Name = "David";       // Modifies the HEAP object
        }

        // =====================================================================
        // 6. KEYWORDS: const, readonly, var
        // =====================================================================

        // const: Compile-time constant (must be initialized, can't change)
        public const int MaxAttempts = 3;

        // readonly: Runtime constant (must be initialized in constructor, can't change)
        public readonly string ApplicationVersion = "1.0.0";

        public void ConstVsReadonlyExample()
        {
            // const - must be known at compile-time
            const int maxItems = 100;
            // maxItems = 200;  // COMPILE ERROR

            // readonly - can use runtime values
            // For instance fields, initialized in constructor or at declaration
            // See the ApplicationVersion field above

            // Local constants
            const decimal taxRate = 0.08m;

            // var - implicit typing
            var localVar = "Can infer type";
            // localVar = 42;  // COMPILE ERROR - still a string
        }

        // =====================================================================
        // 7. STRUCTS: Value Type Example
        // =====================================================================

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString() => $"({X}, {Y})";
        }

        // =====================================================================
        // 8. REFERENCE CLASS EXAMPLE
        // =====================================================================

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        // =====================================================================
        // RUNNING ALL EXAMPLES
        // =====================================================================

        public void RunAllExamples()
        {
            Console.WriteLine("=== VALUE TYPES vs REFERENCE TYPES ===");
            ValueTypesExample();
            Console.WriteLine();
            ReferenceTypesExample();

            Console.WriteLine("\n=== NULLABLE TYPES & NULL-COALESCING ===");
            NullableTypesExample();

            Console.WriteLine("\n=== TYPE INFERENCE: VAR ===");
            VarExample();

            Console.WriteLine("\n=== TYPE INFERENCE: DYNAMIC ===");
            DynamicExample();

            Console.WriteLine("\n=== DECIMAL vs DOUBLE ===");
            Console.WriteLine("--- DOUBLE Example ---");
            DoubleExample();
            Console.WriteLine("\n--- DECIMAL Example ---");
            DecimalExample();

            Console.WriteLine("\n=== STACK vs HEAP ===");
            StackVsHeapExample();

            Console.WriteLine("\n=== const vs readonly vs var ===");
            ConstVsReadonlyExample();
        }
    }
}
