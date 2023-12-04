internal class LevelThree : Level
{
    // Skapar en fältvariabel med en instans av klassen "Random"
    private static readonly Random random = new();

    // Konstruktor som körs när en instans av klassen "LevelThree" skapas
    public LevelThree(string name)
    {
        // Sätter värde på den ärvda Name-egenskapen
        Name = name;
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en beskrivning
    public override void Descript()
    {
        WriteLine("Skogen har övergått i en ödemark där förlamande tystnad råder.");
        WriteLine("Eldrion har berättat att en härskande skugga rör sig i området");
        WriteLine("och att den slutliga lösningen på mysteriet med de mystiska");
        WriteLine("skuggorna kan finnas här.\n");
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en meny med olika val
    public override void TaskMenu(Player player)
    {
        // Skapar en loop som körs så länge spelarens level är 3
        while (player.Level == 3)
        {
            // Skapar ett lexikon av menyobjekt som lagras i en variabel
            var menuItems = new Dictionary<int, MenuItem>
            {
                /* 
                Varje menyobjekt associeras med en numerisk nyckel som motsvarar ett 
                menyalternativ. Varje instans av MenuItem har en beskrivning och en
                referens till en metod.
                */
                { 1, new MenuItem("Utforska ödemarkens källa", () => ExploreSpringOfWasteland(player)) },
                { 2, new MenuItem("Samla viktiga ledtrådar", () => CollectImportantClues(player)) },
                { 3, new MenuItem("Utmana den härskande skuggan", () => ChallengeRulingShadow(player)) }
            };

            /*
            Anropar klassmetod och skickar med Level-namn, aktuell spelare, en referens
            till metoden Descript och variabeln som lagrar lexikonet av menyobjekt.
            */
            LevelMenu.DisplayMenu(Name!, player, Descript, menuItems);
        }
    }

    // Statisk metod för att utforska ödemarkens källa
    private static void ExploreSpringOfWasteland(Player player)
    {
        // Om spelaren redan har fått sitt svärd uppdaterat
        if (player.WeaponStrength == 5)
        {
            // Rensar konsol och skriver ut meddelande
            Clear();
            Game.Print("Du har redan utforskat ödemarkens källa...");
            ReadKey();
        }
        // Om spelaren inte har fått sitt svärd uppdaterat rensas konsolen och meddelande skrivs ut
        else
        {
            Clear();
            Game.Print("Du beslutar dig för att utforska ödemarken och får ganska snabbt syn\n");
            Game.Print("på en spegelblank och guldskimrande källa som känns tilldragande...");
            ReadKey();
            Clear();
            Game.Print("När du tittar ner i källan ser du först bara din egen spegelbild...");
            ReadKey();
            Clear();
            Game.Print("Efter en stund märker du dock att din spegelbild skiljer sig från\n");
            Game.Print("verkligheten...");
            ReadKey();
            Clear();
            Game.Print("Trots att du står alldeles stilla med händerna utmed sidorna, ser du\n");
            Game.Print("dig själv dra fram ditt svärd och sänka ner det i källans vatten...");
            ReadKey();
            Clear();
            Game.Print("Du tar ett kliv tillbaka och inser att det du just såg var en illusion.\n");
            Game.Print("Samtidigt blir du nyfiken på vad som skulle hända om du sänkte ner ditt\n");
            Game.Print("svärd i den guldskimrande källan...");
            ReadKey();

            // Så länge validChoice är false körs while-loopen
            bool validChoice = false;
            while (!validChoice)
            {
                // Rensar konsol och skriver ut alternativ
                Clear();
                WriteLine("Vill du sänka ner ditt svärd i källan?\n");
                WriteLine("1. Ja");
                WriteLine("2. Nej");

                // Efterfrågar inmatning
                Write("\nVälj ett alternativ (1-2): ");

                // Om inmatningen är en siffra körs switch-satsen
                if (int.TryParse(ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Uppdaterar spelarens WeaponStrenght till 5
                            player.WeaponStrength = 5;
                            Clear();
                            Game.Print("Du sänker försiktigt ner svärdet i den guldskimrande källan och drar\n");
                            Game.Print("upp det igen. Svärdet lyser som guld, och du inser att källans kraft\n");
                            Game.Print("har gett svärdet dess optimala styrka...");
                            ReadKey();

                            // validChoice sätts till true för att stoppa while-loopen
                            validChoice = true;
                            break;
                        case 2:
                            // Rensar konsol och skriver ut meddelande
                            Clear();
                            Write("Du väljer att gå därifrån...");
                            ReadKey();

                            // validChoice sätts till true för att stoppa while-loopen
                            validChoice = true;
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
        }
    }

    // Statisk metod för att samla viktiga ledtrådar
    private static void CollectImportantClues(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("Genom rätt svar på gåtor och uträkningar av matematiska tal kan du\n");
        Game.Print("samla viktiga ledtrådar som ökar dina erfarenhetspoäng (XP)...");
        ReadKey();

        // Så länge validChoice är false och collectClues är true körs while-loopen
        bool validChoice = false;
        bool collectClues = true;
        while (!validChoice && collectClues)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine("---------------------------");
            Write(" XP-indikator ");
            player.XpIndicator();
            WriteLine("---------------------------\n");
            WriteLine("Vill du samla ledtrådar?\n");
            WriteLine("1. Ja");
            WriteLine("2. Nej");

            // Efterfrågar inmatning
            Write("\nVälj ett alternativ (1-2): ");

            // Om inmatningen är en siffra körs switch-satsen
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // Genererar ett slumpmässigt tal
                        int randomNumber = random.Next(0, 2);

                        // Om det slumpmässiga talet är 0 får spelaren en gåta
                        if (randomNumber == 0)
                        {
                            // Hämtar en slumpmässig gåta från Riddle-klassen
                            Riddle randomRiddle = Riddle.GetRandomRiddle();

                            // Så länge validInput är false körs while-loopen
                            bool validInput = false;
                            while (!validInput)
                            {
                                // Rensar konsol, skriver ut gåta och efterfrågar svar
                                Clear();
                                WriteLine($"{randomRiddle.Text}");
                                Write("\nSkriv ditt svar: ");

                                // Lagrar svaret som gemener i en variabel
                                string? answer = ReadLine()?.ToLower();

                                // Om svaret är null, tomt eller blanksteg skrivs felmeddelande ut och en ny iteration av loopan startar
                                if (string.IsNullOrWhiteSpace(answer))
                                {
                                    Game.WriteInputErrorMessage();
                                }
                                // Om svaret inte är null, tomt eller blanksteg och svaret är korrekt
                                else
                                {
                                    if (randomRiddle.Answer == answer || randomRiddle.AnswerOpt == answer)
                                    {
                                        // Genererar ett slumpmässigt tal, ökar spelarens XP och skriver ut meddelande
                                        int gainedXp = random.Next(5, 26);
                                        player.Xp += gainedXp;
                                        Clear();
                                        Write($"Rätt svar! Dina erfarenhetspoäng ökar med {gainedXp}...");
                                        ReadKey();
                                    }
                                    // Om svaret inte är korrekt skrivs meddelande ut
                                    else
                                    {
                                        Clear();
                                        Write("Ditt svar är tyvärr fel...");
                                        ReadKey();
                                    }
                                    // validInput sätts till true för att stoppa loopen
                                    validInput = true;
                                }
                            }
                        }
                        // Om det slumpmässiga talet inte är 0, det vill säga 1, får spelaren ett matematiskt tal
                        else
                        {
                            // Genererar två slumpmässiga tal
                            int number1 = random.Next(6, 10);
                            int number2 = random.Next(3, 10);

                            // Så länge validInput är false körs while-loopen
                            bool validInput = false;
                            while (!validInput)
                            {
                                // Rensar konsol, skriver ut tal och efterfrågar svar
                                Clear();
                                WriteLine($"Räkna ut produkten av {number1} * {number2}");
                                Write("\nSkriv ditt svar: ");

                                // Om svaret är en siffra
                                if (int.TryParse(ReadLine(), out int result))
                                {
                                    // Beräknar det korrekta svaret
                                    int correctAnswer = number1 * number2;

                                    // Om svaret är korrekt
                                    if (result == correctAnswer)
                                    {
                                        // Genererar ett slumpmässigt tal, ökar spelarens XP och skriver ut meddelande
                                        int gainedXp = random.Next(5, 26);
                                        player.Xp += gainedXp;
                                        Clear();
                                        Write($"Rätt svar! Dina erfarenhetspoäng ökar med {gainedXp}...");
                                        ReadKey();
                                    }
                                    // Om svaret inte är korrekt skrivs meddelande ut
                                    else
                                    {
                                        Clear();
                                        Write("Ditt svar är tyvärr fel...");
                                        ReadKey();
                                    }

                                    // validInput sätts till true för att stoppa while-loopen
                                    validInput = true;
                                }
                                // Om svaret inte är en siffra skrivs felmeddelande ut
                                else
                                {
                                    Game.WriteInputErrorMessage();
                                }
                            }
                        }
                        break;
                    case 2:
                        // collectClues sätts till false för att stoppa while-loopen
                        collectClues = false;
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
    }

    // Statisk metod för att utmana den härskande skuggan
    private static void ChallengeRulingShadow(Player player)
    {
        // Om XP är mindre än 100 kan den härskande skuggan inte utmanas
        if (player.Xp < 100)
        {
            // Rensar konsol och skriver ut meddelande
            Clear();
            Game.Print("Du har inte tillräckligt med erfarenhetspoäng för att kunna utmana\n");
            Game.Print("den härskande skuggan. Återkom när din XP-indikator är full...");
            ReadKey();
        }
        // Om XP är större eller lika med 100
        else
        {
            // Rensar konsol och skriver ut meddelande
            Clear();
            Game.Print("Du känner dig redo att utmana den härskande skuggan och går segerviss rakt\n");
            Game.Print("emot den...");
            ReadKey();
            Clear();
            Game.Print($"Den härskande skuggan, som ser dig komma med ditt blänkande svärd i luften,\n");
            Game.Print("tornar upp sig som ett ändlöst mörker framför dig...");
            ReadKey();

            // Skapar en instans av klassen "Creature"
            Creature rulingShadow = new("Härskande skuggan", 15, 8, 0);

            // Anropar metod för att starta strid
            Battle.StartBattle(player, rulingShadow);
        }
    }
}