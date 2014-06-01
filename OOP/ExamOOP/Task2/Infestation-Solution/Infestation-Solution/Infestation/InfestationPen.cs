using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationPen : HoldingPen
    {
        public InfestationPen()
            : base()
        {
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerInhibitor":
                    {
                        var inhibitor= new PowerInhibitor();
                        var target = this.GetUnit(commandWords[2]);
                        target.AddSupplement(inhibitor);
                    }
                    break;
                case "HealthInhibitor":
                    {
                        var inhibitor = new HealthInhibitor();
                        var target = this.GetUnit(commandWords[2]);
                        target.AddSupplement(inhibitor);
                    }
                    break;
                case "AggressionInhibitor":
                    {
                        var inhibitor = new AggressionInhibitor();
                        var target = this.GetUnit(commandWords[2]);
                        target.AddSupplement(inhibitor);
                    }
                    break;
                case "Weapon":
                    {
                        var weapon = new Weapon();
                        var target = this.GetUnit(commandWords[2]);
                        target.AddSupplement(weapon);
                    }
                    break;
                default:
                    base.ExecuteAddSupplementCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
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
                    var targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
