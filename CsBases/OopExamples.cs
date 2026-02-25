namespace CsBases.Examples
{
    /// <summary>
    /// Demonstrates C# Object-Oriented Programming (OOP) Fundamentals
    /// Covers classes, inheritance, polymorphism, encapsulation, and interfaces
    /// </summary>
    public class OopExamples
    {
        // =====================================================================
        // 1. CLASSES & OBJECTS - Basic Building Blocks
        // =====================================================================

        /// <summary>
        /// A class is a blueprint for creating objects (instances)
        /// </summary>
        public class Animal
        {
            // Fields (data)
            private string? name;           // Private: only accessible within this class

            // Properties with backing fields
            public string? Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Age { get; set; }  // Auto-property (C# shorthand)

            // Constructor - called when creating a new object
            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }

            // Method
            public virtual void Speak()
            {
                Console.WriteLine($"{Name} makes a sound");
            }

            public override string ToString() => $"{Name} (Age: {Age})";
        }

        public void ClassesAndObjectsExample()
        {
            // Creating an object (instance) from the Animal class
            Animal animal = new Animal("Generic", 5);
            animal.Speak();
            Console.WriteLine(animal.ToString());
        }

        // =====================================================================
        // 2. INHERITANCE - Code Reuse & Specialization
        // =====================================================================

        /// <summary>
        /// Inheritance allows a class to inherit members from another class
        /// Dog inherits from Animal - "IS-A" relationship
        /// </summary>
        public class Dog : Animal
        {
            public string Breed { get; set; }

            // Constructor: using 'base' to call parent constructor
            public Dog(string name, int age, string breed) : base(name, age)
            {
                Breed = breed;
            }

            // Override: replaces parent implementation
            public override void Speak()
            {
                Console.WriteLine($"{Name} barks: Woof! Woof!");
            }

            public void Fetch()
            {
                Console.WriteLine($"{Name} fetches the ball!");
            }
        }

        /// <summary>
        /// Another class inheriting from Animal
        /// </summary>
        public class Cat : Animal
        {
            public bool IsIndoor { get; set; }

            public Cat(string name, int age, bool isIndoor) : base(name, age)
            {
                IsIndoor = isIndoor;
            }

            public override void Speak()
            {
                Console.WriteLine($"{Name} meows: Meow! Meow!");
            }
        }

        public void InheritanceExample()
        {
            Dog dog = new Dog("Buddy", 3, "Golden Retriever");
            dog.Speak();      // Outputs: Buddy barks: Woof! Woof!
            dog.Fetch();      // Outputs: Buddy fetches the ball!

            Cat cat = new Cat("Whiskers", 2, true);
            cat.Speak();      // Outputs: Whiskers meows: Meow! Meow!

            // Parent class can hold references to child objects
            Animal genericAnimal = dog;  // Dog IS-A Animal
            genericAnimal.Speak();       // Still calls Dog's Speak (polymorphism!)
        }

        // =====================================================================
        // 3. POLYMORPHISM - Many Forms
        // =====================================================================

        /// <summary>
        /// Polymorphism: Same method, different behavior in different classes
        /// Method Overriding (runtime polymorphism)
        /// </summary>
        public void PolymorphismExample()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog("Buddy", 3, "Golden Retriever"),
                new Cat("Whiskers", 2, true),
                new Animal("Generic", 5)
            };

            // Each animal speaks in its own way (polymorphic behavior)
            foreach (var animal in animals)
            {
                animal.Speak();  // Calls the appropriate override
            }
        }

        /// <summary>
        /// Method Overloading: Same method name, different parameters
        /// Resolved at compile-time
        /// </summary>
        public class Calculator
        {
            // Overload 1: Add two integers
            public int Add(int a, int b)
            {
                return a + b;
            }

            // Overload 2: Add three integers
            public int Add(int a, int b, int c)
            {
                return a + b + c;
            }

            // Overload 3: Add two doubles
            public double Add(double a, double b)
            {
                return a + b;
            }
        }

        public void MethodOverloadingExample()
        {
            Calculator calc = new Calculator();
            Console.WriteLine($"2 + 3 = {calc.Add(2, 3)}");           // int overload
            Console.WriteLine($"2 + 3 + 4 = {calc.Add(2, 3, 4)}");   // int overload (3 params)
            Console.WriteLine($"2.5 + 3.5 = {calc.Add(2.5, 3.5)}");  // double overload
        }

        /// <summary>
        /// Operator Overloading: Define custom behavior for operators
        /// </summary>
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y) => (X, Y) = (x, y);

            // Overload the + operator
            public static Point operator +(Point a, Point b)
            {
                return new Point(a.X + b.X, a.Y + b.Y);
            }

            // Overload the == operator
            public static bool operator ==(Point a, Point b)
            {
                return a.X == b.X && a.Y == b.Y;
            }

            public static bool operator !=(Point a, Point b)
            {
                return !(a == b);
            }

            public override bool Equals(object? obj) => obj is Point p && this == p;
            public override int GetHashCode() => HashCode.Combine(X, Y);
            public override string ToString() => $"({X}, {Y})";
        }

        public void OperatorOverloadingExample()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(3, 4);
            Point p3 = p1 + p2;  // Uses overloaded + operator

            Console.WriteLine($"{p1} + {p2} = {p3}");
            Console.WriteLine($"{p1} == {p2}: {p1 == p2}");
        }

        // =====================================================================
        // 4. ENCAPSULATION - Data Hiding & Access Control
        // =====================================================================

        /// <summary>
        /// Access Modifiers control visibility:
        /// public    - Accessible everywhere
        /// private   - Accessible only within this class
        /// protected - Accessible within this class and derived classes
        /// internal  - Accessible within the same assembly
        /// </summary>
        public class BankAccount
        {
            // private: only accessible from within BankAccount
            private decimal balance = 0;

            // public: accessible from anywhere
            public string AccountNumber { get; }

            // protected: accessible from derived classes
            protected string AccountOwner { get; set; }

            public BankAccount(string accountNumber, string owner)
            {
                AccountNumber = accountNumber;
                AccountOwner = owner;
            }

            // public method - controls how balance is modified
            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    Console.WriteLine($"Deposited: ${amount}. New balance: ${balance}");
                }
                else
                {
                    Console.WriteLine("Deposit amount must be positive!");
                }
            }

            public void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawn: ${amount}. New balance: ${balance}");
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount!");
                }
            }

            public decimal GetBalance() => balance;
        }

        public void EncapsulationExample()
        {
            BankAccount account = new BankAccount("1234567890", "John Doe");
            account.Deposit(1000);      // Valid
            account.Withdraw(100);      // Valid
            account.Withdraw(2000);     // Invalid: insufficient funds
            // account.balance = -500;   // COMPILE ERROR: private field not accessible
        }

        // =====================================================================
        // 5. INTERFACES - Contracts & Abstraction
        // =====================================================================

        /// <summary>
        /// Interface: Defines a contract (method signatures) without implementation
        /// All methods are abstract (must be implemented by derived classes)
        /// </summary>
        public interface IVehicle
        {
            string Model { get; }
            void Start();
            void Stop();
            void Drive();
        }

        /// <summary>
        /// Another interface
        /// </summary>
        public interface IElectric
        {
            int BatteryPercentage { get; }
            void Charge();
        }

        /// <summary>
        /// Class implementing one interface
        /// </summary>
        public class Car : IVehicle
        {
            public string Model { get; set; }

            public Car(string model) => Model = model;

            public void Start() => Console.WriteLine($"{Model} engine started");
            public void Stop() => Console.WriteLine($"{Model} engine stopped");
            public void Drive() => Console.WriteLine($"{Model} is driving on the road");
        }

        /// <summary>
        /// Class implementing multiple interfaces
        /// </summary>
        public class ElectricCar : IVehicle, IElectric
        {
            public string Model { get; set; }
            public int BatteryPercentage { get; set; }

            public ElectricCar(string model) => Model = model;

            public void Start() => Console.WriteLine($"{Model} electric motors activated");
            public void Stop() => Console.WriteLine($"{Model} powered down");
            public void Drive() => Console.WriteLine($"{Model} is driving silently");
            public void Charge()
            {
                BatteryPercentage = 100;
                Console.WriteLine($"{Model} fully charged!");
            }
        }

        public void InterfaceExample()
        {
            // Using interface type for polymorphism
            IVehicle car = new Car("Toyota");
            car.Start();
            car.Drive();
            car.Stop();

            IVehicle tesla = new ElectricCar("Tesla");
            tesla.Start();
            tesla.Drive();
            tesla.Stop();

            // Using multiple interfaces
            ElectricCar electricCar = new ElectricCar("Tesla Model 3");
            electricCar.Charge();
        }

        // =====================================================================
        // 6. ABSTRACT CLASSES - Partial Implementation + Template
        // =====================================================================

        /// <summary>
        /// Abstract class: Can have abstract methods AND concrete methods
        /// Cannot be instantiated directly
        /// </summary>
        public abstract class Shape
        {
            public string? Color { get; set; }

            // Concrete method: implemented in abstract class
            public void PrintColor()
            {
                Console.WriteLine($"Color: {Color}");
            }

            // Abstract method: must be implemented by derived classes
            public abstract double CalculateArea();
            public abstract void Draw();
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius, string color)
            {
                Radius = radius;
                Color = color;
            }

            public override double CalculateArea() => Math.PI * Radius * Radius;
            public override void Draw() => Console.WriteLine($"Drawing a {Color} circle");
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height, string color)
            {
                Width = width;
                Height = height;
                Color = color;
            }

            public override double CalculateArea() => Width * Height;
            public override void Draw() => Console.WriteLine($"Drawing a {Color} rectangle");
        }

        public void AbstractClassExample()
        {
            // Shape shape = new Shape();  // COMPILE ERROR: cannot instantiate abstract class

            Circle circle = new Circle(5, "Red");
            circle.Draw();
            circle.PrintColor();  // Inherited concrete method
            Console.WriteLine($"Area: {circle.CalculateArea():F2}");

            Rectangle rect = new Rectangle(10, 5, "Blue");
            rect.Draw();
            Console.WriteLine($"Area: {rect.CalculateArea():F2}");
        }

        // =====================================================================
        // 7. VIRTUAL vs ABSTRACT vs SEALED
        // =====================================================================

        /// <summary>
        /// VIRTUAL: Base class provides default implementation, can be overridden
        /// </summary>
        public class Vehicle
        {
            public virtual void Start()
            {
                Console.WriteLine("Vehicle starting...");
            }

            // sealed method: cannot be overridden in derived classes
            public sealed override string ToString()
            {
                return base.ToString();
            }
        }

        /// <summary>
        /// SEALED CLASS: Cannot be inherited
        /// </summary>
        public sealed class ImmutableData
        {
            public string Data { get; }
            public ImmutableData(string data) => Data = data;
            // No class can inherit from ImmutableData
        }

        public class Truck : Vehicle
        {
            public override void Start()
            {
                Console.WriteLine("Truck engine rumbles to life");
            }
        }

        public void VirtualAbstractSealedExample()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Start();

            Truck truck = new Truck();
            truck.Start();  // Calls overridden version

            // ImmutableData immutable = new ImmutableData("test");
            // class DerivedData : ImmutableData { }  // COMPILE ERROR: sealed class
        }

        // =====================================================================
        // 8. CONSTRUCTOR CHAINING - BASE & THIS
        // =====================================================================

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            // Constructor 1: Minimal
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = 0;
            }

            // Constructor 2: Chains to Constructor 1 using 'this'
            public Person(string firstName, string lastName, int age)
                : this(firstName, lastName)  // Calls Constructor 1
            {
                Age = age;
            }
        }

        public class Employee : Person
        {
            public string EmployeeId { get; set; }

            // Chains to parent constructor using 'base'
            public Employee(string firstName, string lastName, int age, string employeeId)
                : base(firstName, lastName, age)  // Calls parent constructor
            {
                EmployeeId = employeeId;
            }
        }

        public void ConstructorChainingExample()
        {
            Person person = new Person("John", "Doe", 30);
            Console.WriteLine($"Person: {person.FirstName} {person.LastName}, Age: {person.Age}");

            Employee employee = new Employee("Jane", "Smith", 28, "EMP001");
            Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName}, ID: {employee.EmployeeId}");
        }

        // =====================================================================
        // 9. PARTIAL CLASSES - Split class definition across files
        // =====================================================================

        /// <summary>
        /// Partial class (first part): Allows splitting a class definition
        /// In real projects, you'd split this across multiple files
        /// </summary>
        public partial class Configuration
        {
            public string? ApplicationName { get; set; }
            public string? Version { get; set; }
        }

        // This would typically be in another file: Configuration.Display.cs
        public partial class Configuration
        {
            public void Display()
            {
                Console.WriteLine($"App: {ApplicationName} v{Version}");
            }
        }

        public void PartialClassExample()
        {
            Configuration config = new Configuration
            {
                ApplicationName = "MyApp",
                Version = "1.0"
            };
            config.Display();
        }

        // =====================================================================
        // RUNNING ALL EXAMPLES
        // =====================================================================

        public void RunAllExamples()
        {
            Console.WriteLine("=== CLASSES & OBJECTS ===");
            ClassesAndObjectsExample();

            Console.WriteLine("\n=== INHERITANCE ===");
            InheritanceExample();

            Console.WriteLine("\n=== POLYMORPHISM (Method Overriding) ===");
            PolymorphismExample();

            Console.WriteLine("\n=== METHOD OVERLOADING ===");
            MethodOverloadingExample();

            Console.WriteLine("\n=== OPERATOR OVERLOADING ===");
            OperatorOverloadingExample();

            Console.WriteLine("\n=== ENCAPSULATION ===");
            EncapsulationExample();

            Console.WriteLine("\n=== INTERFACES ===");
            InterfaceExample();

            Console.WriteLine("\n=== ABSTRACT CLASSES ===");
            AbstractClassExample();

            Console.WriteLine("\n=== VIRTUAL vs SEALED ===");
            VirtualAbstractSealedExample();

            Console.WriteLine("\n=== CONSTRUCTOR CHAINING ===");
            ConstructorChainingExample();

            Console.WriteLine("\n=== PARTIAL CLASSES ===");
            PartialClassExample();
        }
    }
}
