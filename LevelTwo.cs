internal class LevelTwo : Level
{
    // Konstruktor som körs när en instans av klassen "LevelOne" skapas
    public LevelTwo(string name)
    {
        // Sätter värde på den ärvda Name-egenskapen
        base.Name = name;
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en beskrivning
    public override void Descript()
    {
        WriteLine("I skogen finns det olika saker du kan göra för att ta dig närmare");
        WriteLine("lösningen på mysteriet med de mystiska skuggorna.\n");
    }

    // Metod för att implementera den ärvda abstrakta metoden och skriva ut en meny med olika val
    public override void TaskMenu()
    {
        // Skapar en loop som körs så länge spelarens level är 1
        while (Player.CurrentPlayer.Level == 1)
        {
            // Skapar ett lexikon av menyobjekt som lagras i en variabel
            var menuItems = new Dictionary<int, MenuItem>
            {
                /* 
                Varje menyobjekt associeras med en numerisk nyckel som motsvarar ett 
                menyalternativ. Varje instans av MenuItem har en beskrivning och en
                referens till en metod.
                */
                { 1, new MenuItem("Utforska det viskande trädet", ExploreWhisperingTree) },
                { 2, new MenuItem("Besöka trollkarlens stuga", VisitWizardsCottage) },
                { 3, new MenuItem("Utmana den smygande skuggan", ChallengeSneakyShadow) }
            };

            /*
            Anropar en klassmetod som tar tre argument: Level-namn, en referens till 
            metoden Descript och variabeln som lagrar lexikonet av menyobjekt.
            */
            LevelMenu.DisplayMenu(Name!, Descript, menuItems);
        }
    }

    // Statisk metod för att utforska det viskande trädet
    private static void ExploreWhisperingTree()
    {

    }

    // Statisk metod för att besöka trollkarlens stuga
    private static void VisitWizardsCottage()
    {
        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut information
            Clear();
            WriteLine("Du beslutar dig för att besöka trollkarlens stuga. När du närmar");
            WriteLine("dig öppnar trollkarlen dörren och hälsar dig välkommen. Han tittar");
            WriteLine("på dig med nyfikna ögon och undrar hur han kan stå till tjänst.\n");
            WriteLine("Vad vill du fråga trollkarlen?\n");
            WriteLine("1. Har du en läkande trolldryck som jag kan få?");
            WriteLine("2. Kan du hjälpa mig att slipa mitt svärd?");

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
                        WriteLine("Trollkarlen skrattar och säger att det är klart att han har en läkande");
                        WriteLine("trolldryck, men att inget är gratis här i världen. Om du kan svara");
                        Write("rätt på en gåta lovar han att ge dig en läkande trolldryck...");
                        ReadKey();

                        // Hämtar en slumpmässig gåta från Riddle-klassen
                        Riddle randomRiddle = Riddle.GetRandomRiddle();

                        // Rensar konsol, skriver ut gåta och efterfrågar svar
                        Clear();
                        WriteLine(randomRiddle.Text);
                        Write("\nSkriv ditt svar: ");

                        // Lagrar svaret som gemener i en variabel
                        string? answer = ReadLine()?.ToLower();

                        // Om svaret är korrekt uppdateras Potions med 1
                        if (randomRiddle.Answer == answer || randomRiddle.AnswerOpt == answer)
                        {
                            Player.CurrentPlayer.Potions += 1;
                            Clear();
                            WriteLine("Trollkarlen ler och säger att du har svarat rätt på gåtan! Du får en");
                            Write("läkande trolldryck precis som han har utlovat...");
                            ReadKey();
                        }
                        // Om svaret inte är korrekt skrivs meddelande ut
                        else
                        {
                            Clear();
                            WriteLine("Trollkarlen ser lite besviken ut och säger att det tyvärr inte var rätt");
                            Write("svar, men att du är välkommen åter om du vill göra ett nytt försök...");
                            ReadKey();
                        }

                        // validChoice sätts till true för att stoppa while-loopen
                        validChoice = true;
                        break;
                    case 2:
                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        WriteLine("Trollkarlen svarar att han kan hjälpa dig om du lyckas räkna ut");
                        Write("svaret på ett matematiskt tal...");
                        ReadKey();

                        // Genererar två slumpmässiga
                        int number1 = new Random().Next(1, 11);
                        int number2 = new Random().Next(1, 11);

                        // Så länge validOpt är false körs while-loopen
                        bool validOpt = false;
                        while (!validOpt)
                        {

                            // Rensar konsol, skriver ut tal och efterfrågar svar
                            Clear();
                            WriteLine($"Vad är {number1}*{number2}?");
                            Write("\nSkriv ditt svar: ");

                            // Om inmatningen är en siffra
                            if (int.TryParse(ReadLine(), out int result))
                            {
                                // Beräknar det korrekta svaret
                                int correctAnswer = number1 * number2;

                                // Om svaret är korrekt uppdateras WeaponStrenght med 1
                                if (result == correctAnswer)
                                {
                                    Player.CurrentPlayer.WeaponStrength += 1;
                                    Clear();
                                    WriteLine($"Trollkarlen säger att du är smart och att svaret {result} är rätt! Han");
                                    Write("hjälper dig att slipa ditt svärd, vilket ökar dess styrka...");
                                    ReadKey();
                                }
                                // Om svaret inte är korrekt skrivs meddelande ut
                                else
                                {
                                    Clear();
                                    WriteLine($"Trollkarlen ser lite besviken ut och säger att rätt svar är {correctAnswer}.");
                                    Write("Du svarade fel, men är välkommen åter för ett nytt försök...");
                                    ReadKey();
                                }

                                // validOpt sätts till true för att stoppa while-loopen
                                validOpt = true;
                            }
                            // Om inmatningen inte är en siffra skrivs felmeddelande ut
                            else
                            {
                                Game.WriteOptionErrorMessage();
                            }
                        }
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

    private static void ChallengeSneakyShadow()
    {

    }
}