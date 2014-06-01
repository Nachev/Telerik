namespace StudentWithGroupProperty
{
    using System.Text;

    /* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group 
     * in the Student class. Extract all students from "Mathematics" department. Use the Join operator.*/

    public class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("group: {0} | ", this.GroupNumber);
            result.AppendFormat("department: {0}", this.DepartmentName);
            return result.ToString();
        }
    }
}
