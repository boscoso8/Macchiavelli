using Macchiavelli;

// Set console encoding for Unicode card symbols
Console.OutputEncoding = System.Text.Encoding.UTF8;

try
{
    Game game = new Game();
    game.Initialize();
    game.Play();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
