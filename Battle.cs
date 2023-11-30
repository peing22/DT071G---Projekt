internal class Battle
{
    // Statisk metod för starta en strid
    public static void StartBattle(Player player, Creature creature)
    {
        // Så länge spelaren och varelsen lever samt så länge spelaren stannar kvar körs while-loopen
        bool thePlayerRemain = true;
        while (player.IsAlive() && creature.IsAlive() && thePlayerRemain)
        {
            // Rensar konsol och skriver ut information om varelse och spelare
            Clear();
            WriteLine("---------------------------------");
            WriteLine("            S T R I D            ");
            WriteLine("---------------------------------\n");
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(creature.Name);
            WriteLine($"Vapenstyrka {creature.WeaponStrength}");
            WriteLine($"Hälsa {creature.Health}\n");
            ResetColor();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(player.Name);
            WriteLine($"Vapenstyrka {player.WeaponStrength}");
            WriteLine($"Hälsa {player.Health}\n");
            ResetColor();

            // Skriver ut alternativ
            WriteLine("Vad vill du göra?\n");
            WriteLine("1. Gå till attack");
            WriteLine("2. Försvara dig");
            WriteLine("3. Springa iväg");

            // Efterfrågar inmatning
            Write("\nVälj ett alternativ (1-3): ");

            // Om inmatningen är en siffra körs switch-satsen
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
                        Clear();
                        int attack = new Random().Next(1, 4);
                        switch (attack)
                        {
                            case 1:
                                // Skriver ut meddelande och minskar varelsens hälsa
                                WriteLine("Du går till attack med ditt svärd och träffar med full kraft. Den");
                                Write($"{creature.Name!.ToLower()} har ingen chans och förlorar {player.WeaponStrength} i hälsa...");
                                creature.Health -= player.WeaponStrength;
                                break;
                            case 2:
                                // Skriver ut meddelande
                                Write($"Du går till attack med ditt svärd, men den {creature.Name!.ToLower()} försvarar sig...");
                                break;
                            case 3:
                                // Skriver ut meddelande och minskar spelarens hälsa
                                WriteLine($"Du går till attack med ditt svärd, men den {creature.Name!.ToLower()} lyckas");
                                Write($"överlista dig och gör en motattack. Du förlorar {creature.WeaponStrength} i hälsa...");
                                player.Health -= creature.WeaponStrength;
                                break;
                        }
                        ReadKey();
                        break;
                    case 2:
                        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
                        Clear();
                        int defend = new Random().Next(1, 3);
                        switch (defend)
                        {
                            case 1:
                                // Skriver ut meddelande
                                WriteLine($"Den {creature.Name!.ToLower()} gör ett försök att attackera dig,");
                                Write("men du lyckas försvara dig...");
                                break;
                            case 2:
                                // Skriver ut meddelande och minskar spelarens hälsa
                                WriteLine($"Den {creature.Name!.ToLower()} attackerar dig med all sin kraft och");
                                Write($"du lyckas inte försvara dig. Du förlorar {creature.WeaponStrength} i hälsa...");
                                player.Health -= creature.WeaponStrength;
                                break;
                        }
                        ReadKey();
                        break;
                    case 3:
                        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
                        Clear();
                        int run = new Random().Next(1, 3);
                        switch (run)
                        {
                            case 1:
                                // Skriver ut meddelande
                                Write("Du springer för ditt liv och lyckas på något otroligt sätt komma undan...");
                                break;
                            case 2:
                                // Skriver ut meddelande och minskar spelarens hälsa
                                WriteLine($"Du springer för ditt liv, men under flykten lyckas den {creature.Name!.ToLower()}");
                                Write($"attackera dig och du förlorar {creature.WeaponStrength} i hälsa...");
                                player.Health -= creature.WeaponStrength;
                                break;
                        }
                        ReadKey();

                        // Sätter thePlayerRemain till false för att stoppa while-loopen
                        thePlayerRemain = false;
                        break;
                    default:
                        Game.WriteOptionErrorMessage();
                        break;
                }
            }
            // Om inmatningen inte är en siffra skrivs felmeddelande ut
            else
            {
                Game.WriteOptionErrorMessage();
            }
        }

        // Om varelsen inte lever ökas spelarens XP, konsolen rensas och meddelande skrivs ut
        if (!creature.IsAlive())
        {
            player.Xp += creature.XpValue;
            Clear();
            WriteLine($"Det var en tuff strid, men du har besegrat den {creature.Name!.ToLower()}!");
            Write($"Dina erfarenhetspoäng (XP) ökar med {creature.XpValue}...");
            ReadKey();
        }
        // Om spelaren inte lever skrivs meddelande ut och spelet avslutas
        else if (!player.IsAlive())
        {
            Clear();
            Write($"Den {creature.Name!.ToLower()} har besegrat dig och du är död...");
            ReadKey();
            Game.QuitGame();
        }
    }
}