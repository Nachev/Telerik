using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerInhibitor":
                    {
                        var powerInhibitor = new PowerInhibitor();
                        var targetUnit = base.GetUnit(commandWords[2]);
                        targetUnit.AddSupplement(powerInhibitor);
                        break;
                    }
                case "HealthInhibitor":
                    {
                        var healthInhibitor = new HealthInhibitor();
                        var targetUnit = base.GetUnit(commandWords[2]);
                        targetUnit.AddSupplement(healthInhibitor);
                        break;
                    }
                case "AggressionInhibitor":
                    {
                        var aggressionInhibitor = new AggressionInhibitor();
                        var targetUnit = base.GetUnit(commandWords[2]);
                        targetUnit.AddSupplement(aggressionInhibitor);
                        break;
                    }
                case "Weapon":
                    {
                        var weapon = new Weapon();
                        var targetUnit = base.GetUnit(commandWords[2]);
                        targetUnit.AddSupplement(weapon);
                        break;
                    }
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    base.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    base.InsertUnit(tank);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    base.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    base.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    Unit sourceUnit = this.GetUnit(interaction.SourceUnit);
                    if (sourceUnit.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(targetUnit.UnitClassification))
                    {
                        var infestationSpore = new InfestationSpores();
                        targetUnit.AddSupplement(infestationSpore);
                    }

                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
