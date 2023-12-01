internal class LevelTwo : Level
{
    // Konstruktor som körs när en instans av klassen "LevelTwo" skapas
    public LevelTwo(string name)
    {
        // Sätter värde på den ärvda Name-egenskapen
        base.Name = name;
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
                { 3, new MenuItem("Utforska det gamla apotekets ruiner", () => ExploreTheOldPharmacy(player)) },
                { 4, new MenuItem("Utmana den spöklika skuggan", () => ChallengeGhostlyShadow(player)) }
            };

            /*
            Anropar klassmetod och skickar med argumenten Level-namn, spelaren, en referens
            till metoden Descript och variabeln som lagrar lexikonet av menyobjekt.
            */
            LevelMenu.DisplayMenu(Name!, player, Descript, menuItems);
        }
    }

    // Statisk metod för att besöka den forntida smedjan
    private static void VisitAncientForge(Player player)
    {

    }

    // Statisk metod för att granska ruinernas inskriptioner
    private static void ExamineTheInscriptions(Player player)
    {
        
    }

    // Statisk metod för att utforska det gamla apotekets ruiner
    private static void ExploreTheOldPharmacy(Player player)
    {
        
    }

    // Statisk metod för att utmana den spöklika skuggan
    private static void ChallengeGhostlyShadow(Player player)
    {

    }
}