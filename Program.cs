class Program{     // Used this class for static variables (i.e variables I can establish at the top and use all across any static void function)
//-------------------------------------------------------------------------------------------------

static bool introS = true;        //intro start, this boolean is set to start the intro while loop.
static bool introEC1 = false;     //intro ErrorCheck1, this boolean is used to error check any inputs that aren't "Enter key press" for line 12 (i,e the rule prompt).
static bool YesNo1 = false;       //This is created for the Yes and No function that'll error check if the player's response is either Yes or No, in the rule explanation part of the introduction.
static bool namecon = false;      //This flag is set to true after the rule is understood by the player, this flag starts the function that asks the player for their name.
static string finalname;          //Stores the name that the player inputted, this will be used to call the player by their name throughout the game.

static bool restart = true;       //this boolean flag when true, runs the entire game, when false stops the game.
static bool Riddlebegin = false;  //this flag is set after the namecon function's conditions have been met. This flag is responsible to start the riddleone function.
static bool R2con = false;        //This flag, when true, allows for R2Enter function to start. The R2Enter function error checks the player's response when they complete Riddleone. 
                                  //Upon completion of riddleone, the player has to press 'ENTER' to go to the next riddle, the R2Enter function makes sure that the player only goes 
                                  //to the next function upon pressing 'Enter', and that all other inputs don't do anything. 
static bool R3con = false;        //R3con does the same thing as R2con but for the input that makes the player go to riddlethree from riddletwo.
static bool R4con  = false;       //R4con does the same thing as R2con but for the input that makes the player go to riddlefour from riddlethree.
static bool R5con = false;        //All the Rcon function, R2con - R10con facilitate the REnter functions which allow the player to go to the next riddle from their respective riddle number.
static bool R6con = false;
static bool R7con = false;
static bool R8con = false;
static bool R9con = false;
static bool R10con = false;
static bool Riddle2 = false;       //this flag is set after the riddlebegin function's conditions have been met. This flag is responsible to start the riddletwo function.
static bool Riddle3 = false;       //this flag is set after the riddletwo function's conditions have been met. This flag is responsible to start the riddlethree function.
static bool Riddle4 = false;       //this flag is set after the riddlethree function's conditions have been met. This flag is responsible to start the riddlefour function.
static bool Riddle5 = false;       //this flag is set after the riddlefour function's conditions have been met. This flag is responsible to start the riddlefive function.
static bool Riddle6 = false;       //this flag is set after the riddlefive function's conditions have been met. This flag is responsible to start the riddlesix function.
static bool Riddle7 = false;       //this flag is set after the riddlesix function's conditions have been met. This flag is responsible to start the riddleseven function.
static bool Riddle8 = false;       //this flag is set after the riddleseven's function's conditions have been met. This flag is responsible to start the riddleeight function.
static bool Riddle9 = false;       //this flag is set after the riddleeight function's conditions have been met. This flag is responsible to start the riddlenine function.
static bool Riddle10 = false;      //this flag is set after the riddlenine function's conditions have been met. This flag is responsible to start the riddleten function.
static int wronganswers;           //this function stores all the wrong answers through all riddles.
static int rightanswers;           //this function stores all the right answers through all riddles.

//--------------------------            MAIN LOOP           ------------------------------
static void Main()
{  
    while (restart == true)   // if restart is true then the entire game starts again, this flag is manipulated in both "HandleGameover" and "Gamefinished" functions to allow the player to restart or stop the game.
    {
        Console.Clear();
        Introduction();
        riddleone();
        riddletwo();
        riddlethree();
        riddlefour();
        riddlefive();
        riddlesix();
        riddleseven();
        riddleeight();
        riddlenine();
        riddleten();

        if (rightanswers >= 8)   //if the player gets at least 8 answers right, they automatically initialize the win con that'll display at the end of the game, as the player can only answer 2 questions wrong without losing.
        {  
            Gamefinished();      // this function allows the players to either stop, or restart the game.
        }

    }
 
//Console.WriteLine($"Wrong Answers: {wronganswers}");   //for debugging. 
//Console.WriteLine($"Right Answers: {rightanswers}");   //for debugging.   
}
//--------------------------              INTRODUCTION                 ------------------------------
static void Introduction()
{

    while(introS == true)       //While IntroS is true, all the if statements within the while loop will loop.
    {    
        Riddlebegin = false;
        Riddle2 = false;
        if(introEC1 == false)   // the first half of the intro will only be printed in the loop, if Errorcheck1 flag is false, i.e the player didn't press the wrong button.
        {    
            Intro();
        } 

        string input = Console.ReadLine();   
        int inputlength = input.Length;

        if(input.Trim() == "")      //The .Trim feature removes all extra spaces from the player's input, just for minor error checking purposes.
        {   
            Console.Clear();        //This removes all the previously printed text from the Terminal.
            Intro2();               //The latter (Rule explanation) part of the introduction message.
            YesNo1 = true;          // The YesNo flag is set to true so that the YesNo flag can start, this is done here as after printing function intro2() the current loop breaks, and the next loop (YesNo loop) needs to start.
            introS = false;         //This flag has been set to false so that the intro1 doesn't loop.
            break;                  //This loop is broken after displaying the rules to the player. This allows the YesNo while loop to start
        }              

        if(input != "")             //if player input is not indicative of an Enter key press, then the player will be prompted to "press enter to see the rules" message.
        {         
            Console.Clear(); 
            Console.WriteLine("Invalid input, please press the 'Enter' key to see the rules.");
            introEC1 = true;        // if EC1 flag is true, the first half of the intro won't be printed, allowing the rules to be printed whenever the player presses Enter after getting the "invalid" input message
        }        
    }
//------- Yes and No response from the player regarding their understanding of the rules. ------------------------------
    while(YesNo1 == true)                   //because of the YesNo flag, that was turned true at the end of the previous loop, the second loop begins.
    {                       
        string input = Console.ReadLine();
        if(input.ToUpper().Trim() == "Y")   //if the format checked input from the player is "Y", then the player understood the rules, and the namecon flag is set to true.
        {     
            Console.Clear();
            namecon = true;                 //The namecon flag allows the next function to start, the name function that asks players for their name.
            break;                          // this is the end condition for the loop, as if the player inputs "Y", it means that they understood the rules of this game.
        }                                 
        
        else if(input.ToUpper().Trim() == "N")  // if the format checked player input is "N", then the rules of the game are printed again for them to understand.
        {   
            Console.Clear(); 
            Console.WriteLine("Please read the rules again to understand them properly.\n");
            Intro2();
        }
     
        else if (input.ToUpper().Trim() != "Y" || input.ToUpper().Trim() != "N") //This is to Check whether the player's response for the Yes and No question is invalid (i.e not Y or N).
        {  
            Console.Clear(); 
            Console.WriteLine("The only acceptable inputs for this prompt are 'Y' for Yes and 'N' for no.\n"); // if the player enters anything that isn't a "Y" or a "N", then they are refamiliarized with the appropriate responses, alongside another explanation of the rules.
            Intro2();
        }
    }

    while(namecon == true)
    {
        Console.WriteLine("Please enter your name?");        //after the namecon flag is set true by the previous YesNo1 function, this new function starts
        string input = Console.ReadLine();
        bool filtered = false;                                //this local function is used to filter names for inappropriate words.
        List<string> filterednames = new List<string>();      //Creating a list containing inappropriate words that I don't want players to be able to write as their names.
        filterednames.Add("FUCK");
        filterednames.Add("BITCH");
        filterednames.Add("DADDY");
        filterednames.Add("SHIT");
        filterednames.Add("WHORE");
        filterednames.Add("GAY");
        filterednames.Add("ASS");

        if(filterednames.Any(filter => input.ToUpper().Contains(filter)) || input.Trim()== "")
        {       
            //I have used the ".any" method here to check if the player's name has any element from the filterednames list.
            // the .any method puts a special condition for all elements in the filteredname list. the special condition is 
            //(filter => input.ToUpper().Contains(filter)). Here, filter is a custom build parameter that represents all the
            // elements of the filteredname list, and "=>" lamda expression is the one responsible for giving it that designation.
            //input.ToUpper().Contains(filter) means that if the uppercased player input (their name) contains any of the elements 
            //from the filteredname list.

            Console.Clear(); 
            Console.WriteLine("That name isn't allowed.");   
            filtered = true;    //if a player's name includes inapproprate words, the filtered is set to true, which means that if the player entered an appropriate name, the flag would be false.
        }     

        if(filtered == false)   //if the filtered flag is false, that means that the player entered an appropriate name.
        {  
            string savedname = input;  //this new variable saves the player input as a saved name, so that saved information can be used later, without it changing.
            Console.Clear();
            Console.WriteLine($"You chose {savedname}, is this correct?");
            Console.WriteLine("Please type 'Y' to confirm, or 'N' to write a different name.");
            string confirmation = Console.ReadLine().ToUpper();

            while(confirmation != "Y" && confirmation != "N")   //this is to error check the player's response for when they don't choose either Y or N to confirm their name.
            {        
                Console.Clear();                                      //if their response isn't Y or N, this loops.
                Console.WriteLine("Invalid Input, please choose either 'Y' for yes, or 'N' for No.\n");  
                Console.WriteLine($"You chose {savedname}, is this correct?");
                Console.WriteLine("Please type 'Y' to confirm, or 'N' to write a different name.");
                confirmation = Console.ReadLine().ToUpper();    // this line of code takes another player input (confirmation) temporarily pausing the infinite loop to wait for a player's
            }                                                   // response, if the player meets the criteria for this loop to start again (i.e, the player enter Y or N) then the loop prints
                                                                // errorcheck message again, this goes on as many times as the player enters an invalid option.

            if(confirmation == "Y")
            {
                Console.Clear();
                Riddlebegin = true;       //the flag for the next function (Riddleone) has been set to true.
                finalname = savedname;    //this code makes the player's confirmed name into a static variable (finalname) which can be used anywhere throughout this entire code.
                break;                    //this breaks the namecon loop, as the player has confirmed their name choice, which was the purpose of this entire while loop.
            }                           
            
            else if(confirmation == "N")
            {
                Console.Clear();
                continue;
            }
        }
    }
}       // ending bracket for introduction function
//--------------------------          GAMELOGIC - Riddle one           ------------------------------
static void riddleone()
{ 
    Random Randomizer = new Random();         // this Randomizer object will print random values which will be used to randomize the riddles for riddle one.
    int Randomnumber = Randomizer.Next(1,4);  // The range is from 1 to 3 as the upper bounds of the range is exclusive. The int variable Randomnumber will have dynamically changing values from 1 - 3.
    
    if(Randomnumber == 1)                     //if the randomvalue from the Randomizer.Next(1,4) function lands on 1, then the code below is ran (one of the riddles from a set of 3 riddles designed for the riddleone function is chosen).
    {            
        while(Riddlebegin == true)            //This flag was set true after a name was received from the player in the previously running namecon while loop.
        {  
            Console.Clear();
            Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");   // This is one of the 3 randomized riddles in the riddleone function.
            Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
            Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
            Console.WriteLine("What would an Alien's favorite key on the keyboard be?\n");
       
            string answer;    // Establishing a variable that I will be using to store player's formatted input (i.e, trimmed, space removed, and capitalized).
            int answerlength; // Establishing a variable that I will be using to store player input's character length.
            List<string> filteredanswer = new List<string>{"SPACEBAR"};  //this is the answer, I have used lists so that I can use the .Any feature to easily compare all the characters of a player's input with the elements in this list.

            
            while(true)    //while the conditions are met (i.e, there is no break in the loop) the length of the player's input will always be checked to see if its above or equal to 15 characters, and whether their input is an empty string or not.
            {              //I have added a break in their only when the "else" part of this loop is true, that means, only when the player has inputted something that is less than or equal to 15 characters and is not an empty string.
                           //This error checks the player's inputs, and limits their ability to break my code.

                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");  //giving the previously established variables there values
                answerlength = answer.Length; 

                if(answerlength >= 15)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What would an Alien's favorite key on the keyboard be?");
                    Console.WriteLine("\nThe answer is too long.");  // giving out a disclaimer to the player about their input length.
                }
                
                else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What would an Alien's favorite key on the keyboard be?");
                    Console.WriteLine("\nCannot enter an empty input."); // giving out a disclaimer to the player for when they press enter without typing anything first.
                }

                else
                {
                    break;   //the while(true) loop is only exited here, when the answer meets the length and value conditions.
                             //this answer (player input) is then forwarded into the functions below.
                }
            }
            
            if(filteredanswer.Any(filter => answer.Contains(filter)))   //The List.Any(elementsofList => playerinput.Contains(elementsofList)) == true, is indicative of a player's input matching with an element in my list (the answer to this riddle)
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;   //this counts the correct answers.
                R2con = true;        //this fulfills the conditions for the R2 function to work, which is then called upon right afterwards.
                R2Enter();           // This is a function that asks the player to press enter to go onto the next level (Riddle2),  and error checks their input (makes sure they pressed Enter and nothing else).
                break;               //after receiving an answer, right or wrong, the purpose of the riddleone loop has been served, hence the break.
            }              

            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");
                R2con = true;
                wronganswers += 1;  //this counts the wrong answers. will be used to create a gameover condition.
                R2Enter();
                break;              //after receiving an answer, right or wrong, the purpose of the riddleone loop has been served, hence the break.
            }
        }   
    }           //end bracket for the first if condition, for the randomized riddleone.

    if(Randomnumber == 2)    //if the randomvalue from the Randomizer.Next(1,4) function lands on 2, then a different riddle is printed. 
    {                        // the rest of it is very similar to the previous riddleone function, barring the riddle itself.
        while(Riddlebegin == true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
            Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
            Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
            Console.WriteLine("What is a Martian's favorite Chocolate bar?\n");
       
            string answer;
            int answerlength;
            List<string> filteredanswer = new List<string>{"MARSBAR", "MARS"};

            while (true)           
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");  
                answerlength = answer.Length;

                if (answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten; hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What is a Martian's favorite Chocolate bar?");
                    Console.WriteLine("\nCannot enter an empty input.");
                }
                    
                else if (answerlength > 11)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten; hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What is a Martian's favorite Chocolate bar?");
                    Console.WriteLine("\nThe answer is too long.");
                }
                    
                else
                {
                    break;
                }
            }

            if(filteredanswer.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R2con = true;
                R2Enter();
                break;
            }

            else
            {            
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");   
                Console.WriteLine("\nPress the Enter key to continue.");
                R2con = true;            
                wronganswers += 1;
                R2Enter();
                break;
            }    
        }
    }           //end bracket for second if condition, for the randomized riddleone.

    if(Randomnumber == 3)           //if the randomvalue from the Randomizer.Next(1,4) function lands on 3, then a different riddle is printed.
    {  
        while(Riddlebegin == true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
            Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
            Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
            Console.WriteLine("What do you call a Martian that can Sing?\nP.S, full name required.\n");
       
            string answer;
            int answerlength;
            List<string> filterednames = new List<string>{"BRUNOMARS"};
            
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length; 
            
                if(answerlength > 12)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What do you call a Martian that can Sing?\nP.S, full name required.");
                    Console.WriteLine("\nThe answer is too long.");    
                }         
            
                else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {finalname}!!, I am the first of the Decem Riddlers Jo Amon..!!");
                    Console.WriteLine("This is the first tunnel out of ten, hope you don't get lost hehe..he.");
                    Console.WriteLine("Anyhow, let us bear witness to your mental prowess, solve my riddle if you can.\n");
                    Console.WriteLine("What do you call a Martian that can Sing?\nP.S, full name required.");                    
                    Console.WriteLine("\nCannot enter an empty input.");
                }
            
                else
                {
                    break;
                }
            }    
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R2con = true;            
                R2Enter();           
                break;
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                R2con = true; 
                wronganswers += 1;
                R2Enter(); 
                break;
            }     
        }       //end bracket for third if condition, for the randomized riddleone.
    }           // end bracket for riddleone function. 
}
//Basically there are 3 riddles that can be randomly printed by the riddleone function. This will be the
//case for all riddle functions, that is, riddletwo will have 3 random functions, riddlethree will have 3 randomfunctions, and so on till the 
//last riddle (riddleten). This is done to add a sense of randomness in the code and make each run a little different.

