namespace School
{
    using System;
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        IList<IStudent> Students { get; }

        void InsertStudent(IStudent studentTobeInserted);

        void RemoveStudent(IStudent studentTobeInserted);
    }
}