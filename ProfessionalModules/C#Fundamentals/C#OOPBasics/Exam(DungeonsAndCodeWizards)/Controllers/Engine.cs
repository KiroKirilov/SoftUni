using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Controllers
{
    public class Engine
    {
        public void Run()
        {
            var master = new DungeonMaster();
            var isRunning = true;

            while (isRunning)
            {
                

                try
                {
                    var commandArgs = Console.ReadLine().Split(' ').ToList();
                    var currentCommand = commandArgs[0];
                    commandArgs.RemoveAt(0);
                    var cmdThisTurn = false;

                    switch (currentCommand)
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "UseItem":
                            Console.WriteLine(master.UseItem(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            cmdThisTurn = true;
                            break;

                        case "Attack":
                            Console.WriteLine(master.Attack(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "Heal":
                            Console.WriteLine(master.Heal(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(commandArgs.ToArray()));
                            cmdThisTurn = true;
                            break;

                        case "IsGameOver":
                            Console.WriteLine(master.IsGameOver());
                            cmdThisTurn = true;
                            break;

                        default:
                            break;
                    }

                    if (master.IsGameOver() || !cmdThisTurn)
                    {
                        break;
                    }
                    cmdThisTurn = false;
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine($"Parameter Error: {argEx.Message}");
                }
                catch (InvalidOperationException invOpEx)
                {
                    Console.WriteLine($"Invalid Operation: {invOpEx.Message}");
                }
                catch (Exception e)
                {
                    break;
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(master.GetStats());

        }
    }
}
