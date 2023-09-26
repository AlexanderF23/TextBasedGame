using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace textAdventure
{
    class TextAdventure
    {
        static void Main(string[] args)
        {
            gameTitle();
            first();
        }

        public static void gameTitle()
        {
            Console.WriteLine("Velkommen til Datamatik i Tønder The Game");
            Console.WriteLine("Tryk på Enter for at starte.");
            Console.ReadLine();
            Console.Clear();
            first();
        }

        public static void first()
        {
            string choice;
            
            Console.WriteLine("Du er lige startet på 3 semester på Datamatiker uddannelsen i Tønder og det er din første dag.");
            Console.WriteLine("Du kommer ind i Klasse hvor alle dine nye medstuderende sidder og venter på at timen går i gang.");
            Console.WriteLine("Du sætter dig på en af de tomme pladser bagerst i lokalet mens din lære Ib starter undervisningen.");
            Console.WriteLine("Efter der er gået omkring 10 minutter af timen, kommer der en elev ind i lokalet og jeg er Lukas og du sidder på min plads.");
            Console.WriteLine("Hvad gør du?");
            Console.WriteLine("1. Du siger at du ikke vil flytte dig.");
            Console.WriteLine("2. Du flytter dig.");
            Console.WriteLine("3. Tjek din taske");
            Console.WriteLine("Valg: ");
            choice = Console.ReadLine().ToLower();
            Console.Clear();


            switch (choice)
            {
                case "1":
                case "Du siger at du ikke vil flytte dig.":
                case "kamp":
                    {
                        Console.WriteLine("Så siger Lukas 'så må vi jo slåse om det'");
                        Console.WriteLine("Lukas stiller sig i angrebs position og du gør det samme.");
                        Console.ReadLine();
                        gameOver();
                        break;
                    }
                case "2":
                case "Du flytter dig.":
                    {
                        Console.WriteLine("Du rejser dig op og finder en anden plads i lokalet.");
                        Console.ReadLine();
                        second();
                        break;
                    }
                case "3":
                case "Tjek din taske":
                    {
                        Console.WriteLine("Inventory: Virker ikke enu");
                        Console.ReadLine();
                        first();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Du skal vælge et af de 3 valgmuligheder");
                        Console.ReadLine();
                        first();
                        break;
                    }
                    
            }
        }

        public static void gameOver()
        {
            Console.Clear();
            Console.WriteLine("Du tabte kampen og Lukas tog din plads.");
            Console.WriteLine("du har Tabt spillet");
            Console.ReadLine();
            Console.Clear();
            gameTitle();
        }

        public static void youWin()
        {
            Console.Clear();
            Console.WriteLine("Du vandt kampen");
            Console.ReadLine();
            second();
            break;
        }
        
        
    }
    
}
