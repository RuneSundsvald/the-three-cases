using ClassLibrary1;

int userint = 0;
string? userstring = "";
bool exit = false;

string? user="";
string? username;
string? password;
string? line = null;
string? login;
bool knowuser = false;
bool samepass = false;
string? newuser = null;
string? newpassword = null;
string? newknowuser = null;
bool hasspace;
string newPassword=null;


//login
while (knowuser == false && !exit)
{
    Console.Clear();
    /*
    Console.Write("Username: ");
    user = Console.ReadLine();
    Console.WriteLine();
    Console.Write("Password: ");
    password = Console.ReadLine();
    */
    user = Input.input("Username", false);
    password = Input.input("Password");
    login = user + " " + password;


    try
    {   //looking thour the text file to see if the login it knowen
        StreamReader sr = new StreamReader(@"C:\Users\Rune\Desktop\the three cases\the three cases\TextFile1.txt");
        line = sr.ReadLine();
       
        while (line != null)
        {
            //if the login is knowen set knowuser to true that will alow the user to break out of the while loop they are in
            //and get to the menu
            if (line == login)
            {
                knowuser = true;
                line= null;
            }
            else
            {
                line = sr.ReadLine();
            }
            
        }
        sr.Close();
        //after it has looked thour the login list if the user and or password was not know print this msg
        if (knowuser == false)
        {
            Console.WriteLine("Wrong user name and or password");
            Console.ReadKey();
        }


    }

    //if we run in to some error
    catch (Exception e)
    {

        Console.WriteLine("fail");
        Console.WriteLine(e.ToString());
        exit = true;


    }
}


//MAIN PROGRAM
///this is the main program that the user can get to if they have a login   
///here the can use the 3 build in fetehs "fodbold", "Dansekonkurrence" og "Oprettelse af ny user" or the can exit the program


while (!exit)
{

    Console.Clear();
    //the menu prombes the user to pick what they wanna do
    Console.WriteLine("Menu\n1. Fodbold.\n2. Dansekonkurrence.\n3. Oprettelse af ny user.\n4. Change password.\n5. Exit.");
    string choice = Console.ReadLine();

    //the 4 choice the user can pick
    switch (choice)
    {
        //FODBOLD
        //useing the "fodbold" class
        case "1":
            Console.Write("er det mål eller afleveringer: ");
            userstring = Console.ReadLine().ToLower();


            Console.Write("intast antal: ");
            userint = (Convert.ToInt32(Console.ReadLine()));

            
            Console.WriteLine(fodbold.ex1(userint, userstring));
            Console.ReadLine();
            break;
        
            
        //DANCE STUFF
        //useing teh dancepoints class
        case "2":
            Console.Clear();
            dancepoints person1 = new dancepoints();
            dancepoints person2 = new dancepoints();

            person1.setData();
            person2.setData();

            dancepoints per = person1 + person2;
            Console.WriteLine($"{per.Name} {per.Points}");
            Console.ReadLine();

            break;



        //add new user
        case "3":
            
            //while loop used for getting a new username and making sure it dose not have a blank space in it
            while (newuser == null)
            {
                Console.Clear();
                Console.WriteLine("welcome");
                Console.WriteLine("type in the new users username");
                newuser = Console.ReadLine();
                //checking if it has a blank space in it. If true prints fail line and sets newuser = null getting them to restart the while loop
                hasspace = newuser.Contains(" ");
                if (hasspace == true)
                {
                    Console.WriteLine("you cannot have a space in the user name");
                    Console.ReadKey();
                    newuser = null;

                }
            }
            //while loop for getting a new user password and making sure it followes the set guide lines
            while (newpassword == null)
            {
                //tells the user the guide lines for a new password and prombs them to type one in
                Console.WriteLine("type the new users password IT CAN NOT have blank space in it\nMost have minimum 12 charters with " +
                    "bouth captile and lowecase togther with numbers & spiacle charters");
                newpassword = Console.ReadLine();
                //checking for blank space and print fail msg if found after it will reset the while loop
                hasspace = newpassword.Contains(" ");
                if (hasspace == true)
                {
                    Console.WriteLine("you cannot have a space in the user name");
                    Console.ReadKey();
                    newpassword = null;

                }
                //checking if the guide lines are being followed if they are not print fail msg and reset while loop
                if (newuser.ToLower()==newpassword.ToLower()||newpassword.Length < 12 || newuser == newpassword || !newpassword.Any(upper => char.IsUpper(upper))
                    || !newpassword.Any(lower => char.IsLower(lower)) || !newpassword.Any(degit => char.IsDigit(degit)))
                {
                    Console.WriteLine("The password does not meet the requarments");
                    Console.ReadKey();
                    newpassword = null;

                }


            }
            //making the new user and password ready to be saved in the .txt doc
            newknowuser = newuser + " " + newpassword;

            //adding the new user to the .txt doc and printing a msg that the user was added
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\Rune\Desktop\the three cases\the three cases\TextFile1.txt", append: true);
                sw.WriteLine(newknowuser);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("failed");
                Console.WriteLine(e.ToString());

            }
            Console.WriteLine(newknowuser + " have been added as a user");
            Console.ReadKey();
            newpassword = null;
            newknowuser=null;
            newuser=null;
            newpassword=null;
            break;

        //Change password with help from (chatGPT) made to fit by Rune
        case "4":
            // File path where the login info is stored
            string filePath = @"C:\Users\Rune\Desktop\the three cases\the three cases\TextFile1.txt";

            // Read all lines from the file into an array
            string[] lines = File.ReadAllLines(filePath);

            // Ask the user for their username
            if (user == "admin")
            {
                Console.Write("Enter your username: ");
                username = Console.ReadLine();
            }
            else
            {
                username = user;
            }

                // Search for the user's information in the array
                int userIndex = Array.FindIndex(lines, line => line.StartsWith(username + " "));

            if (userIndex != -1)
            {
                // Extract the password from the line
                string[] parts = lines[userIndex].Split(' ');
                string oldPassword = parts[1];

                //while loop to make sure the password meets guide lines
                while (newPassword == null)
                {
                    Console.WriteLine("The password CAN NOT have blank space in it\nMost have minimum 12 charters with " +
                    "bouth captile and lowecase togther with numbers & spiacle charters");
                     Console.Write("Enter your new password: ");
                     newPassword = Console.ReadLine();
                    //checking if the guide lines are being followed if they are not print fail msg and reset while loop
                    if (username.ToLower() == newPassword.ToLower() || newPassword.Length < 12 || newPassword == oldPassword || !newPassword.Any(upper => char.IsUpper(upper))
                    || !newPassword.Any(lower => char.IsLower(lower)) || !newPassword.Any(degit => char.IsDigit(degit))|| newPassword.Contains(" "))
                     {
                        Console.WriteLine("The password does not meet the requarments");
                        Console.ReadKey();
                        newPassword = null;

                     }
                }

                // Update the password in memory
                lines[userIndex] = username + " " + newPassword;

                // Rewrite the updated content back to the file
                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Password changed successfully.");
            }
            else
            {
                Console.WriteLine("Username not found.");
            }

            break;
        //CLOSE PROGRAM        
        case "5":
            Console.WriteLine("Exiting...");
            exit = true;
            break;



        //if the user input is not 1-4 it will default to this telling them to try again
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            Console.ReadKey();
            break;


    }
}
