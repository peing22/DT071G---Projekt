internal class LevelOne : Level
{
    // Konstruktor som körs när en instans av klassen "LevelOne" skapas
    public LevelOne(string name)
    {
        // Sätter värde på den ärvda Name-egenskapen
        Name = name;
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en beskrivning
    public override void Descript()
    {
        WriteLine("I skogen finns det olika saker du kan göra för att ta dig närmare");
        WriteLine("lösningen på mysteriet med de mystiska skuggorna.\n");
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en meny med olika val
    public override void TaskMenu(Player player)
    {
        // Skapar en loop som körs så länge spelarens level är 1
        while (player.Level == 1)
        {
            // Skapar ett lexikon av menyobjekt som lagras i en variabel
            var menuItems = new Dictionary<int, MenuItem>
            {
                /* 
                Varje menyobjekt associeras med en numerisk nyckel som motsvarar ett 
                menyalternativ. Varje instans av MenuItem har en beskrivning och en
                referens till en metod.
                */
                { 1, new MenuItem("Utforska det viskande trädet", () => ExploreWhisperingTree(player)) },
                { 2, new MenuItem("Besöka trollkarlens stuga", () => VisitWizardsCottage(player)) },
                { 3, new MenuItem("Utmana den smygande skuggan", () => ChallengeSneakyShadow(player)) }
            };

            /*
            Anropar klassmetod och skickar med Level-namn, aktuell spelare, en referens
            till metoden Descript och variabeln som lagrar lexikonet av menyobjekt.
            */
            LevelMenu.DisplayMenu(Name!, player, Descript, menuItems);
        }
    }

    // Statisk metod för att utforska det viskande trädet
    private static void ExploreWhisperingTree(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("Du närmar dig det viskande trädet och hör att det på något märkligt\n");
        Game.Print("sätt uttalar ord som du kan förstå, med ledtrådar om skuggorna...");
        ReadKey();

        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine("Vill du stanna och lyssna till det viskande trädet?\n");
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
                        int gainedXp = new Random().Next(20, 31);
                        player.Xp += gainedXp;

                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        Game.Print("Du lyssnar uppmärksamt och får ledtrådar om hur du ska kunna lösa\n");
                        Game.Print($"skuggornas mysterium. Dina erfarenhetspoäng (XP) ökar med {gainedXp}...");
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

    // Statisk metod för att besöka trollkarlens stuga
    private static void VisitWizardsCottage(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("Du beslutar dig för att besöka trollkarlens stuga. När du närmar\n");
        Game.Print("dig öppnar trollkarlen dörren och hälsar dig välkommen. Han tittar\n");
        Game.Print("på dig med nyfikna ögon och undrar hur han kan stå till tjänst...");
        ReadKey();
        Clear();
        Game.Print("Du frågar om trollkarlen har någon läkande trolldryck som han kan\n");
        Game.Print("tänka sig att ge till dig...");
        ReadKey();
        Clear();
        Game.Print("Trollkarlen skrattar och säger att han har många olika trolldrycker\n");
        Game.Print("i sin stuga. Han lovar att ge dig en läkande trolldryck om du kan\n");
        Game.Print("svara rätt på en av hans gåtor...");
        ReadKey();

        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine("Vill du svara på en gåta?\n");
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
                            // Om svaret inte är null, tomt eller blanksteg och svaret är korrekt ökas Potions med 1 och meddelande skrivs ut
                            else
                            {
                                if (randomRiddle.Answer == answer || randomRiddle.AnswerOpt == answer)
                                {
                                    player.Potions += 1;
                                    Clear();
                                    Game.Print("Trollkarlen ler och säger att du har svarat rätt på gåtan!\n");
                                    Game.Print("Han ger dig en läkande trolldryck precis som utlovat...");
                                    ReadKey();
                                }
                                // Om svaret inte är korrekt skrivs meddelande ut
                                else
                                {
                                    Clear();
                                    Game.Print("Trollkarlen ser lite besviken ut och säger att det tyvärr inte var rätt\n");
                                    Game.Print("svar, men att du är välkommen åter om du vill göra ett nytt försök...");
                                    ReadKey();
                                }
                                // validInput sätts till true för att stoppa loopen
                                validInput = true;
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

    // Statisk metod för att utmana den smygande skuggan
    private static void ChallengeSneakyShadow(Player player)
    {
        // Rensar konsol och skriver ut meddelande
        Clear();
        Game.Print("Under din vistelse i skogen har du lagt märke till att det smyger\n");
        Game.Print("omkring en mystisk skugga bland träden...");
        ReadKey();
        Clear();
        Game.Print($"När du närmar dig den smygande skuggan märker du att den blir hotfull,\n");
        Game.Print("som att den tänker gå till attack om du kommer för nära...");
        ReadKey();

        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut alternativ
            Clear();
            WriteLine($"Vill du utmana den smygande skuggan?\n");
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
                        Game.Print("till din motståndare som väser hotfullt och gör sig redo för strid...");
                        ReadKey();

                        // Skapar en instans av klassen "Creature"
                        Creature sneakyShadow = new("Smygande skuggan", 5, 1, 80);

                        // Anropar metod för att starta strid
                        Battle.StartBattle(player, sneakyShadow);

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