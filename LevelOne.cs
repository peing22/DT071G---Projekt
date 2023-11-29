internal class LevelOne : Level
{
    // Konstruktor som körs när en instans av klassen "LevelOne" skapas
    public LevelOne(string name)
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
        // Så länge validChoice är false körs while-loopen
        bool validChoice = false;
        while (!validChoice)
        {
            // Rensar konsol och skriver ut information
            Clear();
            WriteLine("Du närmar dig det viskande trädet och hör att det på något märkligt");
            WriteLine("sätt uttalar ord som du kan förstå, med ledtrådar om skuggorna.\n");
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
                        // Genererar ett slumpmässigt tal från 10 till 20 och ökar spelarens XP
                        int gainedXp = new Random().Next(10, 21);
                        Player.CurrentPlayer.Xp += gainedXp;

                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        WriteLine("Du lyssnar uppmärksamt och får ledtrådar om hur du ska kunna lösa");
                        Write($"skuggornas mysterium. Dina erfarenhetspoäng (XP) ökar med {gainedXp}...");
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

    private static void VisitWizardsCottage()
    {
        // Implementera logiken för att besöka trollkarlens stuga här
        // Svara rätt på en gåta för möjlighet att få en läkande trolldryck, räkna ut ett tal så slipar trollkarlen svärdet
    }

    private static void ChallengeSneakyShadow()
    {
        // Implementera logiken för att utmana den smygande skuggan här
        // En fight med varelsen som kan skada hälsan och öka XP vid seger
        // Skapa en egen klass för varelser med namn (smygande skuggan), hälsa (3), vapen (laserblick), vapenstyrka (1)...
    }
}