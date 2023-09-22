namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Anton Hansson SUT23.

            Random random = new Random();
            bool playAgain = true; 

            while(playAgain == true) // While loop. Den loopar så länge playAgain är = true.
            {
                int userGuess = 0; // int variabel som motsvarar användarens gissning.
                int userGuesses = 0; // int variabel som motsvarar antal gissningar av användaren.
                string userAnswer = ""; // sträng variabel som motsvarar vad användaren svara i frågan om man vill spela igen eller inte.
                int number = random.Next(1,20 + 1); // Här kan jag välja att sätta den till vad jag vill, men väljer att sätta den från 1-20.

                while (userGuess != number && userGuesses < 5) // Nästlad while loop. Loopar så länge användarens gissning inte är lika med det slumpade numret.
                {                                                                                           
                    Console.Write("\nVälkommen! Gissa på ett nummer mellan " + 1 + " - " + 20 + " : "); // Ber användaren att skriva in ett nummer mellan 1-20.

                    try// Try Catch som förhindrar krasch om användaren skulle skriva in något annat än ett nummer.
                    {
                        userGuess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException) 
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("ERROR! Du måste skriva ett nummer!"); // Felmeddelandet som skrivs ut i konsolen.
                        Console.ResetColor();
                        continue;
                    }
                    CheckGuess(userGuess, number); // Metod

                    userGuesses++;// Räknar antal gissningar. ++ Gör att det blir 1 mer för varje gång.
                }
                if (userGuess != number) // Om användarens gissar fel 5 gånger, skrivs meddelandet nedanför ut i konsolen. 
                {
                    Console.ForegroundColor = ConsoleColor.Red; //ForegroundColor ändrar färg. Här har jag valt red, då det passar bättre då användaren har förlorat.
                    Console.WriteLine("Det korrekta numret var : " + number);
                    Console.WriteLine("Du förlorade! Du gissade fel 5 gånger, försök igen!\nLaddar..."); //Skrev in "Laddar" då det passar bra för att programmet stannar upp i en liten stund.
                    Thread.Sleep(5000); //Sleep så att programmet stannar upp i en liten stund, så att användaren hinner se meddelandet ovanför.
                    Console.ResetColor();// ResetColor tar tillbaka till den ursprungliga färgen, annars hade färgen fortsatt vara röd i resten av programmet.
                    Console.Clear();//Clear för att hålla onsolen konsolen clean.
                }
                else // Annars om användaren har gissat rätt skrivs meddelandet nedanför ut i konsolen. 
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Ändrar till grön färg då det passar bra när användaren vinner.
                    Console.WriteLine("Woho! Du gjorde det!");
                    Console.WriteLine("Det korrekta numret är: " + number); //Det korrekta numret skrivs ut.
                    Console.WriteLine("Antal gissningar: " + userGuesses); // Antal gissningar som användaren behövde för att gissa rätt skrivs ut.
                    Console.ResetColor();
                    Console.WriteLine("Vill du spela igen? (J/N)");
                    userAnswer = Console.ReadLine();
                    userAnswer = userAnswer.ToUpper(); // ToUpper som omvandlar i fall användaren skulle skriva in en liten bokstav istället en stor.
                

                    if (userAnswer == "J") // Om användaren skriver "J" skrivs meddelandet nedanför ut i konsolen och frågar om man vill spela igen.
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vad kul att du vill spela igen! \nLaddar...");
                        Console.ResetColor();
                        Thread.Sleep(4000);
                        playAgain = true;
                        Console.Clear();
                    }
                    else if( userAnswer == "N") // Annars om användaren skriver "N" så kommer meddelandet nedanför och programmet avslutas efter break;.
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hej då, tack för att du spelade! \nKlicka på valfri knapp för att avsluta.");
                        playAgain= false;   
                        Console.ResetColor();
                        break;
                    }
                
                       
                }
                
            }
            static void CheckGuess(int userGuess, int number) // Metod eller funktion som skriver ut ifall användarens gissing är för hägt eller lågt.
            {
                if(userGuess > number)
                {
                    Console.WriteLine("Tyvärr, " + userGuess + " är för högt. Försök igen!");                 
                }
                else if (userGuess < number)
                {
                    Console.WriteLine("Tyvärr, " + userGuess + " är för lågt. Försök igen!");
                }
                    
            }
        }
    }
}