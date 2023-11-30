// Importerar namespace för att hantera konvertering mellan JSON och objekt
using System.Text.Json;

internal class Game
{
    // Skapar en statisk lista av Player-objekt
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
        // Så länge validInput är false körs while-loopen
        bool validInput = false;
        while (!validInput)
        {
            // Rensar konsol, efterfrågar namn och sparar värde i variabel
            Clear();
            Write("Ge din spelkaraktär ett namn: ");
            string? name = ReadLine();

            // Om namn är null, tomt eller blanksteg skrivs felmeddelande ut och en ny iteration av loopan startar
            if (string.IsNullOrWhiteSpace(name))
            {
                Clear();
                Write("Ogiltigt namn! Tryck på valfri tangent...");
                ReadKey();
            }
            // Om namn är korrekt angivet skapas ett id och värden sätts för spelarens egenskaper
            else
            {
                int id = Players.Count + 1;
                Player.CurrentPlayer.SetPlayerValues(id, name, 1, 0, 10, 1, 1);

                // validInput sätts till true för att stoppa loopen
                validInput = true;

                // Rensar konsol och skriver ut inledande story med metod för "skriv ut långsamt"-effekt
                Clear();
                Print("Du vaknar upp i en dimmig skog och har ingen aning om hur du hamnade där,\n");
                Print($"men du kommer åtminstone ihåg att du heter {Player.CurrentPlayer.Name}.\n\n");
                Print("En svag röst hörs i vinden och uppmanar dig att följa stigen framåt...");
                ReadKey();
                Clear();
                Print("Efter att ha vandrat en stund genom den dimmiga skogen, når du en gammal\n");
                Print("stenport. Porten öppnas långsamt när du närmar dig, och du stiger in i en\n");
                Print("värld där skuggorna tycks leva sitt eget liv...");
                ReadKey();
                Clear();
                Print("Vid stenporten möter du den mystiska figuren Eldrion, väktaren av skogen.\n");
                Print("Han berättar att skogen har förändrats den senaste tiden och att han inte\n");
                Print("vet hur han ska kunna bli av med de mystiska skuggorna.\n\n");
                Print("Eldrion ber dig om hjälp att lösa mysteriet. Han ger dig ett rostigt svärd\n");
                Print("och en flaska läkande trolldryck som skydd på vägen...");
                ReadKey();
                Clear();
                Print("Din uppgift är att utforska denna mystiska värld, avslöja dess hemligheter\n");
                Print("och övervinna de faror som lurar i skuggorna. Du kommer att stöta på olika\n");
                Print("varelser och samla erfarenhetspoäng (XP) för att öka i level...");
                ReadKey();

                // Anropar metod
                PlayGame();
            }
        }
    }

    // Statisk metod för att ladda ett sparat spel
    public static void LoadGame()
    {
        // Rensar konsol och om antalet sparade spel är noll skrivs meddelande ut
        Clear();
        if (Players.Count == 0)
        {
            Write("Det finns inga sparade spel...");
            ReadKey();
        }
        // Om antalet spelare inte är noll körs while-loopen så länge validChoiceOrCancel är false
        else
        {
            bool validChoiceOrCancel = false;
            while (!validChoiceOrCancel)
            {
                // Rensar konsol, skriver ut alternativ och efterfrågar inmatning
                Clear();
                WriteLine("----------------------------");
                WriteLine("   S P A R A D E  S P E L   ");
                WriteLine("----------------------------\n");
                for (int i = 0; i < Players.Count; i++)
                {
                    WriteLine($"{i + 1}. {Players[i].Name} (level {Players[i].Level})");
                }
                WriteLine($"{Players.Count + 1}. Avbryt\n");
                Write($"Välj ett alternativ (1-{Players.Count + 1}): ");

                // Om inmatning inte är ett korrekt alternativ skrivs felmeddelande ut
                if (!int.TryParse(ReadLine(), out int choice) || choice < 1 || choice > Players.Count + 1)
                {
                    WriteOptionErrorMessage();
                }
                // Om inmatning är ett korrekt alternativ och om valet är ett sparat spel
                else
                {
                    if (choice <= Players.Count)
                    {
                        // Uppdaterar CurrentPlayer med vald spelare
                        Player.CurrentPlayer = Players[choice - 1];

                        // validChoiceOrCancel sätts till true för att stoppa loopen
                        validChoiceOrCancel = true;

                        // Anropar metod
                        PlayGame();
                    }
                    // Om valet är att avbryta sätts validChoiceOrCancel till true för att stoppa loopen
                    else
                    {
                        validChoiceOrCancel = true;
                    }
                }
            }
        }
    }

    // Statisk metod för att spela den level spelaren är på
    public static void PlayGame()
    {
        // Skapar en variabel och en loop som håller igång aktuellt spel så länge activeGame är true
        bool activeGame = true;
        while (activeGame)
        {
            // Lagrar aktuell level i en variabel
            int currentLevel = Player.CurrentPlayer.Level;

            // Kör kodblock utifrån spelarens level
            switch (currentLevel)
            {
                case 1:
                    // Skapar en ny instans av klassen "LevelOne" och skickar med namn som parameter
                    LevelOne levelOne = new("Level 1 - Skogens hemligheter");

                    // Skriver ut spelarstatus
                    Player.CurrentPlayer.PlayerStatus();

                    // Anropar klass-metod
                    levelOne.TaskMenu();
                    break;
                case 2:
                    Clear();
                    Write("Level 2...");
                    ReadKey();
                    break;
                case 3:
                    Clear();
                    Write("Level 3...");
                    ReadKey();
                    break;
                case 4:
                    Clear();
                    Write("Level 4...");
                    ReadKey();
                    break;
                case 100:
                    activeGame = false;
                    break;
            }
        }
    }

    // Statisk metod för att spara ett spel
    public static void SaveGame()
    {
        // Om aktuell spelare redan existerar i listan med spelare, ersätts den befintliga instansen
        var existingPlayer = Players.Find(player => player.Id == Player.CurrentPlayer.Id);
        if (existingPlayer != null)
        {
            Players[Players.IndexOf(existingPlayer)] = Player.CurrentPlayer;
        }
        // Om aktuell spelare inte existerar adderas insatsen till listan med spelare
        else
        {
            Players.Add(Player.CurrentPlayer);
        }

        // Serialiserar listan med spelare till en JSON-sträng och sparar den till en JSON-fil
        string json = JsonSerializer.Serialize(Players);
        File.WriteAllText("savedgames.json", json);

        // Rensar konsol och skriver ut meddelande
        Clear();
        Write("Spelet har sparats...");
        ReadKey();
    }

    // Statisk metod för att avsluta aktuellt spel
    public static void QuitGame()
    {
        // Sätter level till 100 för att stoppa loopen som håller igång aktuellt spel
        Player.CurrentPlayer.Level = 100;
        Clear();
        Write("Spelet har avslutats...");
        ReadKey();
    }

    // Statisk metod för att skriva ut felmeddelande
    public static void WriteOptionErrorMessage()
    {
        Clear();
        Write("Ogiltigt alternativ! Gör ett nytt försök...");
        ReadKey();
    }

    // Statisk metod för att skapa en "skriv ut långsamt"-effekt på konsolen
    public static void Print(string text)
    {
        // Skriver ut varje varje bokstav i medskickad textsträng med en fördröjning på 20 millisekunder
        foreach (char character in text)
        {
            Write(character);
            Thread.Sleep(20);
        }
    }
}