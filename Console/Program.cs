using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;

Task whenAllDone = Task.CompletedTask;

var console = new Swopblock.Console("Swopblock", args, out whenAllDone);

await whenAllDone;

namespace Swopblock
{
    public class Console
    {
        public Console(string processorName, string[] args, out Task whenAll)
        {
            ProcessorName = processorName;

            var queue = new ConcurrentQueue<string>();
            TextReader inputReader = System.Console.In;
            TextWriter outputWriter = System.Console.Out;

            if (args.Length > 0)
            {
                if (args.Length >= 2 && args[0] == "--input")
                {
                    inputReader = new StreamReader(args[1]);
                }
                if (args.Length >= 4 && args[2] == "--output")
                {
                    outputWriter = new StreamWriter(args[3]) { AutoFlush = true };
                }
            }

            var readTask = Task.Run(() => ReadLinesAsync(queue, inputReader));
            var writeTask = Task.Run(() => WriteLinesAsync(queue, outputWriter));

            whenAll = Task.WhenAll(readTask, writeTask);
        }

        public string ProcessorName { get; init; }

        public virtual async Task ReadLinesAsync(ConcurrentQueue<string> queue, TextReader reader)
        {
            while (true)
            {
                var line = await Task.Run(() => reader.ReadLine());
                if (line == null) break; // Exit on null input (e.g., end of file)
                queue.Enqueue(line);
            }
        }

        public virtual async Task WriteLinesAsync(ConcurrentQueue<string> queue, TextWriter writer)
        {
            while (true)
            {
                if (queue.TryDequeue(out var line))
                {
                    await foreach (var source in SourceFormat(line))
                    {
                        await foreach (var result in ProcessCommand(source))
                        {
                            await foreach (var sink in ResultFormat(result))
                            {
                                await Task.Run(() => writer.WriteLine(sink));
                            }
                        }
                    }
                }
                else
                {
                    await Task.Delay(random.Next(1000)); // Wait a bit before checking the queue
                }
            }
        }

        Random random = new Random();

        public virtual async IAsyncEnumerable<string> ProcessCommand(string command)
        {
            await Task.Delay(random.Next(1000)); // Simulate command process time 

            System.Console.WriteLine($"    Let {ProcessorName}.Command be: {command} = ProcessCommand({command})");

            yield return command;
        }

        public virtual async IAsyncEnumerable<string> SourceFormat(string command)
        {
            await Task.Delay(random.Next(1000)); // Simulate command source format time 

            System.Console.WriteLine();
            System.Console.WriteLine($"    Let {ProcessorName}.Source  be: {command} = SourceFormat({command})");

            yield return command;
        }

        public virtual async IAsyncEnumerable<string> ResultFormat(string command)
        {
            await Task.Delay(random.Next(1000)); // Simulate command sink format time 

            System.Console.WriteLine($"    Let {ProcessorName}.Result  be: {command} = ResultFormat({command})");
            System.Console.WriteLine();

            yield return command;
        }
    }
}

