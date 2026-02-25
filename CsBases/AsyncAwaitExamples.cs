namespace CsBases.Examples
{
    /// <summary>
    /// Demonstrates C# Asynchronous Programming: Async/Await & Threading
    /// Covers Tasks, async/await, cancellation, and best practices
    /// </summary>
    public class AsyncAwaitExamples
    {
        // =====================================================================
        // 1. ASYNC/AWAIT BASICS
        // =====================================================================

        /// <summary>
        /// Basic async method returning Task (no return value)
        /// The 'async' keyword enables use of 'await'
        /// </summary>
        public async Task BasicAsyncExample()
        {
            Console.WriteLine("Starting async operation...");
            await Task.Delay(1000);  // Non-blocking delay
            Console.WriteLine("Completed after 1 second");
        }

        /// <summary>
        /// Async method returning Task<T> (with return value)
        /// </summary>
        public async Task<string> FetchDataAsync(string id)
        {
            Console.WriteLine($"Fetching data for ID: {id}");
            await Task.Delay(500);  // Simulate network delay
            return $"Data for {id}";
        }

        /// <summary>
        /// Calling async methods - MUST use await
        /// </summary>
        public async Task CallAsyncMethodsExample()
        {
            // Await returns the completed task's result
            string result = await FetchDataAsync("123");
            Console.WriteLine($"Result: {result}");

            // Multiple sequential async operations
            string data1 = await FetchDataAsync("1");
            string data2 = await FetchDataAsync("2");
            Console.WriteLine($"Got: {data1}, {data2}");
        }

        // =====================================================================
        // 2. TASK vs TASK<T> vs VALUETASK
        // =====================================================================

        /// <summary>
        /// Task: Represents an async operation with NO return value
        /// </summary>
        public async Task ReturnsTask()
        {
            await Task.Delay(100);
            Console.WriteLine("Task completed (no return)");
        }

        /// <summary>
        /// Task<T>: Represents an async operation WITH return value
        /// </summary>
        public async Task<int> ReturnsTaskOfInt()
        {
            await Task.Delay(100);
            return 42;
        }

        /// <summary>
        /// ValueTask<T>: Optimization for synchronously-completing operations
        /// Reduces allocations when result is available immediately
        /// Use when:
        /// - Operation often completes synchronously
        /// - Performance is critical
        /// - Called in hot paths
        /// </summary>
        public async ValueTask<int> ReturnsValueTaskOfInt(bool isSync)
        {
            if (isSync)
            {
                // Fast path: return synchronously without allocation
                return 100;
            }

            await Task.Delay(100);
            return 200;
        }

        public async Task TaskVsValueTaskExample()
        {
            // Task and Task<T>
            await ReturnsTask();
            int taskResult = await ReturnsTaskOfInt();
            Console.WriteLine($"Task<int> result: {taskResult}");

            // ValueTask
            int valueTaskSync = await ReturnsValueTaskOfInt(true);   // No allocation
            int valueTaskAsync = await ReturnsValueTaskOfInt(false);  // Allocates
            Console.WriteLine($"ValueTask sync: {valueTaskSync}, async: {valueTaskAsync}");
        }

        // =====================================================================
        // 3. PARALLEL ASYNC OPERATIONS
        // =====================================================================

        /// <summary>
        /// Sequential: Each operation waits for the previous one
        /// Total time: Sum of all delays
        /// </summary>
        public async Task SequentialAsyncExample()
        {
            Console.WriteLine("Starting sequential operations...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string r1 = await FetchDataAsync("A");
            string r2 = await FetchDataAsync("B");
            string r3 = await FetchDataAsync("C");

            watch.Stop();
            Console.WriteLine($"Sequential completed in {watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Results: {r1}, {r2}, {r3}");
        }

        /// <summary>
        /// Parallel: All operations run concurrently
        /// Total time: Max of all delays
        /// Use Task.WhenAll() for better performance
        /// </summary>
        public async Task ParallelAsyncExample()
        {
            Console.WriteLine("Starting parallel operations...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Start all tasks without awaiting immediately
            Task<string> task1 = FetchDataAsync("A");
            Task<string> task2 = FetchDataAsync("B");
            Task<string> task3 = FetchDataAsync("C");

            // Wait for all to complete
            var results = await Task.WhenAll(task1, task2, task3);

            watch.Stop();
            Console.WriteLine($"Parallel completed in {watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Results: {string.Join(", ", results)}");
        }

        /// <summary>
        /// WhenAny: Returns when first task completes
        /// Useful for timeout or race conditions
        /// </summary>
        public async Task WhenAnyExample()
        {
            Task<string> slow = FetchDataAsync("slow");
            Task<string> fast = FetchDataAsync("fast");
            Task<string> medium = FetchDataAsync("medium");

            // Returns immediately when any completes
            Task<string> firstCompleted = await Task.WhenAny(slow, fast, medium);
            Console.WriteLine($"First completed: {await firstCompleted}");
        }

        // =====================================================================
        // 4. CANCELLATION TOKENS
        // =====================================================================

        /// <summary>
        /// CancellationToken allows graceful cancellation
        /// Essential for user cancellation, timeouts, application shutdown
        /// </summary>
        public async Task LongRunningOperationAsync(CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    // Check if cancellation was requested
                    cancellationToken.ThrowIfCancellationRequested();

                    Console.WriteLine($"Working... {i + 1}/10");
                    await Task.Delay(500, cancellationToken);
                }
                Console.WriteLine("Operation completed successfully");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled");
            }
        }

        public async Task CancellationTokenExample()
        {
            // Create a cancellation token source
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                // Cancel after 2 seconds
                cts.CancelAfter(TimeSpan.FromSeconds(2));

                // Pass token to async operation
                await LongRunningOperationAsync(cts.Token);
            }
        }

        /// <summary>
        /// Multiple cancellation tokens with linked token source
        /// </summary>
        public async Task LinkedCancellationTokensExample()
        {
            using (CancellationTokenSource cts1 = new CancellationTokenSource())
            using (CancellationTokenSource cts2 = new CancellationTokenSource())
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token))
            {
                // If either cts1 or cts2 is cancelled, linkedCts is cancelled
                cts1.CancelAfter(TimeSpan.FromSeconds(1));

                try
                {
                    await Task.Delay(2000, linkedCts.Token);
                    Console.WriteLine("Delay completed");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Cancelled via linked token");
                }
            }
        }

        // =====================================================================
        // 5. CONFIGUREWAIT(FALSE)
        // =====================================================================

        /// <summary>
        /// ConfigureAwait(false): Tells framework to not capture sync context
        /// Improves performance and prevents deadlocks in libraries
        ///
        /// Sync Context: UI frameworks (WPF, WinForms, ASP.NET) maintain context
        /// to execute continuations on the original thread
        ///
        /// Use in LIBRARIES to avoid forcing continuations back to UI thread
        /// Avoid in UI code where you need UI thread access
        /// </summary>
        public async Task<string> LibraryMethodAsync()
        {
            // Good practice: Use ConfigureAwait(false) in libraries
            await Task.Delay(100).ConfigureAwait(false);
            return "Library result";
        }

        public async Task<string> UICodeAsync()
        {
            // UI code: DON'T use ConfigureAwait(false) - need UI thread
            string result = await LibraryMethodAsync().ConfigureAwait(false);
            // Still have UI context for UI updates
            return result;
        }

        // =====================================================================
        // 6. EXCEPTION HANDLING IN ASYNC CODE
        // =====================================================================

        /// <summary>
        /// Exception handling works normally with async/await
        /// </summary>
        public async Task ExceptionHandlingExample()
        {
            try
            {
                string result = await OperationThatMayFailAsync(true);
                Console.WriteLine(result);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
        }

        private async Task<string> OperationThatMayFailAsync(bool shouldFail)
        {
            await Task.Delay(100);
            if (shouldFail)
                throw new InvalidOperationException("Something went wrong!");
            return "Success";
        }

        /// <summary>
        /// Multiple parallel operations with exception aggregation
        /// </summary>
        public async Task AggregateExceptionHandlingExample()
        {
            try
            {
                Task task1 = Task.Delay(100).ContinueWith(_ => throw new Exception("Task 1 failed"));
                Task task2 = Task.Delay(100).ContinueWith(_ => throw new Exception("Task 2 failed"));

                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                // When using WhenAll, first exception is thrown
                Console.WriteLine($"First exception: {ex.Message}");
            }
        }

        // =====================================================================
        // 7. COMMON PITFALLS
        // =====================================================================

        /// <summary>
        /// PITFALL 1: Async Void (AVOID!)
        /// Only use for event handlers
        /// </summary>
        // DON'T DO THIS (unless event handler):
        public async void BadAsyncVoidMethod()  // ❌ AVOID
        {
            await Task.Delay(100);
            Console.WriteLine("This is bad practice");
            // No way to know when it completes, exceptions are hard to handle
        }

        // DO THIS INSTEAD:
        public async Task GoodAsyncTaskMethod()  // ✓ GOOD
        {
            await Task.Delay(100);
            Console.WriteLine("This is good practice");
        }

        // Exception in async void is hard to catch:
        public async void BadExceptionHandling()  // ❌ Exceptions go to sync context
        {
            await Task.Delay(100);
            throw new Exception("This is dangerous!");
        }

        /// <summary>
        /// PITFALL 2: Not awaiting async methods
        /// </summary>
        public async Task NotAwaitingExample()
        {
            // ❌ BAD: Fire and forget (no await)
            FetchDataAsync("123");  // Task is created but never awaited

            // ✓ GOOD: Properly await
            await FetchDataAsync("123");

            // ✓ GOOD: If intentional, be explicit
            _ = FetchDataAsync("123");  // Intentionally discarding
        }

        /// <summary>
        /// PITFALL 3: Blocking on async code (DEADLOCK RISK)
        /// </summary>
        public void BlockingOnAsyncBad()
        {
            // ❌ EXTREMELY BAD: Can cause deadlock
            // string result = FetchDataAsync("123").Result;  // DON'T DO THIS!
            // string result = FetchDataAsync("123").Wait();  // DON'T DO THIS!

            // ✓ GOOD: Use async all the way
            // var result = await FetchDataAsync("123");
        }

        // =====================================================================
        // 8. BEST PRACTICES SUMMARY
        // =====================================================================

        /// <summary>
        /// Best Practice 1: Always use async/await for I/O
        /// </summary>
        public async Task<string> BestPracticeIOAsync()
        {
            // Simulate HTTP request
            await Task.Delay(100);
            return "Response";
        }

        /// <summary>
        /// Best Practice 2: Use ConfigureAwait(false) in libraries
        /// </summary>
        public async Task<int> BestPracticeLibraryAsync()
        {
            await Task.Delay(100).ConfigureAwait(false);
            return 42;
        }

        /// <summary>
        /// Best Practice 3: Implement proper cancellation support
        /// </summary>
        public async Task<string> BestPracticeCancellationAsync(CancellationToken ct = default)
        {
            await Task.Delay(100, ct);
            return "Success";
        }

        /// <summary>
        /// Best Practice 4: Use ValueTask for optimized hot paths
        /// </summary>
        public async ValueTask<int> BestPracticeValueTaskAsync(bool isCached, Dictionary<string, int> cache)
        {
            if (isCached && cache.TryGetValue("key", out int value))
            {
                return value;  // Synchronous return, no allocation
            }

            await Task.Delay(100);
            return 100;
        }

        /// <summary>
        /// Best Practice 5: Use Task.WhenAll for parallel operations
        /// </summary>
        public async Task<int[]> BestPracticeParallelAsync(string[] ids)
        {
            // Start all operations concurrently
            var tasks = ids.Select(id => FetchIntAsync(id)).ToArray();

            // Wait for all to complete
            var results = await Task.WhenAll(tasks);
            return results;
        }

        private async Task<int> FetchIntAsync(string id)
        {
            await Task.Delay(100);
            return id.GetHashCode();
        }

        // =====================================================================
        // 9. SYNCHRONIZATION CONTEXT & THREADING
        // =====================================================================

        /// <summary>
        /// Synchronization Context: Mechanism for capturing thread context
        /// Different contexts for UI, ASP.NET, and general code
        /// </summary>
        public async Task SyncContextExample()
        {
            var ctx = SynchronizationContext.Current;
            Console.WriteLine($"Current context: {ctx?.GetType().Name ?? "None"}");

            // After await, context might change (without ConfigureAwait(false))
            await Task.Delay(100);

            var ctxAfter = SynchronizationContext.Current;
            Console.WriteLine($"Context after await: {ctxAfter?.GetType().Name ?? "None"}");

            // With ConfigureAwait(false), context is not captured
            await Task.Delay(100).ConfigureAwait(false);
            var ctxAfterConfigAwait = SynchronizationContext.Current;
            Console.WriteLine($"Context after ConfigureAwait(false): {ctxAfterConfigAwait?.GetType().Name ?? "None"}");
        }

        // =====================================================================
        // 10. PRACTICAL EXAMPLE: ROBUST ASYNC API
        // =====================================================================

        /// <summary>
        /// Robust async method demonstrating best practices
        /// </summary>
        public async Task<T> RobustAsyncAPIAsync<T>(
            Func<Task<T>> operation,
            int retries = 3,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default) where T : class
        {
            timeout ??= TimeSpan.FromSeconds(30);
            int attempt = 0;

            while (attempt < retries)
            {
                try
                {
                    // Create timeout cancellation token
                    using (var timeoutCts = new CancellationTokenSource(timeout.Value))
                    using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                        cancellationToken, timeoutCts.Token))
                    {
                        // Execute operation with timeout
                        var result = await operation().ConfigureAwait(false);
                        return result;
                    }
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    // Timeout occurred (not user cancellation)
                    attempt++;
                    if (attempt >= retries)
                        throw;

                    Console.WriteLine($"Timeout, retrying... (attempt {attempt}/{retries})");
                    await Task.Delay(100 * attempt, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Operation failed: {ex.Message}");
                    throw;
                }
            }

            return null!;
        }

        // =====================================================================
        // RUNNING ALL EXAMPLES
        // =====================================================================

        public async Task RunAllExamplesAsync()
        {
            Console.WriteLine("=== BASIC ASYNC/AWAIT ===");
            await BasicAsyncExample();

            Console.WriteLine("\n=== CALLING ASYNC METHODS ===");
            await CallAsyncMethodsExample();

            Console.WriteLine("\n=== TASK vs TASK<T> vs VALUETASK ===");
            await TaskVsValueTaskExample();

            Console.WriteLine("\n=== SEQUENTIAL ASYNC ===");
            await SequentialAsyncExample();

            Console.WriteLine("\n=== PARALLEL ASYNC ===");
            await ParallelAsyncExample();

            Console.WriteLine("\n=== WHEN ANY ===");
            await WhenAnyExample();

            Console.WriteLine("\n=== CANCELLATION TOKEN ===");
            await CancellationTokenExample();

            Console.WriteLine("\n=== LINKED CANCELLATION TOKENS ===");
            await LinkedCancellationTokensExample();

            Console.WriteLine("\n=== EXCEPTION HANDLING ===");
            await ExceptionHandlingExample();

            Console.WriteLine("\n=== AGGREGATE EXCEPTION HANDLING ===");
            await AggregateExceptionHandlingExample();

            Console.WriteLine("\n=== SYNC CONTEXT ===");
            await SyncContextExample();

            Console.WriteLine("\n=== BEST PRACTICES DEMONSTRATED ===");
            var result = await BestPracticeCancellationAsync();
            Console.WriteLine($"Best practice result: {result}");
        }
    }
}
