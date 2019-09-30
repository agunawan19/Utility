using System;

namespace CustomEntity
{
    public interface IEmployee
    {
        DateTime? HireDate { get; set; }
        string Status { get; set; }
        DateTime? TerminationDate { get; set; }
    }
}