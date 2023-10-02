using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using TextGame.Character;
using TextGame.Items;
using random = System.Random;
using System.Collections.Generic;
using System.Net.Sockets;
using TextGame.Inventory;
using TextGame.Items;

namespace textAdventure
{
    public static class TextAdventure
    {
        private static void Main(string[] args)
        {
            gameTitle();
        }

        private static void gameTitle()
        {
            Console.WriteLine("Velkommen til Datamatik i Tønder The Game");
            Console.WriteLine("Tryk på Enter for at starte.");
            Console.ReadLine();
            Console.Clear();
            First();
        }
        //Kapitel 1
        private static void First()
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
            


            switch (choice)
            {
                case "1":
                case "Du siger at du ikke vil flytte dig.":
                case "kamp":
                    {
                        Console.WriteLine("Så siger Lukas 'så må vi jo slåse om det'");
                        Console.WriteLine("Lukas stiller sig i angrebs position og du gør det samme.");
                        Console.ReadLine();
                        LukasKamp();
                        break;
                    }
                case "2":
                case "Du flytter dig.":
                    {
                        Console.WriteLine("Du rejser dig op og finder en anden plads i lokalet.");
                        Console.ReadLine();
                        Second();
                        break;
                    }
                case "3":
                case "Tjek din taske":
                    {
                        Console.WriteLine("Du tjekker din taske");
                        Console.ReadLine();

                        foreach (string items in Taske.Inventory)
                        {
                            Console.WriteLine(items);
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Du skal vælge et af de 3 valgmuligheder");
                        Console.ReadLine();
                        First();
                        break;
                    }
                    
            }
        }

