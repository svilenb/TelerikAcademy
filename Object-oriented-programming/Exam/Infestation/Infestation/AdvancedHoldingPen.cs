namespace Infestation
{
    using System;

    public class AdvancedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            ISupplement supplement;
            Unit unit = GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();                    
                    break;
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();                    
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();                    
                    break;
                case "Weapon":
                    supplement = new Weapon();                    
                    break;                
                default:
                    throw new ArgumentException("No such supplement");
            }

            unit.AddSupplement(supplement);
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {            
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);                    
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
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
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }         
        }
    }
}
