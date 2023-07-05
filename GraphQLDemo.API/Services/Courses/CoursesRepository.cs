using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.API.Services.Courses
{
    public class CoursesRepository
    {
        #region Campos
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;
        #endregion

        #region Constructor
        public CoursesRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        #endregion

        #region Metodos
        public async Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                context.Courses.Add(courseDto);
                await context.SaveChangesAsync();


                return courseDto;
            }
        }

        public async Task<CourseDto> UpdateCourse(CourseDto courseDto)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                CourseDto courseToUpdate = await context.Courses.Where(x => x.Id == courseDto.Id).FirstOrDefaultAsync();
                if (courseToUpdate == null)
                {
                    return null;
                }
                courseToUpdate.Subject = courseDto.Subject;
                courseToUpdate.InstructorId = courseDto.InstructorId;
                courseToUpdate.Name = courseDto.Name;
                await context.SaveChangesAsync();

                return courseDto;
            }
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                CourseDto courseToDelete = await context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (courseToDelete == null)
                {
                    return false;
                }
                context.Courses.Remove(courseToDelete);
                return await context.SaveChangesAsync() > 0;

            }
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                return await context.Courses.ToListAsync();
            }
        }
        public async Task<CourseDto> GetCourseById(Guid id)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                return await context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }
        #endregion
    }
}
