using System;
using System.Collections.Generic;
using System.Threading;

namespace Week3Day1 {
    class Program {
        static void Main(string[] args) {
            // Week 3 Day 1 Mission 1: Fractal
            //MandelbrotFractal();

            // Week 3 Day 1 Mission 2: A better Join 
            /*
            List<string> heroes = new List<string>{ "Jazlyn", "Theron", "Dayana", "Rolando" };
            List<string> heroesForTwo = new List<string>{ "Jazlyn", "Theron"};
            List<string> hero = new List<string>{ "Jazlyn"};
            List<string> noHero = new List<string>();
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(heroes, true)}.");
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(heroes, false)}.");
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(heroesForTwo, false)}.");
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(hero, false)}.");
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(noHero, false)}.");
            */

            // Week 3 Day 1 Mission 3: Ordinal numbers 
            /*
            for (int i = 1; i < 129; i++) {
                Console.WriteLine($"{OrdinalNumber(i)}");
            }
            */
            theMatrix();
        }

        // Week 3 Day 1 Mission 1: Fractal   
        static void MandelbrotFractal() {

            for (int y = -10; y < 10; y++) {
                for (int x = 1; x < 80; x++) {
                    double r = 0;
                    double i = 0;
                    int k = -1;

                    while (r * r + i * i < 11 && k < 112) {
                        double t = r;
                        r = t * t - i * i - 2.3 + x / 24.5;
                        i = 2 * t * i + y / 8.5;
                        k++;
                    }

                    int c = k % 16;
                    Console.BackgroundColor = (ConsoleColor)c;
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        // Week 3 Day 1 Mission 2: A better Join  
        static string JoinWithAnd(List<string> items, bool useSerialComma = true) {
            string result = "";
            if (items.Count == 0) {
                return result;
            } else if (items.Count == 1) {
                result = items[0];
            } else if (items.Count == 2) {
                result = items[0] + " and " + items[1];
            } else {
                var itemscopy = new List<string>(items);
                if (useSerialComma) {
                    itemscopy[itemscopy.Count - 1] = "and " + itemscopy[itemscopy.Count - 1];
                } else {
                    itemscopy[itemscopy.Count - 2] += " and " + itemscopy[itemscopy.Count - 1];
                    itemscopy.Remove(itemscopy[itemscopy.Count - 1]);
                }
                result = String.Join(", ", itemscopy);
            }
            return result;
        }

        // Week 3 Day 1 Mission 3: Ordinal numbers 
        static string OrdinalNumber(int number) {
            string result = "";
            int lastDigit = number % 10;
            int secondLastDigit = (number / 10) % 10;

            if (secondLastDigit == 1) {
                result = number + "th";
            } else if (lastDigit == 1) {
                result = number + "st";
            } else if (lastDigit == 2) {
                result = number + "nd";
            } else if (lastDigit == 3) {
                result = number + "rd";
            } else {
                result = number + "th";
            }

            return result;
        }

        // Week 3 Day 1 Mission 4: The Matrix 
        static void theMatrix() {
            var streams = new List<int>();
            var random = new Random();
            var symbols = "!@#$%^&*()_+-=[];',.\\/~{}:|<>?";

            for (int i = 0; i < 10; i++) streams.Add(random.Next(0, 80));

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true) {
                for (int x = 0; x < 80; x++) {
                    Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');
                }

                Console.WriteLine();
                Thread.Sleep(100);


                if (random.Next(3) == 0) {
                    if (streams.Count > 0) {
                        streams.RemoveAt(random.Next(streams.Count));
                    }
                }
                if (random.Next(3) == 0) streams.Add(random.Next(0, 80));

            }
        }
    }
}
