namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;    
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data
                .Courses
                .All()
                .Select(CourseModel.FromCourse);

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var course = this.data
                .Courses
                .All()
                .Where(c => c.Id == id)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return BadRequest("Course does not exist - invalid id");
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                Name = course.Name
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;
            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = this.data.Courses.All().FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such course does not exists!");
            }

            existingCourse.Name = course.Name;
            this.data.SaveChanges();

            course.Id = id;
            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCourse = this.data.Courses.All().FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such course does not exists!");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(int id, int studentId)
        {
            var course = this.data.Courses.All().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return BadRequest("Such course does not exists - invalid id!");
            }

            var student = this.data.Students.All().FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return BadRequest("Such student does not exists - invalid id!");
            }

            course.Students.Add(student);
            this.data.SaveChanges();

            return Ok();
        }      
    }
}
