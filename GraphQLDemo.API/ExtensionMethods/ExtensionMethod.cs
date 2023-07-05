using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Queries;
using System;

namespace GraphQLDemo.API.ExtensionMethods
{
    public static class ExtensionMethod
    {
        public static CourseDto MapToCourseDto(this CourseResult courseResult)
        {
            return new CourseDto()
            {
                Id = courseResult.Id,
                InstructorId = courseResult.InstructorId,
                Name = courseResult.Name,
                Subject = courseResult.Subject,
            };
        }

        public static CourseDto MapToCourseDto(this CourseInputType courseInput, Guid id)
        {
            return new CourseDto()
            {
                InstructorId = courseInput.InstructorId,
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                Id = id
            };
        }

        public static CourseResult MapToCourseResult(this CourseDto courseDto)
        {
            return new CourseResult()
            {
                Id = courseDto.Id,
                InstructorId = courseDto.InstructorId,
                Name = courseDto.Name,
                Subject = courseDto.Subject,
            };
        }
        public static CourseType MapToCourseType(this CourseDto courseDto)
        {
            return new CourseType()
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Subject = courseDto.Subject,
                InstructorId = courseDto.InstructorId
            };
        }

        public static InstructorType MapToInstructorType(this InstructorDto instructorDto)
        {
            return new InstructorType()
            {
                Id = instructorDto.Id,
                Courses = instructorDto.Courses,
                FirstName = instructorDto.FirstName,
                LastName = instructorDto.LastName,
                Salary = instructorDto.Salary
            };
        }
    }
}
