using System.Runtime;

namespace CsBases.Examples
{
    /// <summary>
    /// Demonstrates C# Memory Management & Resource Management
    /// Covers garbage collection, IDisposable, finalizers, and disposal patterns
    /// </summary>
    public class MemoryResourceManagementExamples
    {
        // =====================================================================
        // 1. GARBAGE COLLECTOR BASICS
        // =====================================================================

        /// <summary>
        /// Garbage Collector (GC): Automatically manages memory in .NET
        /// Heap is divided into generations for efficiency
        /// </summary>
        public void GarbageCollectorExample()
        {
            Console.WriteLine("=== GC Information ===");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false) / 1024} KB");
            Console.WriteLine($"Is Server GC: {GCSettings.IsServerGC}");
            Console.WriteLine($"GC Latency Mode: {GCSettings.LatencyMode}");

            // Create some objects
            for (int i = 0; i < 1000; i++)
            {
                var obj = new object();  // Allocated to Gen 0
            }

            Console.WriteLine($"\nAfter allocation:");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false) / 1024} KB");

            // Force garbage collection (NOT recommended in production!)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine($"\nAfter GC.Collect():");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(true) / 1024} KB");
        }

        /// <summary>
        /// Generations explained:
        /// Gen 0: Short-lived objects (collected frequently)
        /// Gen 1: Medium-lived objects
        /// Gen 2: Long-lived objects (expensive to collect)
        /// </summary>
        public void GenerationsExample()
        {
            Console.WriteLine("=== Object Generations ===");

            var memBefore = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory before allocation: {memBefore / 1024} KB");

            // Gen 0 objects
            var obj0 = new byte[10240];  // Small allocation in Gen 0
            var memAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"Created Gen 0 object, memory: {memAfter / 1024} KB");

            // Collect Gen 0 and 1
            GC.Collect(0, GCCollectionMode.Optimized);  // Collect Gen 0
            var memAfterGen0 = GC.GetTotalMemory(false);
            Console.WriteLine($"After Gen 0 collection, memory: {memAfterGen0 / 1024} KB");

            // Collect Gen 1 and 2
            GC.Collect(1, GCCollectionMode.Optimized);  // Collect Gen 1
            var memAfterGen1 = GC.GetTotalMemory(false);
            Console.WriteLine($"After Gen 1 collection, memory: {memAfterGen1 / 1024} KB");
        }

        // =====================================================================
        // 2. IDISPOSABLE PATTERN
        // =====================================================================

        /// <summary>
        /// IDisposable: Interface for deterministic cleanup of resources
        /// Implement when holding unmanaged resources (file handles, DB connections, etc.)
        /// </summary>
        public class FileResourceWrapper : IDisposable
        {
            private string _filePath;
            private bool _disposed = false;

            public FileResourceWrapper(string filePath)
            {
                _filePath = filePath;
                Console.WriteLine($"FileResourceWrapper created for: {_filePath}");
            }

            public void WriteData(string data)
            {
                if (_disposed)
                    throw new ObjectDisposedException(nameof(FileResourceWrapper));

                Console.WriteLine($"Writing to file: {data}");
            }

            // Explicit cleanup
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);  // Don't call finalizer
            }

            // Protected virtual Dispose for derived classes
            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                if (disposing)
                {
                    // Cleanup managed resources
                    Console.WriteLine("Disposing managed resources");
                }

                // Cleanup unmanaged resources
                Console.WriteLine("Cleaning up file handle");
                _disposed = true;
            }

            // Finalizer: Last resort cleanup (may never run!)
            ~FileResourceWrapper()
            {
                Console.WriteLine("FileResourceWrapper finalizer called");
                Dispose(false);
            }
        }

        public void IDisposableExample()
        {
            Console.WriteLine("=== IDisposable Pattern ===");

            // Using statement: Ensures Dispose() is called
            using (var resource = new FileResourceWrapper("data.txt"))
            {
                resource.WriteData("Hello World");
            }  // Dispose() called automatically here

            Console.WriteLine("Resource cleaned up");
        }

        // =====================================================================
        // 3. USING STATEMENT & DECLARATION (C# 8+)
        // =====================================================================

        /// <summary>
        /// Using statement (old): Requires braces
        /// </summary>
        public void UsingStatementExample()
        {
            Console.WriteLine("=== Using Statement ===");

            using (var resource = new FileResourceWrapper("data1.txt"))
            {
                resource.WriteData("Data 1");
                resource.WriteData("Data 2");
            }  // Dispose() called here
        }

        /// <summary>
        /// Using declaration (C# 8+): Modern syntax without braces
        /// Dispose is called at end of scope
        /// Cleaner and more readable
        /// </summary>
        public void UsingDeclarationExample()
        {
            Console.WriteLine("=== Using Declaration (C# 8+) ===");

            using var resource = new FileResourceWrapper("data2.txt");
            resource.WriteData("Data");
            // Dispose() called automatically at end of method/scope
        }

        // =====================================================================
        // 4. IDISPOSABLE ASYNC PATTERN
        // =====================================================================

        /// <summary>
        /// IAsyncDisposable: For async cleanup operations
        /// Modern approach for async resource cleanup
        /// </summary>
        public class AsyncDatabaseConnection : IAsyncDisposable
        {
            private bool _disposed = false;

            public AsyncDatabaseConnection()
            {
                Console.WriteLine("Async database connection opened");
            }

            public async Task ExecuteQueryAsync(string query)
            {
                if (_disposed)
                    throw new ObjectDisposedException(nameof(AsyncDatabaseConnection));

                Console.WriteLine($"Executing query: {query}");
                await Task.Delay(100);
            }

            // Async cleanup
            public async ValueTask DisposeAsync()
            {
                if (_disposed)
                    return;

                Console.WriteLine("Starting async cleanup...");
                await Task.Delay(100);  // Simulate async cleanup
                Console.WriteLine("Async cleanup completed");

                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public async Task IAsyncDisposableExample()
        {
            Console.WriteLine("=== IAsyncDisposable Pattern ===");

            // Using statement with async disposal
            await using (var connection = new AsyncDatabaseConnection())
            {
                await connection.ExecuteQueryAsync("SELECT * FROM Users");
            }  // DisposeAsync() called automatically

            Console.WriteLine("Connection cleaned up");
        }

        /// <summary>
        /// Using declaration with async disposal (C# 8+)
        /// </summary>
        public async Task IAsyncDisposableDeclarationExample()
        {
            Console.WriteLine("=== IAsyncDisposable Declaration ===");

            await using var connection = new AsyncDatabaseConnection();
            await connection.ExecuteQueryAsync("SELECT * FROM Orders");
            // DisposeAsync() called at end of scope
        }

        // =====================================================================
        // 5. BOXING & UNBOXING
        // =====================================================================

        /// <summary>
        /// Boxing: Converting value type to reference type (object)
        /// Creates copy on heap, hurts performance
        /// </summary>
        public void BoxingExample()
        {
            Console.WriteLine("=== Boxing ===");

            int value = 42;  // Value type on stack
            object boxed = value;  // Boxing: copy to heap

            Console.WriteLine($"Original value: {value}");
            Console.WriteLine($"Boxed value: {boxed}");
            Console.WriteLine($"Are they equal: {value.Equals(boxed)}");
        }

        /// <summary>
        /// Unboxing: Converting reference type back to value type
        /// Must be exact type match
        /// </summary>
        public void UnboxingExample()
        {
            Console.WriteLine("=== Unboxing ===");

            object boxed = 42;

            // Correct unboxing
            int unboxed = (int)boxed;
            Console.WriteLine($"Unboxed value: {unboxed}");

            // Wrong unboxing throws InvalidCastException
            try
            {
                long wrongUnbox = (long)boxed;  // Throws!
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Boxing costs:
        /// - Heap allocation
        /// - GC pressure
        /// - Performance penalty
        /// Avoid boxing in loops!
        /// </summary>
        public void BoxingPerformanceExample()
        {
            Console.WriteLine("=== Boxing Performance ===");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Without boxing (fast)
            int sum = 0;
            for (int i = 0; i < 100000; i++)
            {
                sum += i;
            }

            watch.Stop();
            Console.WriteLine($"Without boxing: {watch.ElapsedMilliseconds}ms");

            watch.Restart();

            // With boxing (slow)
            object oSum = 0;
            for (int i = 0; i < 100000; i++)
            {
                oSum = (int)oSum + i;  // Box/unbox each iteration
            }

            watch.Stop();
            Console.WriteLine($"With boxing: {watch.ElapsedMilliseconds}ms");
        }

        // =====================================================================
        // 6. WEAK REFERENCES
        // =====================================================================

        /// <summary>
        /// WeakReference: Doesn't prevent garbage collection
        /// Useful for caches where objects can be collected
        /// </summary>
        public class WeakReferenceCache
        {
            private WeakReference<byte[]> _cachedData;

            public void Cache(byte[] data)
            {
                _cachedData = new WeakReference<byte[]>(data);
                Console.WriteLine("Data cached with weak reference");
            }

            public bool TryGetCachedData(out byte[] data)
            {
                data = null;
                if (_cachedData == null)
                    return false;

                return _cachedData.TryGetTarget(out data);
            }
        }

        public void WeakReferenceExample()
        {
            Console.WriteLine("=== Weak Reference ===");

            var cache = new WeakReferenceCache();
            byte[] data = new byte[1024];
            cache.Cache(data);

            // Data is still alive
            if (cache.TryGetCachedData(out var retrieved))
            {
                Console.WriteLine($"Retrieved data: {retrieved.Length} bytes");
            }

            // Allowing GC to collect data
            data = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Data may no longer be available
            if (cache.TryGetCachedData(out var retrieved2))
            {
                Console.WriteLine($"Retrieved data: {retrieved2.Length} bytes");
            }
            else
            {
                Console.WriteLine("Data was collected by GC");
            }
        }

        // =====================================================================
        // 7. FINALIZERS & CHAINS
        // =====================================================================

        /// <summary>
        /// Finalizers: Called by GC, timing unpredictable
        /// Only use for critical cleanup of unmanaged resources
        /// </summary>
        public class FinalizerExample : IDisposable
        {
            private string _name;

            public FinalizerExample(string name)
            {
                _name = name;
                Console.WriteLine($"FinalizerExample created: {_name}");
            }

            // Dispose pattern
            public void Dispose()
            {
                Console.WriteLine($"Dispose called: {_name}");
                GC.SuppressFinalize(this);
            }

            // Finalizer
            ~FinalizerExample()
            {
                Console.WriteLine($"Finalizer called: {_name}");
                // Cleanup unmanaged resources
            }
        }

        public void FinalizerChainsExample()
        {
            Console.WriteLine("=== Finalizer Chains ===");

            {
                var obj1 = new FinalizerExample("Object1");
                var obj2 = new FinalizerExample("Object2");
                var obj3 = new FinalizerExample("Object3");

                obj1.Dispose();  // Only obj1's Dispose is called
                // obj2 and obj3 will wait for finalizer
            }

            Console.WriteLine("Objects out of scope, waiting for GC...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC complete");
        }

        // =====================================================================
        // 8. MEMORY PRESSURE & MONITORING
        // =====================================================================

        /// <summary>
        /// Monitor memory usage and GC behavior
        /// Important for long-running applications
        /// </summary>
        public void MemoryMonitoringExample()
        {
            Console.WriteLine("=== Memory Monitoring ===");

            var memBefore = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory before: {memBefore / 1024 / 1024} MB");

            // Allocate some memory
            var arrays = new List<byte[]>();
            for (int i = 0; i < 100; i++)
            {
                arrays.Add(new byte[1024 * 1024]);  // 1 MB each
            }

            var memAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory after allocation: {memAfter / 1024 / 1024} MB");
            Console.WriteLine($"Allocated: {(memAfter - memBefore) / 1024 / 1024} MB");

            // Clear and collect
            arrays.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var memFinal = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory after GC: {memFinal / 1024 / 1024} MB");
        }

        /// <summary>
        /// Register for memory pressure notifications
        /// Available on .NET 5+
        /// </summary>
        public void MemoryPressureExample()
        {
            Console.WriteLine("=== Memory Pressure ===");

            // Add memory pressure (simulate unmanaged allocation)
            GC.AddMemoryPressure(10 * 1024 * 1024);  // 10 MB pressure
            Console.WriteLine("Added 10 MB memory pressure");

            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

            // Release memory pressure
            GC.RemoveMemoryPressure(10 * 1024 * 1024);
            Console.WriteLine("Removed memory pressure");
        }

        // =====================================================================
        // 9. COMMON PITFALLS
        // =====================================================================

        /// <summary>
        /// PITFALL 1: Not implementing IDisposable
        /// Resources leak if not cleaned up
        /// </summary>
        public class BadResourceManagement
        {
            private readonly FileStream _fileStream;  // Unmanaged resource

            public BadResourceManagement(string path)
            {
                _fileStream = new FileStream(path, FileMode.Create);
                // Never disposed! ❌
            }
        }

        /// <summary>
        /// PITFALL 2: Calling GC.Collect() in production
        /// Forces expensive Gen 2 collection
        /// Let GC manage itself
        /// </summary>
        public void GCCollectPitfallExample()
        {
            Console.WriteLine("=== GC.Collect() Dangers ===");

            // ❌ BAD: Forces garbage collection
            // GC.Collect();  // Expensive!

            // ✓ GOOD: Let GC decide when to collect
            // GC runs automatically when needed
        }

        /// <summary>
        /// PITFALL 3: Finalizers hiding bugs
        /// Resource not disposed properly
        /// </summary>
        public class FinalizerPitfall
        {
            private FileStream? _resource = new FileStream("file.txt", FileMode.Create);

            // Finalizer masks the bug (no IDisposable)
            ~FinalizerPitfall()
            {
                _resource?.Dispose();  // Cleanup happens late
            }
        }

        // =====================================================================
        // 10. BEST PRACTICES SUMMARY
        // =====================================================================

        /// <summary>
        /// Best Practice 1: Implement IDisposable for resources
        /// </summary>
        public class BestPracticeDisposable : IDisposable
        {
            private bool _disposed = false;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed) return;
                if (disposing) { /* Managed cleanup */ }
                // Unmanaged cleanup
                _disposed = true;
            }

            ~BestPracticeDisposable()
            {
                Dispose(false);
            }
        }

        /// <summary>
        /// Best Practice 2: Use using declarations (C# 8+)
        /// </summary>
        public void BestPracticeUsingDeclaration()
        {
            using var resource = new FileResourceWrapper("data.txt");
            // Use resource
            // Automatically disposed
        }

        /// <summary>
        /// Best Practice 3: Implement IAsyncDisposable for async cleanup
        /// </summary>
        public async Task BestPracticeAsyncDisposal()
        {
            await using var connection = new AsyncDatabaseConnection();
            await connection.ExecuteQueryAsync("SELECT * FROM Table");
        }

        /// <summary>
        /// Best Practice 4: Avoid boxing value types
        /// Use generics instead
        /// </summary>
        public void BestPracticeAvoidBoxing()
        {
            // ❌ BAD: Boxing
            // object obj = 42;

            // ✓ GOOD: Use generics
            var list = new List<int> { 1, 2, 3 };
        }

        /// <summary>
        /// Best Practice 5: Never call GC.Collect() in production
        /// Let GC optimize collection
        /// </summary>
        public void BestPracticeGCHandling()
        {
            // ❌ BAD: Forces collection
            // GC.Collect();

            // ✓ GOOD: Let GC manage
            // Application continues, GC collects as needed
        }

        // =====================================================================
        // RUNNING ALL EXAMPLES
        // =====================================================================

        public async Task RunAllExamplesAsync()
        {
            Console.WriteLine("=== GARBAGE COLLECTOR ===");
            GarbageCollectorExample();

            Console.WriteLine("\n=== GENERATIONS ===");
            GenerationsExample();

            Console.WriteLine("\n=== IDISPOSABLE PATTERN ===");
            IDisposableExample();

            Console.WriteLine("\n=== USING STATEMENT ===");
            UsingStatementExample();

            Console.WriteLine("\n=== USING DECLARATION (C# 8+) ===");
            UsingDeclarationExample();

            Console.WriteLine("\n=== IASYNC DISPOSABLE ===");
            await IAsyncDisposableExample();

            Console.WriteLine("\n=== IASYNC DISPOSABLE DECLARATION ===");
            await IAsyncDisposableDeclarationExample();

            Console.WriteLine("\n=== BOXING ===");
            BoxingExample();

            Console.WriteLine("\n=== UNBOXING ===");
            UnboxingExample();

            Console.WriteLine("\n=== BOXING PERFORMANCE ===");
            BoxingPerformanceExample();

            Console.WriteLine("\n=== WEAK REFERENCE ===");
            WeakReferenceExample();

            Console.WriteLine("\n=== FINALIZER CHAINS ===");
            FinalizerChainsExample();

            Console.WriteLine("\n=== MEMORY MONITORING ===");
            MemoryMonitoringExample();

            Console.WriteLine("\n=== MEMORY PRESSURE ===");
            MemoryPressureExample();

            Console.WriteLine("\n=== BEST PRACTICES ===");
            BestPracticeUsingDeclaration();
            await BestPracticeAsyncDisposal();
            BestPracticeAvoidBoxing();
            Console.WriteLine("Best practices demonstrated");
        }
    }
}
