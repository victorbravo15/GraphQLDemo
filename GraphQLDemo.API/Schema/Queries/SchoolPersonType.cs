using GraphQLDemo.API.DTOs;
using System;
using System.Collections.Generic;

namespace GraphQLDemo.API.Schema.Queries
{
    public class SchoolPersonType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