        //Kampen om pladsen
        public static void LukasKamp()
        {
            Player player = new Player();
            Lukas lukas = new Lukas();
            
            //impementer skade for Lukas
            while (player.playerHealth > 0 && lukas.lukasHealth > 0)
            {
                Console.WriteLine("Du har " + player.playerHealth + " liv.");
                Console.WriteLine("fjenden har " + lukas.lukasHealth + " liv.");
                Console.WriteLine("Hvad gør du? Angrib eller Forsvar?");

                //spillers valg
                string choice = Console.ReadLine();
                
                //spillers skade
                if (choice == "Angrib")
                {
                    //hvis man angriber
                    Console.WriteLine("Du angriber Lukas");
                    lukas.lukasHealth -= player.playerAttac;
                    Console.WriteLine("Du har gjort " + player.playerAttac + " skade på Lukas");
                }
                if (choice == "Forsvar")
                {
                    //hvis man blokerer
                    Console.WriteLine("Du forsvarer dig");

                }
                //fjendens skade
                if (lukas.lukasHealth > 0) 
                {
                    Console.WriteLine("Lukas langer ud efter dig med en lussing");
                    player.playerHealth -= lukas.lukasAttack;
                }
            }
            
            if (player.playerHealth <= 0)
            {
                gameOver();
            }
            else if (lukas.lukasHealth <= 0)
            {
                youWin();
                int x = player.GetExp();
                Console.WriteLine("Du vandt kampen over Lukas og fik " + x + " xp");
                Console.WriteLine("Lukas finder en anden plads.");
                player.xp += x;
                
                if (player.CanLevelUp())
                    player.LevelUp();
                
                Console.ReadLine();
                Second();
            }
        }
        
        
        //Kapitel 2
        private static void Second()
        {
            string choice;
            
            Console.WriteLine("Efter den første lektion er fædig forlader alle andre studerende lokalet.");
            Console.WriteLine("Du er den eneste tilbage i lokalet, Hvad vil du bruge din pause på?");
            Console.WriteLine("1. tjek de andre studerendes tasker.");
            Console.WriteLine("2. Gå i kantinen.");
            Console.WriteLine("3. Du venter i lokalet til pausen er over.");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "1":
                case "tjek de andre studerendes tasker.":
                case "loot":
                    {
                    TaskeTyveri();
                    break;
                    }

                case "2":
                case "Gå i kantinen.":
                    {
                        Console.WriteLine("Du gå hen i kantinen og ser hvad du kan finde.");
                        Kantine();
                        break;
                    }

                case "3":
                case "du venter i lokalet til pausen er over":
                    {
                        Console.WriteLine("Efter lidt tid kommer alle de andre studerende tilbage og næste lektion begynder.");
                        Console.ReadLine();
                        Third();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("du skal vælge et af de 3 valgmuligheder");
                        Console.ReadLine();
                        Second();
                        break;
                    }
                    
            }
            
        }
        
        
        //Tasketyveri
        private static void TaskeTyveri()
        {
            string choice;
            
            Console.WriteLine("Et par af de andre studerende har efterladt deres tasker i lokalet.");
            Console.WriteLine("Du har ikke meget tid inden de andre studerende kommer tilbage så du kan kun nå at tjekke en taske.");
            Console.WriteLine("De eneste tasker der ser spændende ud er Pernilles, Marks of din underviser Ibs tasker.");
            Console.WriteLine("Hvilken taske vil du tjekke?");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "1":
                case "Pernilles":
                case "Pernille":
                {
                    Console.WriteLine("Du sniger dig hen til Pernilles taske og åbner den.");
                    Console.WriteLine("Helt i bunden af tasken finder du en kniv.");
                    Console.WriteLine("Det undre dig ikke da Pernille kommer fra Højer.");
                    Console.WriteLine("Du tager kniven og putter den i din taske.");
                    Taske.Inventory.Add("Kniv");
                    Console.WriteLine("Du Kan høre at de andre studerende kommer tilbage fra pausen.");
                    Console.WriteLine("så du skynder dig tilbage til din plads.");
                    Third();
                    break;
                }


                case "2":
                case "Marks":
                case "Mark":
                {
                    Console.WriteLine("Du sniger dig hen til Marks taske og åbner den.");
                    Console.WriteLine("Det eneste du finder i Marks taske er et par Warhammer figurer.");
                    Console.WriteLine("Inden du når at putte dem i din taske høre du noget bag dig.");
                    Console.WriteLine("Du vender dig om og ser en vred Mark stå bag dig.");
                    Console.ReadLine();
                    markKamp();
                    break;
                }

                case "3":
                case "Ibs":
                case "Ib":
                {
                    Console.WriteLine("Du tøver lidt mens du sniger dig hen til din underviser Ibs taske.");
                    Console.WriteLine("Da du skal til at åbne Ibs taske mærker du en hånd på din skulder.");
                    Console.WriteLine("Du vender dig hurtigt om og ser ib stå helt op af dig");
                    ibKamp();
                    break;
                }    
                    
                
                
            }
        }

        public static void markKamp()
        {
            Mark mark = new Mark();
            Player player = new Player();

            while (player.playerHealth > 0 && mark.markHealth > 0)
            {
                Console.WriteLine("Du har " + player.playerHealth + " liv.");
                Console.WriteLine("Mark har " + mark.markHealth + " liv.");
                Console.WriteLine("Hvad gør du? Angrib eller Forsvar?");
                
                
                //spillers valg
                string choice = Console.ReadLine();
                
                //spillers skade
                if (choice == "Angrib")
                {
                    Console.WriteLine("Du angriber Mark");
                    mark.markHealth -= player.playerAttac;
                    Console.WriteLine("Du har gjort " + player.playerAttac + " skade på Mark");
                }

                if (choice == "Forsvar")
                {
                    Console.WriteLine("Du forsvarer dig");
                }
                if (mark.markAttack > 0)
                {
                    Console.WriteLine("Mark kresser dig med sine negle");
                    player.playerHealth -= mark.markAttack;
                }
            }

            if (player.playerHealth <= 0)
            {
                gameOver();
            }
            else if (mark.markHealth <= 0)
            {
                youWin();
                int x = player.GetExp();
                Console.WriteLine("Du vandt kampen over Mark og fik " + x + " xp");
                Console.WriteLine("Mark løber ud af lokalet.");
                player.xp += x;
                
                if (player.CanLevelUp())
                    player.LevelUp();
                
                Console.ReadLine();
                Third();
            }
            
        }

        public static void ibKamp()
        {
            Ib ib = new Ib();
            Player player = new Player();

            while (player.playerHealth > 0 && ib.ibHealth > 0)
            {
                Console.WriteLine("Du har " + player.playerHealth + " liv.");
                Console.WriteLine("Ib har " + ib.ibHealth + " liv.");
                Console.WriteLine("Du har ingen chance mod Ib men du er fanget i Kamp.");
                Console.WriteLine("Hvad gør du? Angrib eller Forsvar?");
                
                string choice = Console.ReadLine();
                
                if (choice == "Angrib")
                {
                    Console.WriteLine("Du angriber Ib");
                    ib.ibHealth -= player.playerAttac;
                    Console.WriteLine("Du har gjort " + player.playerAttac + " skade på Ib");
                }
                
                if (choice == "Forsvar")
                {
                    Console.WriteLine("Du forsvarer dig");
                }
                
                if (ib.ibAttack > 0)
                {
                    Console.WriteLine("Ib slår dig i hovedet med en kridt tavle");
                    player.playerHealth -= ib.ibAttack;
                }
            }

            if (player.playerHealth <= 0)
            {
                gameOver();
            }
            else if (ib.ibHealth <= 0)
            {
                youWin();
                int x = player.GetExp();
                Console.WriteLine("Du vandt kampen over Ib og fik " + x + " xp");
                player.xp += x;
                
                if (player.CanLevelUp())
                    player.LevelUp();
                
                Console.ReadLine();
                Third();
            }
        }
        
        
        // noget går galt efter man tilføjer en fransk hotdog til tasken
        //Kantine
        private static void Kantine()
        {
            //Taske taske = new Taske();
            string choice;
            
            Console.WriteLine("du Finder en Fransk Hotdog i kantinen");
            Console.WriteLine("Vil du købe den?");
            Console.WriteLine("1. Ja");
            Console.WriteLine("2. Nej");
            choice = Console.ReadLine().ToLower();


            switch (choice)
            {
                case"1":
                case"Ja":
                Taske.Inventory.Add("FranskHotdog");
                Console.WriteLine("Du har nu en Fransk Hotdog i din taske");
                Third();
                break;

                case "2":
                case "Nej":
                {
                    Console.WriteLine("Du går tilbage til klassen");
                    Third();
                    break;
                }
            }
            
        }
        
        // det er en test skal for om inventory virker
        //Kapitel 3
        private static void Third()
        {
            string choice;
            
            Console.WriteLine("Efter pausen kommer alle de andre studerende tilbage til klassen og den sidste lektion begynder.");
            Console.WriteLine("Iløbet af jeres sidste lektion får i en opgave for hvor i skal lave et text adventur spil.");
            Console.WriteLine("Efter lektionen er over får i fri og du tager hjem");
            Console.ReadLine();
            EndOfDemo();
        }
        
        private static void EndOfDemo()
        {
            Console.WriteLine("Dette er slutningen af demo håber du har nydt det.");
            Console.ReadLine();
            Console.Clear();
            gameTitle();
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
            
            
        }
        
        
    }
    
}
