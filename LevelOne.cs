// Importerar klass för att slippa upprepa "Console"
using static System.Console;

// Intern klass som ärver från den abstrakta klassen "Level"
internal class LevelOne : Level
{
    // Konstruktor som körs när en instans av klassen "LevelOne" skapas
    public LevelOne(string name)
    {
        // Sätter värde på Name-egenskapen
        base.Name = name;
    }

    // Metod för att implementera den abstrakta metoden och skriva ut en beskrivning
    public override void Descript()
    {
        Game.Print("Du befinner dig vid stenporten där du möter du den mystiska figuren Eldrion,\n");
        Game.Print("väktaren av skogen. Han berättar att skogen har förändrats den senaste tiden\n");
        Game.Print("och att han inte vet hur han ska kunna återställa balansen.\n\n");
        Game.Print("Eldrion ber dig om hjälp att lösa mysteriet med de märkliga skuggorna. Han ger\n");
        Game.Print("dig ett svärd och fem flaskor läkande trolldryck som skydd på vägen...");
    }

    // Metod för att implementera den abstrakta metoden och skriva ut en meny med olika uppgifter
    public override void TaskMenu()
    {
        // Skapar en loop som körs så länge level är 1
        while (Player.CurrentPlayer.Level == 1)
        {
            // Rensar konsol och skriver ut rubrik, XP-indikator och meny
            Clear();
            WriteLine("-----------------------------------------------------------------");
            Write($" {Name}         XP-indikator ");
            Player.CurrentPlayer.ProgressBar();
            WriteLine("-----------------------------------------------------------------\n");
            WriteLine("I skogen finns det olika saker du kan göra för att ta dig närmare");
            WriteLine("lösningen på mysteriet med de mystiska skuggorna.\n");
            WriteLine("1. Utforska det viskande trädet");
            WriteLine("2. Besök trollkarlens stuga");
            WriteLine("3. Utmana den smygande skuggan");
            WriteLine("4. Drick en läkande trolldryck");
            WriteLine("5. Se aktuell status");
            WriteLine("6. Spara spelet");
            WriteLine("7. Avsluta\n");

            // Efterfrågar inmatning
            Write("Välj ett alternativ (1-7): ");

            // Om inmatning är en siffra körs switch-satsen
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ExploreWhisperingTree();
                        break;
                    case 2:
                        VisitWizardsCottage();
                        break;
                    case 3:
                        ChallengeSneakyShadow();
                        break;
                    case 4:
                        Player.CurrentPlayer.DrinkPotion();
                        break;
                    case 5:
                        Player.CurrentPlayer.PlayerStatus();
                        break;
                    case 6:
                        Game.SaveGame();
                        break;
                    case 7:
                        Game.QuitGame();
                        break;
                    default:
                        Clear();
                        Write("Ogiltigt alternativ! Tryck på valfri tangent...");
                        ReadKey();
                        break;
                }
            }
            // Om inmatning inte är en siffra skrivs felmeddelande ut
            else
            {
                Clear();
                Write("Ogiltigt alternativ! Tryck på valfri tangent...");
                ReadKey();
            }

            // Om spelaren kan nå nästa level
            if (Player.CurrentPlayer.CanLevelUp())
            {
                // Anropar metod för att öka spelarens level
                Player.CurrentPlayer.LevelUp();
            }
        }
    }

    // Statisk metod för att utforska det viskande trädet
    private static void ExploreWhisperingTree()
    {
        bool isChoiceValid = false;
        while (!isChoiceValid)
        {
            // Rensar konsol och skriver ut information
            Clear();
            WriteLine("Du närmar dig det viskande trädet och hör att det på något märkligt");
            WriteLine("sätt uttalar ord som du kan förstå, med ledtrådar om skuggorna.\n");
            WriteLine("Vill du gå fram och lyssna på det viskande trädet?\n");
            WriteLine("1. Ja");
            WriteLine("2. Nej");

            // Efterfrågar inmatning
            Write("\nVälj ett alternativ (1-2): ");

            // Om inmatning är en siffra körs switch-satsen
            if (int.TryParse(ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // isChoiceValid sätts till true för att stoppa while-loopen
                        isChoiceValid = true;

                        // Genererar ett random tal och ökar spelarens XP
                        int gainedXp = new Random().Next(10, 20);
                        Player.CurrentPlayer.Xp += gainedXp;

                        // Rensar konsol och skriver ut meddelande
                        Clear();
                        WriteLine("Du lyssnar uppmärksamt på det viskande trädet som berättar viktiga");
                        WriteLine("saker gällande mysteriet med de märkliga skuggorna.\n");
                        Write($"Dina erfarenhetspoäng (XP) ökar med {gainedXp}...");
                        ReadKey();
                        break;
                    case 2:
                        // isChoiceValid sätts till true för att stoppa while-loopen
                        isChoiceValid = true;
                        break;
                    default:
                        Clear();
                        Write("Ogiltigt alternativ! Tryck på valfri tangent...");
                        ReadKey();
                        break;
                }
            }
            // Om inmatning inte är en siffra skrivs felmeddelande ut
            else
            {
                Clear();
                Write("Ogiltigt alternativ! Tryck på valfri tangent...");
                ReadKey();
            }
        }
    }

    private static void VisitWizardsCottage()
    {
        // Implementera logiken för att besöka trollkarlens stuga här
        // Svara rätt på en gåta för möjlighet att få en läkande trolldryck
    }

    private static void ChallengeSneakyShadow()
    {
        // Implementera logiken för att utmana den smygande skuggan här
        // En fight med varelsen som kan skada hälsan och öka XP vid seger
    }
}