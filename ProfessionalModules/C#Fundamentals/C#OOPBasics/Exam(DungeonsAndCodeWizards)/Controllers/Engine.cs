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

            while (true)
            {
                try
                {
                    var commandArgs = Console.ReadLine().Split(' ').ToList();
                    var currentCommand = commandArgs[0];
                    commandArgs.RemoveAt(0);

                    switch (currentCommand)
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(commandArgs.ToArray()));
                            break;

                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(commandArgs.ToArray()));
                            break;

                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(commandArgs.ToArray()));
                            break;

                        case "UseItem":
                            Console.WriteLine(master.UseItem(commandArgs.ToArray()));
                            break;

                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(commandArgs.ToArray()));
                            break;

                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(commandArgs.ToArray()));
                            break;

                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            break;

                        case "Attack":
                            Console.WriteLine(master.Attack(commandArgs.ToArray()));
                            break;

                        case "Heal":
                            Console.WriteLine(master.Heal(commandArgs.ToArray()));
                            break;

                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(commandArgs.ToArray()));
                            break;

                        case "IsGameOver":
                            Console.WriteLine(master.IsGameOver());
                            break;

                        default:
                            break;
                    }

                    if (master.IsGameOver())
                    {
                        break;
                    }
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
