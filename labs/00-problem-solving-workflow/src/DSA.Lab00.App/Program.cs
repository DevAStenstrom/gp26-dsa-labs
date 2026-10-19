using System;
using System.Collections.Generic;
using DSA.Lab00;

List<Player> players = new()
{
    new Player(101, "Amina", 120),
    new Player(205, "Bo", 85),
    new Player(734, "Cleo", 160),
    new Player(910, "Dani", 105),
};

PlayerCollection collection = new(players);

Console.WriteLine("DSA Lab 0 - baseline\n");

Player? player = collection.FindById(734);

Console.WriteLine($"{collection.FindHighestScore()?.Name} has the highest score of all players\n");

if (player != null)
{
    Console.WriteLine(collection.ContainsName(player.Name) ? $"{player.Name} is in the collection\n" : $"{player.Name} is not in the collection\n" );
    
    Console.WriteLine($"Found player {player.Name} with score {player.Score}\n");
}
else
{
    Console.WriteLine("Player not found\n");
}

Console.WriteLine("Next: open the lab README and work through the tasks");
