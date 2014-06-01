namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        #region Fields
        private const double InitialHealthPoints = 100;
        private const double DefenceModeDefenceBounus = 30;
        private const double DefenceModeAttackMinus = 40;
        private const string DefenseFormat = " *Defense: {0}";
        #endregion

        #region Constant
        public Tank(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = InitialHealthPoints;
            this.DefenseMode = false;
            this.ToggleDefenseMode();
            this.Targets = new List<string>();
        }
        #endregion

        #region Properties
        public bool DefenseMode { get; private set; }
        #endregion

        #region Methods
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += DefenceModeAttackMinus;
                this.DefensePoints -= DefenceModeDefenceBounus;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= DefenceModeAttackMinus;
                this.DefensePoints += DefenceModeDefenceBounus;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendFormat(DefenseFormat, this.DefenseMode ? "ON" : "OFF");
            return result.ToString();
        }
        #endregion
    }
}
