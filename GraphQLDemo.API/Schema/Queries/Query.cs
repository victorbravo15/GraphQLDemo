using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.ExtensionMethods;
using GraphQLDemo.API.Schema.Filters;
using GraphQLDemo.API.Schema.Sorters;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Services.Courses;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        #region Campos 
        private readonly CoursesRepository _coursesRepository;
        #endregion

        public Query(CoursesRepository coursesRepository)
        {
            this._coursesRepository = coursesRepository;
        }

        [UseSorting]
        public async Task<List<CourseType>> GetCoursesAsync()
        {
            List<CourseDto> courses = await this._coursesRepository.GetCourses();

            return courses.Select(x => x.MapToCourseType()).ToList();
        }

        [UseDbContext(typeof(SchoolDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseFiltering(typeof(CourseFilterType))]
        //[UseSorting(typeof(CourseSortType))] (No funciona con esta versión a la hora de aplicarle un tipo)
        [UseSorting()]
        public IQueryable<CourseType> GetPaginatedCourses([ScopedService] SchoolDbContext context)
        {
            //No se permite hacer mapeo con método estático con la propiedad UseFiltering y ScopedService a la vez
            return context.Courses.Select(x =>
            new CourseType()
            {
                Id = x.Id,
                Name = x.Name,
                InstructorId = x.InstructorId,
                Subject = x.Subject,
            });
        }

        public async Task<CourseType> GetcourseByIdAsync(Guid id)
        {
            return (await this._coursesRepository.GetCourseById(id)).MapToCourseType();
        }

        [GraphQLDeprecated("This query is deprecated.")]
        public string Istructions => "Hellow World";
    }
}
