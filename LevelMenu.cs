static class LevelMenu
{
    // Statisk metod för att visa levelmenyn
    public static void DisplayMenu(string name, Player player, Action description, Dictionary<int, MenuItem> menuItems)
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

        // Loopar igenom varje menyobjekt i lexikonet av menyobjekt
        foreach (var menuItem in menuItems)
            {
                // Skriver ut menyobjektets numeriska nyckel och beskrivning
                WriteLine($"{menuItem.Key}. {menuItem.Value.Description}");
            }

        // Skriver ut extra menyalternativ som inte ingår i lexikonet av menyobjekt
        WriteLine($"{menuItems.Count + 1}. Dricka en läkande trolldryck");
        WriteLine($"{menuItems.Count + 2}. Se din aktuella status");
        WriteLine($"{menuItems.Count + 3}. Spara spelet");
        WriteLine($"{menuItems.Count + 4}. Avsluta\n");

        // Efterfrågar inmatning
        Write("Välj ett alternativ (1-" + (menuItems.Count + 4) + "): ");

        // Om inmatningen är en siffra anropas den metod som matchar spelarens val
        if (int.TryParse(ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= menuItems.Count)
            {
                menuItems[choice]?.Action?.Invoke();
            }
            else if (choice == menuItems.Count + 1)
            {
                player.DrinkPotion();
            }
            else if (choice == menuItems.Count + 2)
            {
                player.PlayerStatus();
            }
            else if (choice == menuItems.Count + 3)
            {
                Game.SaveGame(player);
            }
            else if (choice == menuItems.Count + 4)
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