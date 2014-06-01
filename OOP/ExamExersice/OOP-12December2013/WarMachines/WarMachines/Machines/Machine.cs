namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        #region Constants
        private const string NameFormat = "- {0}";
        private const string TypeFormat = " *Type: {0}";
        private const string HealthFormat = " *Health: {0}";
        private const string AttackFormat = " *Attack: {0}";
        private const string DefenseFormat = " *Defense: {0}";
        private const string TargetsFormat = " *Targets: {0}";
        private const string NoTargets = "None";
        #endregion

        #region Fields
        private IList<string> targets;
        private IPilot pilot;
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return string.Copy(this.name);
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Machine cannot be engaged without pilot.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Targets cannot be null.");
                }

                this.targets = value;
            }
        }
        #endregion

        #region Public methods
        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Target attacked cannot be null.");
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            string targetsToStr = this.targets.Count == 0 ? NoTargets : string.Join(", ", this.targets);
            string typeName = this.GetType().Name;
            StringBuilder result = new StringBuilder();
            result.AppendFormat(NameFormat, this.name);
            result.AppendLine();
            result.AppendFormat(TypeFormat, typeName);
            result.AppendLine();
            result.AppendFormat(HealthFormat, this.HealthPoints);
            result.AppendLine();
            result.AppendFormat(AttackFormat, this.AttackPoints);
            result.AppendLine();
            result.AppendFormat(DefenseFormat, this.DefensePoints);
            result.AppendLine();
            result.AppendFormat(TargetsFormat, targetsToStr);
            return result.ToString();
        }
        #endregion
    }
}
