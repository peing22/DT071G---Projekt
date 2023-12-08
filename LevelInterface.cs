static class LevelInterface
{
    // Statisk metod för att visa level-gränssnitt
    public static void Display(string name, Player player, Action description, Dictionary<int, LevelOption> levelOptions)
    {
        // Rensar konsol och skriver ut namn och XP-indikator
        Clear();
        WriteLine("-----------------------------------------------------------------");
        Write($" {name}");
        int level = player.Level;
        switch (level)
        {
            case 1:
                Write($"         ");
                break;
            case 2:
                Write($"            ");
                break;
            case 3:
                Write($"           ");
                break;
        }
        Write("XP-indikator ");
        player.XpIndicator();
        WriteLine("-----------------------------------------------------------------\n");

        // Anropar metod för att visa beskrivning och ställer en fråga till spelaren
        description?.Invoke();
        WriteLine("Vad vill du göra?\n");

        // Loopar igenom varje objekt i lexikonet av level-alternativ
        foreach (var levelOption in levelOptions)
            {
                // Skriver ut objektets numeriska nyckel och beskrivning
                WriteLine($"{levelOption.Key}. {levelOption.Value.Description}");
            }

        // Skriver ut extra alternativ som inte ingår i lexikonet av objekt
        WriteLine($"{levelOptions.Count + 1}. Dricka en läkande trolldryck");
        WriteLine($"{levelOptions.Count + 2}. Se din aktuella status");
        WriteLine($"{levelOptions.Count + 3}. Spara spelet");
        WriteLine($"{levelOptions.Count + 4}. Avsluta\n");

        // Efterfrågar inmatning
        Write("Välj ett alternativ (1-" + (levelOptions.Count + 4) + "): ");

        // Om inmatningen är en siffra anropas den metod som matchar spelarens val
        if (int.TryParse(ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= levelOptions.Count)
            {
                levelOptions[choice]?.Action?.Invoke();
            }
            else if (choice == levelOptions.Count + 1)
            {
                player.DrinkPotion();
            }
            else if (choice == levelOptions.Count + 2)
            {
                player.PlayerStatus();
            }
            else if (choice == levelOptions.Count + 3)
            {
                Game.SaveGame(player);
            }
            else if (choice == levelOptions.Count + 4)
            {
                Game.QuitGame(player);
            }
            // Om spelarens val inte matchar något av alternativen ovan skrivs felmeddelande ut
            else
            {
                Game.WriteOptionErrorMessage();
            }
        }
        // Om inmatningen inte är en siffra skrivs felmeddelande ut
        else
        {
            Game.WriteOptionErrorMessage();
        }

        // Om spelaren kan nå nästa level
        if (player.CanLevelUp())
        {
            // Anropar metod för att öka spelarens level
            player.LevelUp();
        }
    }
}