using System;
using System.Collections.Generic;

namespace SchoolSystem_Labb3.Models;

public partial class StaffCourse
{
    public int FkstaffId { get; set; }

    public int FkcourseId { get; set; }

    public int StaffCourseId { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Staff Fkstaff { get; set; } = null!;
}
