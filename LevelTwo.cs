internal class LevelTwo : Level
{
    // Konstruktor som körs när en instans av klassen "LevelTwo" skapas
    public LevelTwo(string name)
    {
        // Sätter värde på den ärvda Name-egenskapen
        Name = name;
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en beskrivning
    public override void Descript()
    {
        WriteLine("Du har kommit fram till ruinerna av en forntida stad, gömd djupt");
        WriteLine("inne i skogen. Spöklika skuggor dansar bland de gamla stenarna,");
        WriteLine("och du förstår att ruinerna bär på hemligheter som kan ta dig");
        WriteLine("närmare lösningen på mysteriet med de mystiska skuggorna.\n");
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en meny med olika val
    public override void TaskMenu(Player player)
    {
        // Skapar en loop som körs så länge spelarens level är 2
        while (player.Level == 2)
        {
            // Skapar ett lexikon av menyobjekt som lagras i en variabel
            var menuItems = new Dictionary<int, MenuItem>
            {
                /* 
                Varje menyobjekt associeras med en numerisk nyckel som motsvarar ett 
                menyalternativ. Varje instans av MenuItem har en beskrivning och en
                referens till en metod.
                */
                { 1, new MenuItem("Besöka den forntida smedjan", () => VisitAncientForge(player)) },
                { 2, new MenuItem("Granska ruinernas inskriptioner", () => ExamineTheInscriptions(player)) },
                { 3, new MenuItem("Utforska det gamla apoteket", () => ExploreTheOldPharmacy(player)) },
                { 4, new MenuItem("Utmana den spöklika skuggan", () => ChallengeGhostlyShadow(player)) }
            };

            /*
            Anropar klassmetod och skickar med Level-namn, aktuell spelare, en referens
            till metoden Descript och variabeln som lagrar lexikonet av menyobjekt.
            */
            LevelMenu.DisplayMenu(Name!, player, Descript, menuItems);
        }
    }

    // Statisk metod för att besöka den forntida smedjan
    private static void VisitAncientForge(Player player)
    {
        // Om spelaren redan har fått sitt svärd slipat
        if (player.WeaponStrength == 3)
        {
            // Rensar konsol och skriver ut meddelande
            Clear();
            Game.Print("Du har redan fått hjälp med ditt svärd och Vendela är inte längre kvar...");
            ReadKey();
        }
        // Om spelaren inte har fått sitt svärd slipat rensas konsolen och meddelande skrivs ut
        else
        {
            Clear();
            Game.Print("Du har lagt märke till något som liknar en gammal smedja bland ruinerna\n");
            Game.Print("och bestämmer dig för att gå dit...");
            ReadKey();
            Clear();
            Game.Print("När du närmar dig får du syn på en liten figur som ser ut att leta efter\n");
            Game.Print("något. Den lilla figuren presenterar sig som Vendela och berättar att hon\n");
            Game.Print("arbetade som smed i staden innan de mystiska skuggorna dök upp...");
            ReadKey();
            Clear();
            Game.Print("Du frågar Vendela om hon letar efter något. Hon svarar att hon försöker leta\n");
            Game.Print("rätt på sina verktyg som blivit kvar i ruinerna, men att det enda hon har\n");
            Game.Print("hittat är den gamla slipmaskinen...");
            ReadKey();
            Clear();
            Game.Print("Du ser din chans att få hjälp med ditt rostiga svärd och frågar Vendela om\n");
            Game.Print("hon har möjlighet att slipa det åt dig...");
            ReadKey();
            Clear();
            Game.Print("Vendela ler och säger att hon kan slipa ditt svärd om du lyckas räkna ut\n");
            Game.Print("svaret på ett matematiskt tal...");
            ReadKey();

            // Så länge validChoice är false körs while-loopen
            bool validChoice = false;
            while (!validChoice)
            {
                // Rensar konsol och skriver ut alternativ
                Clear();
                WriteLine("Vill du räkna ut ett tal?\n");
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
                            // Genererar två slumpmässiga tal
                            int number1 = new Random().Next(6, 10);
                            int number2 = new Random().Next(3, 10);

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

                                    // Om svaret är korrekt uppdateras WeaponStrenght till 3
                                    if (result == correctAnswer)
                                    {
                                        player.WeaponStrength = 3;
                                        Clear();
                                        Game.Print($"Vendela säger att du är smart och att svaret {result} är rätt! Hon\n");
                                        Game.Print("hjälper dig att slipa ditt svärd, vilket ökar dess styrka...");
                                        ReadKey();
                                    }
                                    // Om svaret inte är korrekt skrivs meddelande ut
                                    else
                                    {
                                        Clear();
                                        Game.Print($"Vendela ser lite besviken ut och säger att rätt svar är {correctAnswer}.\n");
                                        Game.Print("Du svarade fel, men är välkommen åter för ett nytt försök...");
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
                            // validChoice sätts till true för att stoppa while-loopen
                            validChoice = true;
                            break;
                        case 2:
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

    // Statisk metod för att granska ruinernas inskriptioner
    private static void ExamineTheInscriptions(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("När du tittar närmare på ruinerna ser du inskriptioner i vissa stenar.\n");
        Game.Print("Det verkar vara ledtrådar om de mystiska skuggorna...");
        ReadKey();

        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine("Vill du studera inskriptionerna en stund?\n");
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
                        // Genererar ett slumpmässigt tal och ökar spelarens XP
                        int gainedXp = new Random().Next(10, 21);
                        player.Xp += gainedXp;

                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        Game.Print("Du studerar inskriptionerna noggrant och hittar ledtrådar om hur du ska kunna\n");
                        Game.Print($"lösa skuggornas mysterium. Dina erfarenhetspoäng (XP) ökar med {gainedXp}...");
                        ReadKey();

                        // validChoice sätts till true för att stoppa while-loopen
                        validChoice = true;
                        break;
                    case 2:
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

    // Statisk metod för att utforska det gamla apotekets ruiner
    private static void ExploreTheOldPharmacy(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("När du går omkring bland ruinerna får du syn på något som liknar\n");
        Game.Print("ett gammalt apotek...");
        ReadKey();
        Clear();
        Game.Print("På marken hittar du flaskor som påminner om den flaska med läkande\n");
        Game.Print("trolldryck som du fick av Eldrion vid stenporten...");
        ReadKey();
        Clear();
        Game.Print("Du letar igenom flaskorna noggrant och blir glad när du inser att\n");
        Game.Print("en av dem är en läkande trolldryck! Du stoppar den i fickan och\n");
        Game.Print("tänker att den kan komma till god användning...");
        ReadKey();

        // Spelarens Potions ökas med 1
        player.Potions += 1;
    }

    // Statisk metod för att utmana den spöklika skuggan
    private static void ChallengeGhostlyShadow(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("Under din vistelse bland ruinerna har du lagt extra märke till\n");
        Game.Print("en spöklik skugga som inte verkar uppskatta din närvaro...");
        ReadKey();

        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine($"Vill du utmana den spöklika skuggan?\n");
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
                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        Game.Print("Du känner dig modig, drar fram ditt svärd och går med bestämda steg fram\n");
                        Game.Print("till din motståndare som ställer sig i stridsposition...");
                        ReadKey();

                        // Skapar en instans av klassen "Creature"
                        Creature ghostlyShadow = new("Spöklika skuggan", 8, 4, 90);

                        // Anropar metod för att starta strid
                        Battle.StartBattle(player, ghostlyShadow);

                        // validChoice sätts till true för att stoppa while-loopen
                        validChoice = true;
                        break;
                    case 2:
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