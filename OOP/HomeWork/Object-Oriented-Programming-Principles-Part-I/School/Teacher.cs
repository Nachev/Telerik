namespace School
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Teacher : People
    {
        private IList<Discipline> disciplines;

        public Teacher(string name, IEnumerable<Discipline> inputDisciplines, string comment = null)
            : base(name, comment)
        {
            this.disciplines = new List<Discipline>();

            foreach (var discipline in inputDisciplines)
            {
                this.disciplines.Add(discipline);
            }
        }

        public IList<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }

        public override string ToString()
        {
            var result = base.ToString() + " Disciplines: " + string.Join(", ", this.Disciplines.Select(i => i.Name));
            return result;
        }
    }
}
