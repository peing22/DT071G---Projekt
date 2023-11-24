// Importerar klass för att slippa upprepa "Console".
using static System.Console;

// Rensar konsol och lagrar en ASCII-designad textsträng i en variabel
Clear();
string title = @"
        
    ███      ▄█      ███        ▄████████  ▄█       
▀█████████▄ ███  ▀█████████▄   ███    ███ ███       
   ▀███▀▀██ ███▌    ▀███▀▀██   ███    █▀  ███       
    ███   ▀ ███▌     ███   ▀  ▄███▄▄▄     ███       
    ███     ███▌     ███     ▀▀███▀▀▀     ███       
    ███     ███      ███       ███    █▄  ███       
    ███     ███      ███       ███    ███ ███▌    ▄ 
   ▄████▀   █▀      ▄████▀     ██████████ █████▄▄██ 
                                          ▀         
        ";

// Ändrar förgrundsfärg i konsol, skriver ut textsträng och återställer förgrundsfärg
ForegroundColor = ConsoleColor.DarkMagenta;
WriteLine(title);
ResetColor();

// Ber användaren trycka på valfri tangent för att komma vidare
Game.Print("  Välkommen till Titel! Tryck på valfri tangent...");
ReadKey();

// Skapar en loop som håller gränssnittet igång tills programmet avslutas
while (true)
{
    // Rensar konsol och skriver ut meny
    Clear();
    WriteLine("Vad vill du göra?\n");
    WriteLine("1. Starta ett nytt spel");
    WriteLine("2. Ladda ett sparat spel");
    WriteLine("3. Avsluta programmet\n");

    // Efterfrågar inmatning
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
                Clear();
                Game.Quit();
                break;
            default:
                Clear();
                Game.Print("\nOgiltigt alternativ! Tryck på valfri tangent...");
                ReadKey();
                break;
        }
    }
    // Om inmatning inte är en siffra skrivs felmeddelande ut
    else
    {
        Clear();
        Game.Print("\nOgiltigt alternativ! Tryck på valfri tangent...");
        ReadKey();
    }
}