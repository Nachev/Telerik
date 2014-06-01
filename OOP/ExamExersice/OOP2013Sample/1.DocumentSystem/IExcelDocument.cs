namespace DocumentSystem
{
    using System;

    public interface IExcelDocument
    {
        int NumberOfColumns { get; }

        int NumberOfRows { get; }
    }
}