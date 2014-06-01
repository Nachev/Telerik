namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        #region Fields
        private const double InitialHelathPoints = 200;
        private const string StealthFormat = " *Stealth: {0}";
        #endregion

        #region Constructor
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.StealthMode = stealthMode;
            this.HealthPoints = InitialHelathPoints;
            this.Targets = new List<string>();
        }
        #endregion

        #region Properies
        public bool StealthMode { get; private set; }
        #endregion

        #region Methods
        public void ToggleStealthMode()
        {
            this.StealthMode = this.StealthMode ? false : true;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendFormat(StealthFormat, this.StealthMode ? "ON" : "OFF");
            return result.ToString();
        }
        #endregion
    }
}