//--------------------------          GAMELOGIC - Riddle two           ------------------------------
static void riddletwo()
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle2 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
            Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
            Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
            Console.WriteLine("Name a band that never plays music.\n");
    
            string answer;
            int answerlength;
            List<string> filterednames = new List<string>{"RUBBERBAND"};
            
            while(true)
            {
            answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
            answerlength = answer.Length;
            
                if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("Name a band that never plays music."); 
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else if(answerlength >= 12)
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("Name a band that never plays music."); 
                    Console.WriteLine("\nThe answer is too long.");
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R3con = true;        
                R3Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                R3con = true; 
                R3Enter();
                break;
            }   
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
            Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
            Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
            Console.WriteLine("What Music genre would a balloon be scared of?\n");
    
            string answer;
            int answerlength;
            List<string> filterednames = new List<string>{"POP", "POPMUSIC"};
         
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("What Music genre would a balloon be scared of?");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("What Music genre would a balloon be scared of?");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else
                {
                    break;
                }
            }
                
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R3con = true;         
                R3Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                R3con = true; 
                R3Enter();
                break;
            }
        }

        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
            Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
            Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
            Console.WriteLine("I have a lot of keys, but I can't open doors..What am I?\n");
    
            string answer;
            int answerlength;
            List<string> filterednames = new List<string>{"PIANO", "KEYBOARD", "HARMONIUM", "ORGAN", "HARPSICHORD", "ACCORDION",
            "SYNTHESIZER", "GRANDPIANO", "KEYTAR"};
        
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength >= 15)
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("I have a lot of keys, but I can't open doors..What am I?");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good Morrow {finalname}, I am the second Decem Riddler Micheal Jackson Heeeheee.");
                    Console.WriteLine("This is the second tunnel aka the Neverland Ranch. To moonWALK out of this place,");
                    Console.WriteLine("you've got to successfully answer my riddle, come on now, SHAMON WITH IT.\n");
                    Console.WriteLine("I have a lot of keys, but I can't open doors..What am I?");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else
                {
                    break;
                }
            }
        
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R3con = true;         
                R3Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                R3con = true; 
                R3Enter();
                break;
            }    
        }
    }
} // ending for the riddle two function 
//--------------------------          GAMELOGIC - Riddle three         ------------------------------
static void riddlethree()
{
    Random Randomizer = new Random();
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle3 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
            Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
            Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
            Console.WriteLine("When is my Birthday?\nhint: the answer is in the name Mario.\n");
        
            List<string> filterednames = new List<string>{"MAR10", "10MAR", "MARCH10TH", "10THMARCH", "10MARCH", "MARCH10", 
            "10THOFMARCH", "MARCHOF10TH", "MARCHTHE10TH"};
            string answer;
            int answerlength;

            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("When is my Birthday?\nhint: the answer is in the name Mario.");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else if(answerlength >= 15)
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("When is my Birthday?\nhint: the answer is in the name Mario.");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R4con = true;         
                R4Enter();           
                break;
            }
        
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R4con = true; 
                    R4Enter();
                    break;
                }
            }    
        }
        
        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
            Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
            Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
            Console.WriteLine("In a kingdom of shrooms where Bowser looms, who's the red-clad hero dispelling the princess's gloom?\n");

            List<string> filterednames = new List<string>{"MARIO"};
            string answer;
            int answerlength;

            while(true)
            {
                answer = Console.ReadLine().Trim().Replace(" ", "").ToUpper();
                answerlength = answer.Length;

                if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("In a kingdom of shrooms where Bowser looms, who's the red-clad hero dispelling the princess's gloom?");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else if(answerlength > 8)
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("In a kingdom of shrooms where Bowser looms, who's the red-clad hero dispelling the princess's gloom?");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R4con = true;         
                R4Enter();           
                break;
            }
        
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R4con = true; 
                    R4Enter();
                    break;
                }
            }    
        }
            
        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
            Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
            Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
            Console.WriteLine("With a crown on my head, I'm round and white, a ghostly monarch with a mischievous delight.\nWhat am I in the haunting night?\n");

            List<string> filterednames = new List<string>{"KINGBOO"};
            string answer;
            int answerlength;
            
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength >= 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("With a crown on my head, I'm round and white, a ghostly monarch with a mischievous delight.\nWhat am I in the haunting night?");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hey there {finalname}, I am the Third Decem Riddler Mario Mario WAHOOoo.");
                    Console.WriteLine("welcome to the mushroo- I mean the third tunnel.");
                    Console.WriteLine("In order to get to the next level, you must solve my riddle. LET'S A GO!!!\n");
                    Console.WriteLine("With a crown on my head, I'm round and white, a ghostly monarch with a mischievous delight.\nWhat am I in the haunting night?");
                    Console.WriteLine("\nCannot enter an empty input."); 
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R4con = true;         
                R4Enter();           
                break;
            }
        
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R4con = true; 
                    R4Enter();
                    break;
                }
           }      
        }
    } //while loop for the riddlethree function.
} //ending bracket for the riddle three function
//--------------------------          GAMELOGIC - Riddle four          ------------------------------
static void riddlefour()
{
    Random Randomizer = new Random();
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle4 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
            Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
            Console.WriteLine("\nI'm a car from the past but in the future I shine. What am I that travels through time?\n");
            
            List<string> filterednames = new List<string>{"THEDELOREAN", "DELOREAN", "THEDELOREAN1982DMC-12", "DELOREAN1982DMC", "THE1982DMCDELOREAN", 
            "THE1982DELOREANDMC-12", "THEDELOREAN1982DMC", "1982DMCDELOREAN","THEDELOREAN1982", "THE1982DELOREAN"};
            string answer;
            int answerlength;
            
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 24)
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nI'm a car from the past but in the future I shine. What am I that travels through time?");
                    Console.WriteLine("\nThe answer is too long.");      
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nI'm a car from the past but in the future I shine. What am I that travels through time?");
                    Console.WriteLine("\nCannot enter an empty input.");      
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R5con = true;         
                R5Enter();           
                break;
            }
            
            else if(filterednames.Any(filter => answer.Contains(filter)) == false)
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R5con = true; 
                    R5Enter();
                    break;
                }   
            }           
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
            Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
            Console.WriteLine("\nIn traversing time, it provides a crucial thrust. It's a must have part known for its flux.");
            Console.WriteLine("In the DeLorean, it sparks the combustion, what is it, in this discussion.\n");
            
            List<string> filterednames = new List<string>{"THEFLUXCAPACITOR", "THE-FLUX-CAPACITOR", "THEFLUX-CAPACITOR", "FLUXCAPACITOR"
            ,"FLUX-CAPACITOR"};
            string answer;
            int answerlength;

            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 20)
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nIn traversing time, it provides a crucial thrust. It's a must have part known for its flux.");
                    Console.WriteLine("In the DeLorean, it sparks the combustion, what is it, in this discussion.");
                    Console.WriteLine("\nThe answer is too long.");      
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nIn traversing time, it provides a crucial thrust. It's a must have part known for its flux.");
                    Console.WriteLine("In the DeLorean, it sparks the combustion, what is it, in this discussion.");
                    Console.WriteLine("\nCannot enter an empty input.");      
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R5con = true;         
                R5Enter();           
                break;
            }
            
            else if(filterednames.Any(filter => answer.Contains(filter)) == false)
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue."); 
                wronganswers += 1;           
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R5con = true; 
                    R5Enter();
                    break;
                }      
            }           
        }

        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
            Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
            Console.WriteLine("\nI tick and I tock, on the wall or a shelf, counting the moments, in a rythemic stealth.");
            Console.WriteLine("What am I, with hands that dance, In the morning light or a moonlit trance?\n");

            List<string> filterednames = new List<string>{"CLOCK"};
            string answer;
            int answerlength;

            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength >= 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nI tick and I tock, on the wall or a shelf, counting the moments, in a rythemic stealth.");
                    Console.WriteLine("What am I, with hands that dance, In the morning light or a moonlit trance?");
                    Console.WriteLine("\nThe answer is too long.");      
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Howdy {finalname}, I'm the fourth Decem Riddler, Dr. Emmett Brown, welcome to the fourth tunnel Buddy.");
                    Console.WriteLine("To get out of dodge (haha) there is only thing you can do..SOLVE ME RIDDLE");
                    Console.WriteLine("\nI tick and I tock, on the wall or a shelf, counting the moments, in a rythemic stealth.");
                    Console.WriteLine("What am I, with hands that dance, In the morning light or a moonlit trance?");
                    Console.WriteLine("\nCannot enter an empty input.");      
                }

                else
                {
                    break;
                }
            }
            
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R5con = true;         
                R5Enter();           
                break;
            }
            
            else if(filterednames.Any(filter => answer.Contains(filter)) == false)
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R5con = true; 
                    R5Enter();
                    break;
                }       
            }           
        }                     
    }
}
//--------------------------          GAMELOGIC - Riddle five          ------------------------------
static void riddlefive()
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle5 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
            Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
            Console.WriteLine("A property that keeps you on the ground and stops things from floating around,");
            Console.WriteLine("what is it called?\n");
    
            List<string> filterednames = new List<string>{"GRAVITY"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("A property that keeps you on the ground and stops things from floating around,");
                    Console.WriteLine("what is it called?");   
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("A property that keeps you on the ground and stops things from floating around,");
                    Console.WriteLine("what is it called?");   
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R6con = true;        
                R6Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R6con = true; 
                    R6Enter();
                    break;
                }   
            }    
        }
        
        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
            Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
            Console.WriteLine("What is something that you always have, but you always leave behind?\n");
            
            List<string> filterednames = new List<string>{"FINGERPRINTS", "FINGER-PRINTS", "FINGERPRINT","FINGER-PRINT"};
            string answer;
            int answerlength;
            
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("What is something that you always have, but you always leave behind?");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else if(answerlength > 16)
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("What is something that you always have, but you always leave behind?");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else
                {
                    break;
                }
            }

            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R6con = true;         
                R6Enter();           
                break;
            }
            
            else if(filterednames.Any(filter => answer.Contains(filter)) == false)
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R6con = true; 
                    R6Enter();
                    break;
                } 
            }  
        }
        
        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
            Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
            Console.WriteLine("In an empty room, I take no space, yet in a night sky, I find my place.");
            Console.WriteLine("What am I, with a soft glow, that in the darkness likes to show.\n");
        
            List<string> filterednames = new List<string>{"LIGHT", "LIGHTS"};
            string answer;
            int answerlength;
            
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("In an empty room, I take no space, yet in a night sky, I find my place.");
                    Console.WriteLine("What am I, with a soft glow, that in the darkness likes to show.");
                    Console.WriteLine("\nCannot enter an empty input.");
                }

                else if(answerlength > 9)
                {
                    Console.Clear();
                    Console.WriteLine($"Good day {finalname}, I am the fifth Decem Riddler Albert Einstein.");
                    Console.WriteLine("This is the fifth tunnel, I'm sure you know the deal by now, lets go.\n");
                    Console.WriteLine("In an empty room, I take no space, yet in a night sky, I find my place.");
                    Console.WriteLine("What am I, with a soft glow, that in the darkness likes to show.");
                    Console.WriteLine("\nThe answer is too long.");
                }

                else
                {
                    break;
                }
            }

            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R6con = true;         
                R6Enter();           
                break;
            }
            
            else if(filterednames.Any(filter => answer.Contains(filter)) == false)
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;  
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R6con = true; 
                    R6Enter();
                    break;
                } 
            }  
        }    
    }
}    
//--------------------------          GAMELOGIC - Riddle Six           ------------------------------
static void riddlesix()    
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle6 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
            Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
            Console.WriteLine("this tunnel with a riddle so..\n");
            Console.WriteLine("I'm orange and bouncy with black carvings like a map, people fight for my");
            Console.WriteLine("touch but throw me at a glance, what am I?\n");

            List<string> filterednames = new List<string>{"BASKETBALL", "BASKET-BALL"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength >= 14)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("I'm orange and bouncy with black carvings like a map, people fight for my");
                    Console.WriteLine("touch but throw me at a glance, what am I?");  
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("I'm orange and bouncy with black carvings like a map, people fight for my");
                    Console.WriteLine("touch but throw me at a glance, what am I?");     
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R7con = true;        
                R7Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R7con = true; 
                    R7Enter();
                    break;
                }
            }    
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
            Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
            Console.WriteLine("this tunnel with a riddle so..\n");
            Console.WriteLine("I'm a ball that rolls but can't bounce or be thrown, what am I?\nhint: linked to the 5 senses.\n");

            List<string> filterednames = new List<string>{"EYE", "EYES", "EYEBALLS", "EYEBALL", "EYE-BALL", "EYE-BALLS"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 12)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("I'm a ball that rolls but can't bounce or be thrown, what am I?\nhint: linked to the 5 senses.");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("I'm a ball that rolls but can't bounce or be thrown, what am I?\nhint: linked to the 5 senses.");   
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R7con = true;        
                R7Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R7con = true; 
                    R7Enter();
                    break;
                }
            }    
        }

        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
            Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
            Console.WriteLine("this tunnel with a riddle so..\n");
            Console.WriteLine("What is an insect's favorite sport?\n");

            List<string> filterednames = new List<string>{"CRICKET"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("What is an insect's favorite sport?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {finalname}, I am the the sixth Decem Riddler Wilt Chamberlain.");
                    Console.WriteLine("I don't know how I'm alive right now, but hey an alien told me to guard");
                    Console.WriteLine("this tunnel with a riddle so..\n");
                    Console.WriteLine("What is an insect's favorite sport?");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R7con = true;        
                R7Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R7con = true; 
                    R7Enter();
                    break;
                }
            }    
        }
    }
}    
//--------------------------          GAMELOGIC - Riddle seven         ------------------------------
static void riddleseven()    
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle7 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
            Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
            Console.WriteLine("After all, the state of the world depends on it.\n");
            Console.WriteLine("What kind of a business am I a part of :)\n");

            List<string> filterednames = new List<string>{"CHICKENBUSINESS", "FASTFOODBUSINESS", "FAST-FOODBUSINESS",
            "FAST-FOOD-BUSINESS", "CHICKEN-BUSINESS", "CHICKEN", "FASTFOOD", "FAST-FOOD", "FOODINDUSTRY", "FOOD-INDUSTRY",
            "CHICKENINDUSTRY", "CHICKEN-INDUSTRY", "COOKINGBUSINESS", "COOKING-BUSINESS", "COOKING"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 22)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("What kind of a business am I a part of :)");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("What kind of a business am I a part of :)");   
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R8con = true;        
                R8Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R8con = true; 
                    R8Enter();
                    break;
                }
            }    
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
            Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
            Console.WriteLine("After all, the state of the world depends on it.\n");
            Console.WriteLine("What kind of a suit would a lawyer love?\n");

            List<string> filterednames = new List<string>{"LAWSUIT"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength >= 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("What kind of a suit would a lawyer love?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("What kind of a suit would a lawyer love?");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R8con = true;        
                R8Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R8con = true; 
                    R8Enter();
                    break;
                }
            }    
        }

          if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
            Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
            Console.WriteLine("After all, the state of the world depends on it.\n");
            Console.WriteLine("I'm a trio of letters, fierce and keen, In drug control I reign Supreme. What am I??");
            Console.WriteLine("hint: Hank Shrader. Also just the acronym, not the full form.\n");


            List<string> filterednames = new List<string>{"DEA"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 6)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("I'm a trio of letters, fierce and keen, In drug control I reign Supreme. What am I??");
                    Console.WriteLine("hint: Hank Shrader. Also just the acronym, not the full form.");
                    Console.WriteLine("\nThe answer is too long.");
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening {finalname}, I am the the seventh Decem Riddler Gustavo Fring,");
                    Console.WriteLine("but you can call me Guss. I have a simple riddle for you, hopefully you can answer it correctly.");
                    Console.WriteLine("After all, the state of the world depends on it.\n");
                    Console.WriteLine("I'm a trio of letters, fierce and keen, In drug control I reign Supreme. What am I??");
                    Console.WriteLine("hint: Hank Shrader. Also just the acronym, not the full form.");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R8con = true;        
                R8Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R8con = true; 
                    R8Enter();
                    break;
                }
            }    
        }
    }
}
//--------------------------          GAMELOGIC - Riddle eight         ------------------------------
static void riddleeight()    
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle8 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
            Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
            Console.WriteLine("May fortune favor you in these trying times.\n");
            Console.WriteLine("In London town, I tower high, A clock with chimes, reaching the sky. Tourists gather, my bells they hear");
            Console.WriteLine("What am I, holding time my dear?\n");

            List<string> filterednames = new List<string>{"BIGBEN", "BIG-BEN"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("In London town, I tower high, A clock with chimes, reaching the sky. Tourists gather, my bells they hear");
                    Console.WriteLine("What am I, holding time my dear?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("In London town, I tower high, A clock with chimes, reaching the sky. Tourists gather, my bells they hear");
                    Console.WriteLine("What am I, holding time my dear?");   
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R9con = true;        
                R9Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R9con = true; 
                    R9Enter();
                    break;
                }
            }    
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
            Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
            Console.WriteLine("May fortune favor you in these trying times.\n");
            Console.WriteLine("Protected by tall guards in red, with lush garden beds widely spread. In London's heart I proudly stand, the greatest");
            Console.WriteLine("symbol of royalty at one's hand. What am I?\n");


            List<string> filterednames = new List<string>{"BUCKINGHAMPALACE", "BUCKINGHAM-PALACE"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 20)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("Protected by tall guards in red, with lush garden beds widely spread. In London's heart I proudly stand, the greatest");
                    Console.WriteLine("symbol of royalty at one's hand. What am I?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("Protected by tall guards in red, with lush garden beds widely spread. In London's heart I proudly stand, the greatest");
                    Console.WriteLine("symbol of royalty at one's hand. What am I?");  
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R9con = true;        
                R9Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R9con = true; 
                    R9Enter();
                    break;
                }
            }    
        }

         if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
            Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
            Console.WriteLine("May fortune favor you in these trying times.\n");
            Console.WriteLine("I'm a sport forged from ancient bretain's rough trance, jaws beware, for I require a strong stance. With fists");
            Console.WriteLine("clenched, in a square terrain, I'm a sport where resilience is in my veins. What am I?\n");

            List<string> filterednames = new List<string>{"BOXING"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 9)
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("I'm a sport forged from ancient bretain's rough trance, jaws beware, for I require a strong stance. With fists");
                    Console.WriteLine("clenched, in a square terrain, I'm a sport where resilience is in my veins. What am I?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Good evening dear, Welcome to my humble domain, I am the the eighth Decem Riddler Queen Elizabeth II.");
                    Console.WriteLine("I have, with me, but a simple riddle for your persual, hopefully you have what it takes to get past this hurdle.");
                    Console.WriteLine("May fortune favor you in these trying times.\n");
                    Console.WriteLine("I'm a sport forged from ancient bretain's rough trance, jaws beware, for I require a strong stance. With fists");
                    Console.WriteLine("clenched, in a square terrain, I'm a sport where resilience is in my veins. What am I?");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R9con = true;        
                R9Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R9con = true; 
                    R9Enter();
                    break;
                }
            }    
        }
    }
}
//--------------------------          GAMELOGIC - Riddle nine          ------------------------------
static void riddlenine()    
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle9 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
            Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
            Console.WriteLine("In sands and caves I hold my reign, I am part dragon and part plane. I strike fear in those who approach");
            Console.WriteLine("me, especially the ones who put all their faith in a flame ridden monkey. What am I?\n");

            List<string> filterednames = new List<string>{"GARCHOMP"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 9)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("In sands and caves I hold my reign, I am part dragon and part plane. I strike fear in those who approach");
                    Console.WriteLine("me, especially the ones who put all their faith in a flame ridden monkey. What am I?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("In sands and caves I hold my reign, I am part dragon and part plane. I strike fear in those who approach");
                    Console.WriteLine("me, especially the ones who put all their faith in a flame ridden monkey. What am I?");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R10con = true;        
                R10Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R10con = true; 
                    R10Enter();
                    break;
                }
            }    
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
            Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
            Console.WriteLine("With sparks that dance and cheeks that glow, In battles fierce, my power I show. A thundering tail");
            Console.WriteLine("and a squishy body, who am I in Ash's party?\n");

            List<string> filterednames = new List<string>{"PIKACHU"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("With sparks that dance and cheeks that glow, In battles fierce, my power I show. A thundering tail");
                    Console.WriteLine("and a squishy body, who am I in Ash's party?");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("With sparks that dance and cheeks that glow, In battles fierce, my power I show. A thundering tail");
                    Console.WriteLine("and a squishy body, who am I in Ash's party?");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R10con = true;        
                R10Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R10con = true; 
                    R10Enter();
                    break;
                }
            }    
        }

        
        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
            Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
            Console.WriteLine("In Sinnoh's realm where trainers shine, a master tactician, in battles, divine. Dragon's breath and");
            Console.WriteLine("roses intertwine, Who am I, a trainer sublime.\n");

            List<string> filterednames = new List<string>{"CYNTHIA"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("In Sinnoh's realm where trainers shine, a master tactician, in battles, divine. Dragon's breath and");
                    Console.WriteLine("roses intertwine, Who am I, a trainer sublime.");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {finalname}, into my chambers, I am the ninth Decem leader Cynthia (PTSD music kicks in)");
                    Console.WriteLine("My riddle has been crafted to cover all known type advantages, best me if you can.\n");
                    Console.WriteLine("In Sinnoh's realm where trainers shine, a master tactician, in battles, divine. Dragon's breath and");
                    Console.WriteLine("roses intertwine, Who am I, a trainer sublime.");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;
                R10con = true;        
                R10Enter();           
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    R10con = true; 
                    R10Enter();
                    break;
                }
            }    
        }
    }
}
//--------------------------          GAMELOGIC - Riddle ten           ------------------------------
static void riddleten()    
{
    Random Randomizer = new Random();         
    int Randomnumber = Randomizer.Next(1,4);
    
    while(Riddle10 == true)
    {
        if(Randomnumber == 1)
        {
            Console.Clear();
            Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
            Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
            Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
            Console.WriteLine("The person who makes it, sells it. The person who buys it never uses it. And the person who uses it, never");
            Console.WriteLine("realize that they're using it. What is the object in question?\nhint: it's not fake money.\n");

            List<string> filterednames = new List<string>{"COFFIN", "CASKET"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 8)
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("The person who makes it, sells it. The person who buys it never uses it. And the person who uses it, never");
                    Console.WriteLine("realize that they're using it. What is the object in question?\nhint: it's not fake money.");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("The person who makes it, sells it. The person who buys it never uses it. And the person who uses it, never");
                    Console.WriteLine("realize that they're using it. What is the object in question?\nhint: it's not fake money.");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;         
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    break;
                }
            }    
        }

        if(Randomnumber == 2)
        {
            Console.Clear();
            Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
            Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
            Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
            Console.WriteLine("What comes once in a minute, twice in a moment, but never in a thousand years?");
            Console.WriteLine("hint: look at the words.\n");

            List<string> filterednames = new List<string>{"M"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("What comes once in a minute, twice in a moment, but never in a thousand years?");
                    Console.WriteLine("hint: look at the words.");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("What comes once in a minute, twice in a moment, but never in a thousand years?");
                    Console.WriteLine("hint: look at the words.");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;         
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    break;
                }
            }    
        }

        if(Randomnumber == 3)
        {
            Console.Clear();
            Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
            Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
            Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
            Console.WriteLine("I have keys but they open no locks, I have space but no room as such, you can enter but you can't go");
            Console.WriteLine("inside. What am I?\nhint: You used it throughout this game.\n");

            List<string> filterednames = new List<string>{"KEYBOARD"};
            string answer;
            int answerlength;
                
            while(true)
            {
                answer = Console.ReadLine().ToUpper().Trim().Replace(" ", "");
                answerlength = answer.Length;

                if(answerlength > 10)
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("I have keys but they open no locks, I have space but no room as such, you can enter but you can't go");
                    Console.WriteLine("inside. What am I?\nhint: You used it throughout this game.");
                    Console.WriteLine("\nThe answer is too long.");  
                }

                  else if(answer == "")
                {
                    Console.Clear();
                    Console.WriteLine($"hohohoo, if isn't {finalname}, It seems I was right to choose you as the represntative of Humanity.");
                    Console.WriteLine("You have done well for yourself to get to this point, my heartiest congratulations. Now, the only");
                    Console.WriteLine("Thing standing between you and the safety of this world, is one last riddle. All the best.\n");
                    Console.WriteLine("I have keys but they open no locks, I have space but no room as such, you can enter but you can't go");
                    Console.WriteLine("inside. What am I?\nhint: You used it throughout this game.");
                    Console.WriteLine("\nCannot enter an empty input.");     
                }

                else
                {
                    break;
                }
            }
                    
            if(filterednames.Any(filter => answer.Contains(filter)))
            {
                Console.Clear();
                Console.WriteLine("Congratulations, you got it right!!");
                Console.WriteLine("\nPress the Enter key to continue.");
                rightanswers += 1;         
                break;
            }
          
            else
            {
                Console.Clear();
                Console.WriteLine("Oops, wrong answer.");
                Console.WriteLine("\nPress the Enter key to continue.");            
                wronganswers += 1;
                
                if(wronganswers == 3)
                {
                    HandleGameOver();
                    break;
                }

                else
                {
                    break;
                }
            }    
        }
    }
}
/*_______________________________________________________________________________________________________________________________________*/

