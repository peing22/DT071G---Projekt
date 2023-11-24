// Importerar klass för att slippa upprepa "Console".
using static System.Console;

internal class Game
{
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

    // Statisk metod för att starta ett nytt spel
    public static void NewGame()
    {
        Clear();
        Print("Nytt spel startas...");
        ReadKey();
    }

    // Metod för att spara ett spel


    // Statisk metod för att ladda ett spel
    public static void LoadGame()
    {
        Clear();
        Player.CurrentPlayer.Name = "Robert";
        Player.CurrentPlayer.Id = 1;
        Print($"ID {Player.CurrentPlayer.Id} - {Player.CurrentPlayer.Name}...");
        ReadKey();
    }

    // Statisk metod för att avsluta programmet
    public static void Quit()
    {
        Environment.Exit(0);
    }
}