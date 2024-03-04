namespace ClassLibrary1
{
    //fodblod class 
    public class fodbold
    {
        public static string ex1(int intx, string sx)
        {
            if (sx == "mål")
            {
                return "Olé olé olé";
            }
            else if (intx >= 10 && sx == "afleveringer")
            {
                return "High Five – Jubel!!!";
            }
            else if (intx <= 1 && sx == "afleveringer")
            {
                return "Shh";
            }
            else if (intx > 1 && intx < 10 && sx == "afleveringer")
            {
                string huh = "";
                for (int i = 0; intx > i; i++)
                {
                    huh += "Huh! ";
                }
                return huh;
            }

            return "failed";


        }

    }
    //dancepoint class
    public class dancepoints
    {
         public string Name { get; set; }
         public int Points { get; set; }

         public void setData()
        {
            Console.Write("Indtast dancer navn: ");
            string name = Console.ReadLine();


            Console.Write("Indtast ders points: ");
            int points = 0;
                try
                {
                points = int.Parse(Console.ReadLine());
              
                }
                catch(Exception)
                {
                Console.WriteLine("Du skal indtaste et tal!");
                }
                Name = name;
                Points = points;

        }
        public static dancepoints operator+ (dancepoints a, dancepoints b)
        {
            dancepoints team = new dancepoints();
            team.Points = a.Points + b.Points;
            team.Name = a.Name + " & " + b.Name;
            return team;

        }
       


    }
    public class Input
    {
       public static string input(string s,bool nl=false)
        {
            
            Console.Write(s + ": ");
            string xx = Console.ReadLine();
            if (nl == true)
            {
                Console.WriteLine();
            }
            return xx;
        }

    }
}