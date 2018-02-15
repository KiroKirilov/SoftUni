using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var trainers = new Dictionary<string,Trainer>();

        while ((input=Console.ReadLine())!="Tournament")
        {
            var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var trainerName = data[0];
            var pkmnName = data[1];
            var pkmnType = data[2];
            var pkmnHp = int.Parse(data[3]);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName,new Trainer(trainerName));
            }
            var currentPkmn = new Pokemon(pkmnName,pkmnType,pkmnHp);
            trainers[trainerName].Pokemon.Add(currentPkmn);
        }

        while ((input=Console.ReadLine())!="End")
        {
            var type = input.Trim();

            foreach (var trainer in trainers)
            {
                if (!trainer.Value.ContainsType(type))
                {
                    trainer.Value.DecreaseHelth();
                    trainer.Value.RemoveDead();
                }
                else
                {
                    trainer.Value.AmountOfBadges++;
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t=>t.Value.AmountOfBadges))
        {
            Console.WriteLine($"{trainer.Key} {trainer.Value.AmountOfBadges} {trainer.Value.Pokemon.Count}");
        }
    }
}

