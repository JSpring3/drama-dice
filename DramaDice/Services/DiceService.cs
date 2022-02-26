using System.Security.Cryptography;
using DramaDice.Models;

namespace DramaDice.Services;

public static class DiceService
{
    public static Result Roll(int dicePool, bool usePlusOne, bool useExploding, bool useLegendary)
    {
        var rollList = RollSeventhSeaDice(dicePool, usePlusOne, useExploding, useLegendary);
        rollList = FixDieIds(rollList);

        var liveDice = rollList.Where(x => x.Category == DieCategory.Live);
        var explodingDice = rollList.Where(x => x.Category == DieCategory.Exploding);

        return new Result(liveDice, explodingDice, rollList, DiceSort.Descending);
    } 

    public static List<Die> RollSeventhSeaDice (int dicePool, bool usePlusOne, bool useExploding, bool useLegendary)
    {
        var results = new List<Die>();

        for (var i = 1; i <= dicePool; i++)
        {
            if (useExploding)
            {
                results.AddRange(GenerateExplodingDice(usePlusOne, useLegendary , i));
            }
            else
            {
                results.Add(GenerateNormalDie(usePlusOne, useLegendary, i));
            }
        }

        return results;
    }

    public static List<Die> FixDieIds(List<Die> allDice)
    {
        var results = new List<Die>();
        var id = 1;
        foreach (var record in allDice)
        {
            record.Id = id;
            id++;
            results.Add(record);
        }

        return results;
    }

    private static IEnumerable<Die> GenerateExplodingDice(bool usePlusOne, bool useLegendary, int id)
    {
        var results = new List<Die>();
        int dieResult;
        var previousResult = 0;
        do
        {
            dieResult = CheckForLegendary(id, useLegendary);

            if (usePlusOne) dieResult += 1;

            var die = new Die
            {
                Id = id,
                Value = dieResult,
                Status = DieStatus.New,
                Category = previousResult >= 10 ? DieCategory.Exploding : DieCategory.Live,
                IsLegendary = useLegendary && id == 1
            };
            
            results.Add(die);
            previousResult = dieResult;
            id++;
        } while (dieResult >= 10);

        return results;
    }

    private static Die GenerateNormalDie(bool usePlusOne, bool useLegendary, int id)
    {
        var dieResult = CheckForLegendary(id, useLegendary);
        
        if (usePlusOne) dieResult += 1;

        return new Die
        {
            Id = id,
            Value = dieResult,
            Status = DieStatus.New,
            Category = DieCategory.Live,
            IsLegendary = useLegendary && id == 1
        };
    }

    private static int CheckForLegendary(int id, bool useLegendary)
    {
        return useLegendary && id == 1 ? 10 : GenerateInteger(1, 10);
    }

    private static int GenerateInteger(int min, int max)
    {
        return RandomNumberGenerator.GetInt32(min, max + 1);
    }
}