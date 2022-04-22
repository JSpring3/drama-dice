using DramaDice.Models;


namespace DramaDice.Services
{
    public static class DiscordMsgService
    {
        public static DiscordMessage BuildDiscordMessage(DiscordMsgData data, string msgType = "Simple")
        {
            var explodedDiceFromReRolls = data.ReRollNewValues
                .Where(x => x.Category == DieCategory.Exploding).ToList();

            if (explodedDiceFromReRolls.Any())
            {
                data.ExplodedDice.AddRange(explodedDiceFromReRolls);
            }

            var fields = BuildFieldList(data, msgType).ToList();

            fields.AddRange(BuildRaiseGroups(data.SummedGroups));

            var author = BuildAuthor(data.CharacterName, data.CharacterType);

            var thumbnail = new Thumbnail("https://i.imgur.com/BHEbZ53.png");

            var embeds = new[]
            {
                new Embed($"{data.RaiseTotal} Raises with {data.TraitorDice.Count} Traitor Dice", "", 
                    "https://www.google.com",
                    4818554,
                    fields,
                    author,
                    thumbnail)
            };

            return new DiscordMessage(embeds);
        }

        private static IEnumerable<Field> BuildFieldList(DiscordMsgData data,string msgType)
        {
            if (msgType != "Simple")
            {
               return new List<Field>
                    {
                        BuildSuccessTarget(data.SuccessTarget),
                        BuildDicePool(data.DicePool),
                        BuildAllResultList(data.StartingDice),
                        BuildLiveResultList(data.LiveDice),
                        BuildUsePlusOne(data.UsePlusOne),
                        BuildUseLegendaryTrait(data.UseLegendary),
                        BuildUseExplodingDice(data.UseExploding),
                        BuildExplodingDiceCount(data.ExplodedDice.Count),
                        BuildExplodingResultList(data.ExplodedDice),
                        BuildHasRerolledDice(data.ReRollHistory),
                        BuildReRolledDiceCount(data.ReRollTotal),
                        BuildReRollHistoryList(data.ReRollHistory),
                        BuildReRollNewValuesList(data.ReRollNewValues),
                        BuildHasTraitorDice(data.TraitorDice),
                        BuildTraitorDice(data.TraitorDice)
                    };
            }

            return new List<Field>
                    {
                        BuildSuccessTarget(data.SuccessTarget),
                        BuildDicePool(data.DicePool),
                        BuildAllResultList(data.StartingDice),
                        BuildTraitorDice(data.TraitorDice),
                        BuildReRolledDiceCount(data.ReRollTotal),
                        BuildReRollNewValuesList(data.ReRollNewValues),
                    };

        }

        private static Field BuildSuccessTarget(int value)
        {
            return new Field("Success Target", $"{value}", true);
        }
        private static Field BuildAllResultList(IEnumerable<Die> allDice)
        {
            return new Field("Final Results", 
                $"[ {string.Join(", " , allDice.Select(d => d.Value))} ]",
                true);
        }
        private static Field BuildExplodingResultList(IEnumerable<Die> explodingDice)
        {
            return new Field("Exploding Dice",
                $"[ {string.Join(", ", explodingDice.Select(d => d.Value))} ]",
                true);
        }
        private static Field BuildLiveResultList(IEnumerable<Die> liveDice)
        {
            return new Field("Normal Dice",
                $"[ {string.Join(", ", liveDice.Select(d => d.Value))} ]",
                true);
        }
        private static Field BuildReRollHistoryList(IEnumerable<Die> reRollHistory)
        {
            return new Field("Re-Rolled Dice",
                $"[ {string.Join(", ", reRollHistory.Select(d => d.Value))} ]",
                true);
        }
        private static Field BuildReRollNewValuesList(IEnumerable<Die> reRollNewValues)
        {
            return new Field("Re-Rolled New Values",
                $"[ {string.Join(", ", reRollNewValues.Select(d => d.Value))} ]",
                true);
        }
        private static Field BuildTraitorDice(IEnumerable<Die> traitorDice)
        {
            return new Field("Traitor Dice", $"[ {string.Join(", ", traitorDice.Select(d => d.Value))} ]", true);
        }
        private static Field BuildHasTraitorDice(List<Die> traitorDice)
        {

            return new Field("Traitor Dice?", $"{CheckYesOrNo(traitorDice)}", true);
        }
        private static Field BuildUseExplodingDice(bool value)
        {
            return new Field("Exploding Dice?", $"{CheckYesOrNo(value)}", true);
        }

        private static Field BuildDicePool(int value)
        {
            return new Field("Dice Pool", $"{value}", true);
        }
        private static Field BuildExplodingDiceCount(int value)
        {
            return new Field("# of Exploded", $"{value}", true);
        }

        private static Field BuildReRolledDiceCount(int value)
        {
            return new Field("# of Re-Rolls", $"{value}", true);
        }

        private static Field BuildUsePlusOne(bool value)
        {
            return new Field("+1 All Dice?", $"{CheckYesOrNo(value)}", true);
        }

        private static Field BuildUseLegendaryTrait(bool value)
        {
            return new Field("Legendary Trait?", $"{CheckYesOrNo(value)}", true);
        }

        private static Field BuildHasRerolledDice(IEnumerable<Die> reRollHistory)
        {
            return new Field("Re-Rolled Die?", $"{CheckYesOrNo(reRollHistory)}", true);
        }

        private static List<Field> BuildRaiseGroups(List<RaiseGroup> raiseGroups)
        {
            var fields = new List<Field>();
            foreach (var raiseGroup in raiseGroups)
            {
                var field = new Field($"Raise {raiseGroup.Id}{CheckRaiseGroupType(raiseGroup)}",
                    $"[ {string.Join(", ", raiseGroup.DiceSet.Select(d => d.Value))} ]",
                    true);
                fields.Add(field);
            }

            return fields;
        }

        private static Author BuildAuthor(string name, string characterType)
        {
            return new Author(name, "https://www.google.com", BuildCharacterTypeIconUrl(characterType));
        }

        private static string CheckYesOrNo(bool value)
        {
            return value ? "Yes" : "No";
        }

        private static string CheckYesOrNo(IEnumerable<Die> list)
        {
            return list.Any() ? "Yes" : "No";
        }

        private static string CheckRaiseGroupType(RaiseGroup group)
        {
            return @group.RaiseGroupingType == GroupingType.Skilled ? " (Made 2 Raises)" : "";
        }

        private static string BuildCharacterTypeIconUrl(string characterType)
        {
            return characterType switch
            {
                "Hero" => "https://i.imgur.com/SUFmDok.png",
                "Villain" => "https://i.imgur.com/vDE989m.png",
                _ => "https://i.imgur.com/mRSLSDA.png"
            };
        }
    }
}
