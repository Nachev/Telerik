namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Cars.Models;

    public class CarEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.Id == y.Id && x.Make == y.Make && x.Model == y.Model && x.Year == y.Year;
        }

        public int GetHashCode(Car obj)
        {
            if (object.ReferenceEquals(obj, null)) 
            {
                return 0;
            }

            int hashCodeName = obj.Id.GetHashCode();
            int hasCodeAge = obj.Make.GetHashCode();
            int hashCodeModel = obj.Model.GetHashCode();
            int hashCodeYear = obj.Year.GetHashCode();

            return hashCodeName ^ hasCodeAge ^ hashCodeModel ^ hashCodeYear;
        }
    }
}
