using System;

public class CoreProgram
{
    public static void Main()
    {
        var process = new CoreProgram();

        process.Run("Enter a message (enter 'exit' to quit):", "Greeting Template:", "Hi! My name is {YourName}.");
    }

    public virtual void Run(string intro, string templateTitle, string template)
    {
        Console.WriteLine(intro);
        Console.WriteLine();

        Console.WriteLine(templateTitle);
        Console.WriteLine(template);
        Console.WriteLine();

        while (true)
        {
            // Read input from the console
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                continue;

            // Check if the user wants to exit
            if (input.ToLower() == "exit")
            {
                break;
            }

            // Process the input
            string processedMessage = ProcessMessage(input);

            // Output the processed message
            Console.WriteLine("Processed Message: " + processedMessage);
        }
    }

    protected virtual string? ProcessMessage(string message)
    {
        // Convert the message to uppercase
        return message.ToUpper();
    }
}