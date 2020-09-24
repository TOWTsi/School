using System;
using System.Collections.Generic;

namespace Week2Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            // Week 2 Day 4 Mission 1: Generate characters, 5th edition Part 1

            List<int> roll = new List<int>();
            List<int> everyAbility = new List<int>();
            int abilities = 6;
            int dices = 4;

            for (int i = 0; i < abilities; i++) {
                roll.Clear();
                for (int j = 0; j < dices; j++) {
                    roll.Add(random.Next(1, 7));
                }                
                Console.Write($"You roll {String.Join(", ",roll)}. The ability score is ");
                int abilityScore = 0;
                roll.Sort();
                for (int k = 0; k < roll.Count - 1; k++) {
                    abilityScore += roll[k + 1];
                }
                Console.WriteLine($"{abilityScore}.");
                // Week 2 Day 4 Mission 1: Generate characters, 5th edition Part 2
                everyAbility.Add(abilityScore);
            }
            everyAbility.Sort();
            Console.WriteLine($"Your available ability scores are {String.Join(", ", everyAbility)}.");

            // Week 2 Day 4 Mission 2: BOSS LEVEL Battle with the basilisk Part 1

            List<string> members = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };

            int basiliskDices = 8;
            int basiliskDiceSites = 8;
            int basiliskHealth = 0;
            for (int i = 0; i < basiliskDices; i++) {
                basiliskHealth += random.Next(1, basiliskDiceSites + 1);
            }
            basiliskHealth += 16;
            Console.WriteLine($"A basilisk with {basiliskHealth} HP appears!");

            // Part 1
            //int hitDices = 2;
            //int hitDiceSites = 6;

            // Start part 3
            int hitDices = 1;
            int hitDiceSites = 4;

            int avoidGazeDices = 1;
            int avoidGazeDiceSites = 20;
            int avoidGazeResult = 0;
            int avoidGazeLimit = 12;

            int constitution = 5;
            // End part 3

            int hitDamage = 0;
            // Week 2 Day 4 Mission 2: BOSS LEVEL Battle with the basilisk Part 2
            bool isBasiliskAlive = true;
            while (isBasiliskAlive) {
                foreach (string member in members) {
                    hitDamage = 0;
                    for (int i = 0; i < hitDices; i++) {
                        hitDamage += random.Next(1, hitDiceSites + 1);
                    }
                    basiliskHealth -= hitDamage;
                    // Start Part 2
                    if (basiliskHealth <= 0) {
                        basiliskHealth = 0;
                        isBasiliskAlive = false;
                        Console.WriteLine($"{member} hits the basilisk for {hitDamage} damage. Basilisk has {basiliskHealth} HP left.");
                        break;
                    }
                    // End Part 2                    
                    Console.WriteLine($"{member} hits the basilisk for {hitDamage} damage. Basilisk has {basiliskHealth} HP left.");
                }
                // Start part 3
                if (isBasiliskAlive) {

                    int randomPray = random.Next(0, members.Count);
                    avoidGazeResult = 0;
                    for (int i = 0; i < avoidGazeDices; i++) {
                        avoidGazeResult += random.Next(1, avoidGazeDiceSites + 1);
                    }                    

                    Console.WriteLine($"The basilisk uses petrifying gaze on {members[randomPray]}!");
                    if (avoidGazeResult + constitution < avoidGazeLimit) {
                        Console.WriteLine($"{members[randomPray]} rolls a {avoidGazeResult} and fails to be saved. {members[randomPray]} is turned into stone.");
                        members.Remove(members[randomPray]);
                        if(members.Count == 0) {
                            Console.WriteLine("The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.");
                            break;
                        } else {
                            /* nothing to do */
                        }
                    } else {
                        Console.WriteLine($"{members[randomPray]} rolls a {avoidGazeResult} and is saved from the attack.");
                    }
                }
                // End part 3
            }
            if (!isBasiliskAlive) {
                Console.WriteLine("The basilisk collapses and the heroes celebrate their victory!");
            }                        
        }
    }
}
