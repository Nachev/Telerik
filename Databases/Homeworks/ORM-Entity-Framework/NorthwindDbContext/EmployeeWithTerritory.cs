namespace NorthwindDbContext
{
    using System;
    using System.Linq;
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet 
        { 
            get
            {
                var result = new EntitySet<Territory>();                
                result.AddRange(this.Territories);
                return result;
            }

            set
            {
                this.Territories = value.ToList();
            }
        }
    }
}