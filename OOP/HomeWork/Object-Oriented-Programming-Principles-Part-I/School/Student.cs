namespace School
{
    using System.Text;

    internal class Student : People
    {
        public Student(string name, int classId, string comment) : base(name, comment)
        {
            this.ClassID = classId;
        }

        public int ClassID { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat(" class ID: {0}", this.ClassID);
            return result.ToString();
        }
    }
}
