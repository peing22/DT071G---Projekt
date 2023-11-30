internal class Riddle
{
    // Egenskaper av typen string som kan returnera värden
    public string? Text { get; }
    public string? Answer { get; }
    public string? AnswerOpt { get; }

    // Konstruktor som körs när en instans av klassen "Riddle" skapas
    public Riddle(string text, string answer, string answerOpt)
    {
        // Sätter värde för klassens egenskaper
        Text = text;
        Answer = answer;
        AnswerOpt = answerOpt;
    }

    // Statisk metod som returnerar en slumpmässigt vald gåta från en lista av gåtor
    public static Riddle GetRandomRiddle()
    {
        // Skapar och instansierar en lista av gåtor
        List<Riddle> riddles = new()
        {
            // Skapar gåtor med frågor, svar och alternativa svar
            new Riddle("Vad är det som är smittsamt, men som ingen är rädd för?", "skrattet", "ett skratt"),
            new Riddle("Vad blir blötare och blötare ju mer du torkar?", "handduken", "en handduk"),
            new Riddle("Vad går upp och ner utan att röra sig?", "trappan", "en trappa"),
            new Riddle("Vad kan gå, men inte springa?", "klockan", "en klocka"),
            new Riddle("Vad går över vatten utan att röra sig?", "bron", "en bro"),
            new Riddle("Vad går utan fötter?", "tiden", "tid"),
            new Riddle("Vad är det som kan sitta i ett hörn, men ändå åka jorden runt?", "frimärket", "ett frimärke"),
            new Riddle("Vad är det du har framför dig, men som du inte kan se?", "framtiden", "min framtid"),
            new Riddle("Vad har fyra ben på dagen, men sex ben på natten?", "sängen", "en säng"),
            new Riddle("Vad kommer i fyrkant, uppskattas i trekant men är en cirkel?", "pizzan", "en pizza"),
            new Riddle("Vad kan gå igenom fönsterrutan utan att den går sönder?", "ljuset", "ljus"),
            new Riddle("Vad är det som kan få dig att gråta fast du inte är ledsen?", "löken", "en lök"),
            new Riddle("Vilken råtta äter inte ost?", "dammråttan", "en dammråtta"),
            new Riddle("Vilken gris kan du stoppa in hel i munnen?", "polkagrisen", "en polkagris"),
            new Riddle("Vem går upp varje morgon utan att ha sovit en blund?", "solen", "en sol"),
            new Riddle("Vem är inte kunglig, men bär ändå krona?", "trädet", "ett träd"),
            new Riddle("Vem hör utan öron och talar utan mun, men svarar alltid?", "ekot", "ett eko"),
            new Riddle("På vilken sida av ett får är det mest ull?", "utsidan", "på utsidan")
        };

        // Returnerar en slumpmässig gåta från listan
        int randomIndex = new Random().Next(riddles.Count);
        return riddles[randomIndex];
    }
}