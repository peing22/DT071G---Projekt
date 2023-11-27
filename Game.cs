/*
Importerar klass för att slippa upprepa "Console" och namespace för 
att hantera konvertering mellan JSON och objekt.
*/
using static System.Console;
using System.Text.Json;

internal class Game
{
    // Skapar en privat statisk lista av Player-objekt
    private static List<Player> Players = new();

    // Konstruktor som körs när en instans av klassen "Game" skapas
    public Game()
    {
        // Om JSON-filen existerar deserialiseras innehållet till listan med Player-objekt
        if (File.Exists("savedgames.json"))
        {
            string json = File.ReadAllText("savedgames.json");
            Players = JsonSerializer.Deserialize<List<Player>>(json)!;
        }
    }

    // Statisk metod för att starta ett nytt spel
    public static void NewGame()
    {
        // Så länge isInputValid är false körs while-loopen
        bool isInputValid = false;
        while (!isInputValid)
        {
            // Rensar konsol, efterfrågar användarens namn och sparar värde i variabel
            Clear();
            Write("Ge din spelkaraktär ett namn: ");
            string? name = ReadLine();

            // Om namn är null, tomt eller blanksteg skrivs felmeddelande ut och en ny iteration av loopan startas
            if (string.IsNullOrWhiteSpace(name))
            {
                Clear();
                Write("Ogiltigt namn! Tryck på valfri tangent...");
                ReadKey();
            }
            // Om namn är korrekt angivet sätts värden för spelarens id och namn
            else
            {
                Player.CurrentPlayer.Id = Players.Count + 1;
                Player.CurrentPlayer.Name = name;

                // isInputValid sätts till true för att stoppa loopen
                isInputValid = true;

                // Rensar konsol och skriver ut inledande story
                Clear();
                Print("Du vaknar upp i en dimmig skog och har ingen aning om hur du hamnade där, \n");
                Print($"men du kommer åtminstone ihåg att du heter {Player.CurrentPlayer.Name}. \n\n");
                Print("En mystisk röst hörs i vinden. Den uppmanar dig att följa stigen framåt...");
                ReadKey();
                Clear();
                Print("Efter att ha vandrat en stund genom den dimmiga skogen, når du en gammal \n");
                Print("stenport. Porten öppnas långsamt när du närmar dig, och du stiger in i en \n");
                Print("värld där skuggorna tycks leva sitt eget liv. \n\n");
                Print("Din uppgift är att utforska denna mystiska värld, avslöja dess \n");
                Print("hemligheter och övervinna de faror som lurar i skuggorna...");
                ReadKey();

                // Anropar metod
                PlayGame();
            }
        }
    }

    // Statisk metod för att ladda ett sparat spel
    public static void LoadGame()
    {
        // Rensar konsol och om antalet sparade spelare är noll skrivs meddelande ut
        Clear();
        if (Players.Count == 0)
        {
            Write("Det finns inga sparade spel. Tryck på valfri tangent...");
            ReadKey();
        }
        // Om antalet spelare inte är noll körs while-loopen så länge isChoiceValid är false
        else
        {
            bool isChoiceValid = false;
            while (!isChoiceValid)
            {
                // Rensar konsol, skriver ut sparade spel och efterfrågar inmatning
                Clear();
                WriteLine("----------------------------");
                WriteLine("   S P A R A D E  S P E L   ");
                WriteLine("----------------------------\n");
                for (int i = 0; i < Players.Count; i++)
                {
                    WriteLine($"    {i + 1}. {Players[i].Name} (level {Players[i].Level})");
                }
                Write($"\nVälj ett alternativ (1-{Players.Count}): ");

                // Om inmatning inte är korrekt skrivs felmeddelande ut
                if (!int.TryParse(ReadLine(), out int choice) || choice < 1 || choice > Players.Count)
                {
                    Clear();
                    Write("Ogiltigt alternativ! Tryck på valfri tangent...");
                    ReadKey();
                }
                // Om inmatning är korrekt uppdateras CurrentPlayer med vald spelare
                else
                {
                    Player.CurrentPlayer = Players[choice - 1];

                    // isChoiceValid sätts till true för att stoppa loopen
                    isChoiceValid = true;
                }
            }

            // Rensar konsol och skriver ut hälsning...
            Clear();
            Print($"Välkommen tillbaka, {Player.CurrentPlayer.Name}...");
            ReadKey();

            // Anropar metod
            PlayGame();
        }
    }

    // Statisk metod för att spela olika nivåer av spelet
    public static void PlayGame()
    {
        // Rensar konsol och lagrar aktuell level i en variabel
        Clear();
        int currentLevel = Player.CurrentPlayer.Level;

        // Kör kodblock utifrån spelarens level
        switch (currentLevel)
        {
            case 1:
                // Skapar en ny instans av klassen "LevelOne" och skickar med namn som parameter
                LevelOne levelOne = new("Level 1 - Skogens hemligheter");

                // Skriver ut namn och beskrivning för level
                Write($"{levelOne.Name}\n\n");
                levelOne.LevelDescript();
                ReadKey();
                break;
            case 2:
                Write("Level 2...");
                ReadKey();
                break;
            case 3:
                Write("Level 3...");
                ReadKey();
                break;
            case 4:
                Write("Level 4...");
                ReadKey();
                break;
            case 5:
                Write("Level 5...");
                ReadKey();
                break;
        }
    }

    // Statisk metod för att spara ett spel
    public static void SaveGame()
    {
        // Om CurrentPlayer redan existerar i listan med spelare ersätts den befintliga instansen
        var existingPlayer = Players.Find(p => p.Id == Player.CurrentPlayer.Id);
        if (existingPlayer != null)
        {
            Players[Players.IndexOf(existingPlayer)] = Player.CurrentPlayer;
        }
        // Om CurrentPlayer inte existerar adderas den nya insatsen till listan med spelare
        else
        {
            Players.Add(Player.CurrentPlayer);
        }

        // Serialiserar listan med spelare till en JSON-sträng och sparar den till en JSON-fil
        string json = JsonSerializer.Serialize(Players);
        File.WriteAllText("savedgames.json", json);
    }

    // Statisk metod för att avsluta programmet
    public static void QuitGame()
    {
        Clear();
        Environment.Exit(0);
    }

    // Statisk metod för att skriva ut meny
    public static void GameMenu()
    {
        // Skapar en loop för menyn
        while (true)
        {
            // Rensar konsol och skriver ut meny
            Clear();
            WriteLine("Vad vill du göra?\n");
            WriteLine("1. Spara");
            WriteLine("2. Avsluta\n");

            // Efterfrågar inmatning
            Write("Välj ett alternativ (1-2): ");

            // Om inmatning är en siffra körs switch-satsen
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        SaveGame();
                        break;
                    case 2:
                        QuitGame();
                        break;
                    default:
                        Clear();
                        Write("\nOgiltigt alternativ! Tryck på valfri tangent...");
                        ReadKey();
                        break;
                }
            }
            // Om inmatning inte är en siffra skrivs felmeddelande ut
            else
            {
                Clear();
                Write("\nOgiltigt alternativ! Tryck på valfri tangent...");
                ReadKey();
            }
        }
    }

    /* 
    Statisk metod för att skapa en "skriv ut långsamt"-effekt på 
    konsolen genom att skriva ut varje tecken i textsträngen med 
    en fördröjning på 20 millisekunder mellan varje tecken.
    */
    public static void Print(string text)
    {
        foreach (char character in text)
        {
            Write(character);
            Thread.Sleep(20);
        }
    }
}