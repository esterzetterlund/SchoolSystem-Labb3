using System;
using System.Collections.Generic;

namespace SchoolSystem_Labb3.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string Grade1 { get; set; } = null!;

    public DateTime Dates { get; set; }

    public int FkstudentId { get; set; }

    public int FkcourseId { get; set; }
    public int? FkstaffId { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Student Fkstudent { get; set; } = null!;
}
