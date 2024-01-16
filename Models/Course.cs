using System;
using System.Collections.Generic;

namespace SchoolSystem_Labb3.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int Credit { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<StaffCourse> StaffCourses { get; set; } = new List<StaffCourse>();
}
