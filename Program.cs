// Importerar klass för att slippa upprepa "Console"
using static System.Console;

// Rensar konsol och lagrar en ASCII-designad textsträng i en variabel
Clear();
string title = @"
   ██████  ██ ▄█▀ █    ██   ▄████   ▄████  ▒█████   ██▀███   ███▄    █  ▄▄▄        ██████    
 ▒██    ▒  ██▄█▒  ██  ▓██▒ ██▒ ▀█▒ ██▒ ▀█▒▒██▒  ██▒▓██ ▒ ██▒ ██ ▀█   █ ▒████▄    ▒██    ▒    
 ░ ▓██▄   ▓███▄░ ▓██  ▒██░▒██░▄▄▄░▒██░▄▄▄░▒██░  ██▒▓██ ░▄█ ▒▓██  ▀█ ██▒▒██  ▀█▄  ░ ▓██▄      
   ▒   ██▒▓██ █▄ ▓▓█  ░██░░▓█  ██▓░▓█  ██▓▒██   ██░▒██▀▀█▄  ▓██▒  ▐▌██▒░██▄▄▄▄██   ▒   ██▒   
 ▒██████▒▒▒██▒ █▄▒▒█████▓ ░▒▓███▀▒░▒▓███▀▒░ ████▓▒░░██▓ ▒██▒▒██░   ▓██░ ▓█   ▓██▒▒██████▒▒   
 ▒ ▒▓▒ ▒ ░▒ ▒▒ ▓▒ ▒▓▒ ▒ ▒  ░▒   ▒  ░▒   ▒ ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░ ▒░   ▒ ▒  ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░   
 ░ ░▒  ░ ░  ░▒ ▒  ░▒░ ░ ░   ░   ░   ░   ░   ░ ▒ ▒░   ░▒ ░ ▒░░ ░░   ░ ▒░  ▒   ▒▒ ░  ░▒  ░ ░   
    ░  ░    ░  ░  ░     ░   ░       ░         ░ ▒    ░░   ░    ░     ░   ░   ▒      ░  ░        
                                                                                             
        ███▄ ▄███▒▒██   ██▓  ██████ ▄▄▄█████▒▒█████  ██▀███   ██▓ █    ██  ███▄ ▄███▓        
       ▓██▒▀█▀ ██▒ ▒██  ██▒▒██    ▒ ▓  ██▒ ▓░▒█   ▀ ▓██ ▒ ██▒▓██▒ ██  ▓██▒▓██▒▀█▀ ██▒        
       ▓██    ▓██░  ▒██ ██░░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒▒██▒▓██  ▒██░▓██    ▓██░        
       ▒██    ▒██   ░ ▐██▒░  ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  ░██░▓▓█  ░██░▒██    ▒██         
       ▒██▒   ░██▒  ░ ██▒░░▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒░██░▒▒█████▓ ▒██▒   ░██▒        
       ░ ▒░   ░  ░   ██░░  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░░▓  ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░        
       ░  ░      ░ ▓██ ░   ░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░ ▒   ░▒░ ░ ░ ░  ░   ░          
                   ░ ▒        ░  ░    ░         ░     ░    ░  ▒    ░      ░                        
        ";

// Ändrar förgrundsfärg i konsol, skriver ut textsträng och återställer förgrundsfärg
ForegroundColor = ConsoleColor.DarkGray;
WriteLine(title);
ResetColor();

// Ber användaren trycka på valfri tangent för att komma vidare
Write("                       Tryck på valfri tangent för att starta spelet...");
ReadKey();

// Skapar en ny instans av klassen "Game" för att konstruktorn ska köras
Game game = new();

// Skapar en loop för startmenyn
while (true)
{
    // Rensar konsol, skriver ut startmeny och efterfrågar inmatning
    Clear();
    WriteLine("-----------------------------");
    WriteLine("       S P E L M E N Y       ");
    WriteLine("-----------------------------\n");
    WriteLine("1. Starta nytt spel");
    WriteLine("2. Ladda sparat spel");
    WriteLine("3. Avsluta\n");
    Write("Välj ett alternativ (1-3): ");

    // Om inmatning är en siffra körs switch-satsen
    if (int.TryParse(ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Game.NewGame();
                break;
            case 2:
                Game.LoadGame();
                break;
            case 3:
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
}