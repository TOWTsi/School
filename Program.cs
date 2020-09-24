using System;
using System.Collections.Generic;

namespace Week2Day5 {
    class Program {
        // Week 2 Day 5 Mission 1: Battle simulator
        static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC) {

            var random = new Random();

            int hitDices = 2;
            int hitDiceSites = 6;

            int avoidAttackDice = 1;
            int avoidAttackDiceSites = 20;
            int avoidAttackResult = 0;

            int constitution = 5;

            int hitDamage = 0;

            Console.WriteLine($"Watch out, {monster} with {monsterHP} HP appears!");

            bool isMonsterAlive = true;
            while (isMonsterAlive) {
                foreach (string hero in heroes) {
                    hitDamage = 0;

                    /*for (int i = 0; i < hitDices; i++) {
                        hitDamage += random.Next(1, hitDiceSites + 1);
                    }*/
                    // Start Mission 2
                    hitDamage = DiceRoll(2, 6);
                    // Start Mission 2

                    monsterHP -= hitDamage;
                    // Start Part 2
                    if (monsterHP <= 0) {
                        monsterHP = 0;
                        isMonsterAlive = false;
                        Console.WriteLine($"{hero} hits the {monster} for {hitDamage} damage. {monster} has {monsterHP} HP left.");
                        break;
                    }
                    // End Part 2                    
                    Console.WriteLine($"{hero} hits the {monster} for {hitDamage} damage. {monster} has {monsterHP} HP left.");
                }
                // Start part 3
                if (isMonsterAlive) {

                    int randomPray = random.Next(0, heroes.Count);
                    avoidAttackResult = 0;
                    /*for (int i = 0; i < avoidAttackDice; i++) {
                        avoidAttackResult += random.Next(1, avoidAttackDiceSites + 1);
                    }*/
                    // Start Mission 2
                    avoidAttackResult = DiceRoll(1, 20);
                    // End Mission 2

                    Console.WriteLine($"The {monster} attacks {heroes[randomPray]}!");
                    if (avoidAttackResult + constitution < savingThrowDC) {
                        Console.WriteLine($"{heroes[randomPray]} rolls a {avoidAttackResult} and fails to be saved. {heroes[randomPray]} is killed.");
                        heroes.Remove(heroes[randomPray]);
                        if (heroes.Count == 0) {
                            Console.WriteLine($"The party has failed and the {monster} continues to go wild.");
                            break;
                        } else {
                            /* nothing to do */
                        }
                    } else {
                        Console.WriteLine($"{heroes[randomPray]} rolls a {avoidAttackResult} and is saved from the attack.");
                    }
                }
                // End part 3
            }
            if (!isMonsterAlive) {
                Console.WriteLine($"The {monster} collapses and the heroes celebrate their victory!");
            }
        }

        static void Main(string[] args) {
            List<string> heroes = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };
            //SimulateBattle(heroes, "Orc", 15, 12);
            SimulateBattle(heroes, "Orc", DiceRoll(2, 8, 6), 12);
            if (heroes.Count > 0) {
                //SimulateBattle(heroes, "Mage", 40, 20);
                SimulateBattle(heroes, "Mage", DiceRoll(9, 8), 20);
            } else {
                Console.WriteLine($"After one battle the quest ends. Unfortunately, none of the party members survived.");
            }
            if (heroes.Count > 0) {
                //SimulateBattle(heroes, "troll", 84, 18);
                SimulateBattle(heroes, "troll", DiceRoll(8, 10, 40), 18);
            } else {
                Console.WriteLine($"After two battles the quest ends. Unfortunately, none of the party members survived.");
            }
            if (heroes.Count > 0) {
                Console.WriteLine($"After three grueling battles, {String.Join(", ", heroes)} returns from the dungeons. Unfortunately, none of the other party members survived.");
            } else {
                Console.WriteLine($"After three battles the quest ends. Unfortunately, none of the party members survived.");
            }

        }

        // Week 2 Day 5 Mission 1: Dice roll simulator
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0) {
            var random = new Random();
            int diceRoll = 0;
            for (int i = 0; i < numberOfRolls; i++) {
                diceRoll += random.Next(1, diceSides + 1);
            }
            return diceRoll + fixedBonus;
        }
    }
}