// first half of the intro
static void Intro()
{
    Console.Clear();      //clears the previous text from the Terminal.
    Console.WriteLine("Welcome player, this game is called RIDDLE ESCAPE!!.");
    Console.WriteLine("You have been chosen by the great alien overlord Steve to represent humanity as its last stand.");
    Console.WriteLine("The task is simple, answer 10 riddles correctly and you save the world and everyone within it.");
    Console.WriteLine("But there is one crucial rule you must follow.");
    Console.WriteLine("\nPlease press enter to know more.");
}
// Second half of the intro (Rules).
static void Intro2()
{ 
    Console.WriteLine("----------------------  CRUCIAL RULE   ------------------------");
    Console.WriteLine("1.) You only have 3 tries, if you fail 3 times, you lose.");
    Console.WriteLine("\nDo you understand this rule, type 'Y' for Yes or 'N' for No.\n");
}
// the R2 Enter function (i,e pressing the Enter Key after riddle one to go to Riddle two)
static void R2Enter()
{
    if(R2con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle2 = true;
        }
    }
}
// the R3 Enter function (i,e pressing the Enter Key after riddle two to go to Riddle three)
static void R3Enter()
{
    if(R3con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle3 = true;
        }
    }
}
// the R4 Enter function (i,e pressing the Enter Key after riddle three to go to Riddle four)
static void R4Enter()
{
    if(R4con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle4 = true;
        }
    }
}
// the R5 Enter function (i,e pressing the Enter Key after riddle four to go to Riddle five)
static void R5Enter()
{
    if(R5con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle5 = true;
        }
    }
}
// the R6 Enter function (i,e pressing the Enter Key after riddle five to go to Riddle six)
static void R6Enter()
{
    if(R6con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle6 = true;
        }
    }
}
// the R7 Enter function (i,e pressing the Enter Key after riddle six to go to Riddle seven)
static void R7Enter()
{
    if(R7con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle7 = true;
        }
    }
}
// the R8 Enter function (i,e pressing the Enter Key after riddle seven to go to Riddle eight)
static void R8Enter()
{
    if(R8con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle8 = true;
        }
    }
}
// the R9 Enter function (i,e pressing the Enter Key after riddle eight to go to Riddle nine)
static void R9Enter()
{
    if(R9con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle9 = true;
        }
    }
}
// the R10 Enter function (i,e pressing the Enter Key after riddle nine to go to Riddle ten)
static void R10Enter()
{
    if(R10con == true)
    {
        string input = Console.ReadLine().Trim();

        while(input != "")
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please press enter to continue.");
            input = Console.ReadLine().Trim();
        }

        if(input == "")
        {
            Riddle10 = true;
        }
    }
}
/// This function handles the gameover scenario, if a player gets 3 wrong answers.
static void HandleGameOver()
{
    Console.Clear();                                                                //This is the "You lose" message.
    Console.WriteLine("-------------       YOU LOSE       --------------");
    Console.WriteLine("It seems that you have made too many mistakes");
    Console.WriteLine("Unfortunately, the planet is now doomed, AKA GAMEOVERU DA.");
    Console.WriteLine("\nIf you want to try again, press the enter key");
    Console.WriteLine("If you want to exit the game, press 'E'");
    string input = Console.ReadLine().Trim().ToUpper();

    while (input != "E" && input != "")              //if the input isn't 'E' or 'Enter' then an invalid input message is displayed, followed by a console.Read which allows the player to try inputting again.
    {
        Console.Clear();
        Console.WriteLine("Invalid Input, please press either the 'E' button to stop the game, or the Enter Key to restart");
        input = Console.ReadLine().Trim().ToUpper();
    }

    if (input == "E")     //if the player input is 'E' then the game stops, as the restart flag is set to false.
    {
        restart = false;
    }
    
    else if (input == "") //if the player inputs an empty string (Enter key), the game resets all the relevant variables and turns the game restarts.
    {
        restart = true;   //this turns the main while loop on again.
        wronganswers = 0; //resets the wrong answers
        rightanswers = 0; //resets the right answers
        introS = true;    //allows the intro to print again
        introEC1 = false; //allows the into loop to print without errors
        Riddle3 = false;  //all the riddle states are made false, besides riddleone(riddlebegin) and riddle2, which are made false at the start of the intro.
        Riddle4 = false;
        Riddle5 = false;
        Riddle6 = false;
        Riddle7 = false;
        Riddle8 = false;
        Riddle9 = false;
        Riddle10 = false;
    }
}
/// This function handles the Gamefinished scenario, if a player wins, they have the option to quit or try again.
static void Gamefinished()
{
    Console.Clear();
    Console.WriteLine("-------------       YOU WIN       --------------");          // The Gamefinished function is set up just like the HandleGameOver function.
    Console.WriteLine($"Congratulations {finalname}, you have saved the planet, Steve is very impressed");
    Console.WriteLine("and will spare the planet from absolute annahilation.");
    Console.WriteLine("\nIf you want to play again, press the Enter key.");
    Console.WriteLine("If you want to stop playing, press the 'E' key.");
    string input = Console.ReadLine().Trim().ToUpper();

    while (input != "E" && input != "")
    {
        Console.Clear();
        Console.WriteLine("Invalid Input, please press either the 'E' button to stop the game, or the Enter Key to restart");
        input = Console.ReadLine().Trim().ToUpper();
    }

    if (input == "E")
    {
        restart = false;
    }

    else if (input == "") 
    {  
        restart = true;
        wronganswers = 0;
        rightanswers = 0;
        introS = true;
        introEC1 = false;
        Riddle3 = false;
        Riddle4 = false;
        Riddle5 = false;
        Riddle6 = false;
        Riddle7 = false;
        Riddle8 = false;
        Riddle9 = false;
        Riddle10 = false;
    }
}
}  // the class program ending bracket.
  