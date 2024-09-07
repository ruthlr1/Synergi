// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using SongSuggester.App;
using SongSuggester.Application;
using SongSuggester.Application.Services.Songs;

var host = DependencyInjection.Register(args);

// always prompting to ask for genre
while (true)
{
    Console.WriteLine("Enter a genre to search for");
    // Read the input from the console
    string? userInput = Console.ReadLine();

    // check for valid genre
    var validationMessage = InputValidator.ValidateGenre(userInput);
    if(!string.IsNullOrEmpty(validationMessage))
    {
        Console.WriteLine(validationMessage);
        Console.WriteLine(""); // add extra space for UI
        continue;
    }

    // make call to go and get the songs
    var songService = host.Services.GetRequiredService<ISongService>();
    var displayMessages = await songService.GetSongs(userInput!);
    
    // display results
    foreach(var msg in displayMessages)
    {
        Console.WriteLine(msg);
    }

    Console.WriteLine(""); // add extra space for UI
}
