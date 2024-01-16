using System;
using System.Collections.Generic;

namespace SchoolSystem_Labb3.Models;

public partial class Staff
{

    public int StaffId { get; set; }

    public string Position { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<StaffCourse> StaffCourses { get; set; } = new List<StaffCourse>();
}
