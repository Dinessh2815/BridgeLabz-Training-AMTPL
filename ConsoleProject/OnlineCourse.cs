using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    abstract class  OnlineCourse
    {
        private static int nextEnrollmentID = 2000;

        public int enrollmentID { get; private set; }
        public string Title;
        public string instructorName;
        public string Duration;

        public OnlineCourse(string title, string instructorName, string duration)
        {
            Title = title;
            this.instructorName = instructorName;
            Duration = duration;

            enrollmentID = nextEnrollmentID++;
        }

        public virtual void CourseDetails()
        {
            Console.WriteLine($"EnrollmentID: {enrollmentID}");
            Console.WriteLine($"Course Title: {Title}");
            Console.WriteLine($"Instructor: {instructorName}");
            Console.WriteLine($"Duration: {Duration}");
        }
    }

    class VideoCourse : OnlineCourse
    {
        public VideoCourse(string title, string instructorName,string duration) : base(title, instructorName, duration)
        {
        }

        public override void CourseDetails()
        {
            base.CourseDetails();
            Console.WriteLine("Type: Video Course");
        }
    }
}
