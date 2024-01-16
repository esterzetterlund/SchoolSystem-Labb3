using System;
using System.Collections.Generic;

namespace SchoolSystem_Labb3.Models;

public partial class Student
{
    public int StudentID { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int? FkclassId { get; set; }

    public virtual Class? Fkclass { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
