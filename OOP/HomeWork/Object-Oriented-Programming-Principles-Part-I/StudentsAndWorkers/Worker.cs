namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        private const int WORK_DAYS_PER_WEEK = 5;

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : this(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        
        public decimal WeekSalary { get; private set; }

        public double WorkHoursPerDay { get; private set; }

        /// <summary>
        /// Returns money earned per hour
        /// </summary>
        public decimal MoneyPerHour()
        {
            decimal result = (this.WeekSalary / WORK_DAYS_PER_WEEK) / (decimal)this.WorkHoursPerDay;
            return result;
        }
    }
}
