namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        #region Fields
        private const string NoMachines = "no" + Machines;
        private const string FirstLineFormat = "{0} - {1}";
        private const string Machines = " machines";
        private const string OneMachine = "1 machine";

        private string name;
        private IList<IMachine> machines;
        #endregion

        #region Constructor
        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return string.Copy(this.name);
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot should have a name.");
                }

                this.name = value;
            }
        }
        #endregion

        #region Method
        public void AddMachine(IMachine machine)
        {
            if (machines == null)
            {
                throw new ArgumentNullException("Machine cannot be null.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            string numberOfMachines;
            if (this.machines.Count == 0)
            {
                numberOfMachines = NoMachines;
            }
            else if (this.machines.Count == 1)
            {
                numberOfMachines = OneMachine;
            }
            else
            {
                numberOfMachines = this.machines.Count + Machines;
            }

            var result = new StringBuilder();
            result.AppendFormat(FirstLineFormat, this.name, numberOfMachines);
            if (this.machines.Count != 0)
            {
                result.AppendLine();
                var sortedMachines = this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name).ToList();

                for (int count = 0; count < sortedMachines.Count; count++)
                {
                    result.Append(sortedMachines[count].ToString());
                    if (count != sortedMachines.Count - 1)
                    {
                        result.AppendLine();
                    }
                }
            }

            return result.ToString();
        }
        #endregion
    }
}
