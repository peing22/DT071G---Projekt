internal class Battle
{
    // Skapar en fältvariabel med en instans av klassen "Random"
    private static readonly Random random = new();

    // Statisk metod för starta en strid
    public static void StartBattle(Player player, Creature creature)
    {
        // Så länge spelaren och varelsen lever samt så länge spelaren stannar kvar körs while-loopen
        bool thePlayerRemain = true;
        while (player.IsAlive() && creature.IsAlive() && thePlayerRemain)
        {
            // Rensar konsol och skriver ut information om spelare och varelse
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

            // Om inmatningen är en siffra körs switch-satsen där metoder anropas
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Attack(player, creature);
                        break;
                    case 2:
                        Defend(player, creature);
                        break;
                    case 3:
                        Escape(player, creature, ref thePlayerRemain);
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
        // Anropar metod för att hantera utfallet av striden
        BattleOutcome(player, creature);
    }

    // Statisk metod för att gå till attack
    private static void Attack(Player player, Creature creature)
    {
        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
        Clear();
        int attack = random.Next(1, 4);
        switch (attack)
        {
            case 1:
                // Genererar ett slumpmässigt nummer
                int playerMakeDamage = random.Next(1, player.WeaponStrength + 1);

                // Skriver ut meddelande och minskar varelsens hälsa
                WriteLine("Du går till attack med ditt svärd och träffar med full kraft!");
                Write($"Den {creature.Name!.ToLower()} förlorar {playerMakeDamage} i hälsa...");
                creature.Health -= playerMakeDamage;
                break;
            case 2:
                // Skriver ut meddelande
                Write($"Du går till attack med ditt svärd, men den {creature.Name!.ToLower()} försvarar sig...");
                break;
            case 3:
                // Genererar ett slumpmässigt nummer
                int creatureMakeDamage = random.Next(1, creature.WeaponStrength + 1);

                // Skriver ut meddelande och minskar spelarens hälsa
                WriteLine($"Du går till attack med ditt svärd, men den {creature.Name!.ToLower()} lyckas");
                Write($"överlista dig och gör en motattack. Du förlorar {creatureMakeDamage} i hälsa...");
                player.Health -= creatureMakeDamage;
                break;
        }
        ReadKey();
    }

    // Statisk metod för att försvara sig
    private static void Defend(Player player, Creature creature)
    {
        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
        Clear();
        int defend = random.Next(1, 3);
        switch (defend)
        {
            case 1:
                // Skriver ut meddelande
                WriteLine($"Den {creature.Name!.ToLower()} gör ett försök att attackera dig,");
                Write("men du lyckas försvara dig...");
                break;
            case 2:
                // Genererar ett slumpmässigt nummer
                int creatureMakeDamage = random.Next(1, creature.WeaponStrength + 1);

                // Skriver ut meddelande och minskar spelarens hälsa
                WriteLine($"Den {creature.Name!.ToLower()} attackerar dig med all sin kraft och");
                Write($"du lyckas inte försvara dig. Du förlorar {creatureMakeDamage} i hälsa...");
                player.Health -= creatureMakeDamage;
                break;
        }
        ReadKey();
    }

    // Statisk metod för att springa iväg
    private static void Escape(Player player, Creature creature, ref bool thePlayerRemain)
    {
        // Rensar konsol, genererar ett slumpmässigt nummer och kör switch-satsen
        Clear();
        int run = random.Next(1, 3);
        switch (run)
        {
            case 1:
                // Skriver ut meddelande
                Write("Du springer för ditt liv och lyckas på något otroligt sätt komma undan...");
                break;
            case 2:
                // Genererar ett slumpmässigt nummer
                int creatureMakeDamage = random.Next(1, creature.WeaponStrength + 1);

                // Skriver ut meddelande och minskar spelarens hälsa
                WriteLine($"Du springer för ditt liv, men under flykten lyckas den {creature.Name!.ToLower()}");
                Write($"attackera dig och du förlorar {creatureMakeDamage} i hälsa...");
                player.Health -= creatureMakeDamage;
                break;
        }
        ReadKey();

        // Sätter thePlayerRemain till false för att stoppa while-loopen
        thePlayerRemain = false;
    }

    // Statisk metod för att hantera utfallet av striden
    private static void BattleOutcome(Player player, Creature creature)
    {
        // Om varelsen inte lever och spelarens level är mindre än 3 ökas spelarens XP, konsolen rensas och meddelande skrivs ut
        if (!creature.IsAlive() && player.Level < 3)
        {
            player.Xp += creature.XpValue;
            Clear();
            Game.Print($"Det var en tuff strid, men du har besegrat den {creature.Name!.ToLower()}!\n");
            Game.Print($"Dina erfarenhetspoäng (XP) ökar med {creature.XpValue}...");
            ReadKey();
        }
        // Om varelsen inte lever och spelarens level är 3 rensas konsolen, meddelande skrivs ut och spelet avslutas
        else if (!creature.IsAlive() && player.Level == 3)
        {
            Clear();
            Game.Print($"Den {creature.Name!.ToLower()} ger ifrån sig ett isande skrik innan den\n");
            Game.Print("gradvis löses upp och försvinner för gott...");
            ReadKey();
            Clear();
            Game.Print("Sårad men lättad över segern, ser du dig omkring och upptäcker Eldrion,\n");
            Game.Print("trollkarlen, Vendela och flera andra skogsinvånare som kommer emot dig\n");
            Game.Print("med hurrarop och segersång...");
            ReadKey();
            Clear();
            Game.Print($"Eldrion berättar att i samma stund som den {creature.Name!.ToLower()} gav ifrån sig\n");
            Game.Print("sitt isande skrik, återgick skogen till sitt normala tillstånd...");
            ReadKey();
            Clear();
            Game.Print("Eldrion tackar dig för ditt hjältemod och för din välvilja...");
            ReadKey();
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            Game.Print("Du har löst mysteriet med de mystiska skuggorna!");
            ResetColor();
            ReadKey();
            Game.QuitGame(player);
        }
        // Om spelaren inte lever skrivs meddelande ut och spelet avslutas
        else if (!player.IsAlive())
        {
            Clear();
            Game.Print($"Den {creature.Name!.ToLower()} har besegrat dig och du är död...");
            ReadKey();
            Game.QuitGame(player);
        }
    }
}