using HotChocolate;
using System;

namespace GraphQLDemo.API.Schema.Queries
{
    public class StudentType : SchoolPersonType
    {
        [GraphQLName("gpa")]
        public double GPA { get; set; }
    }
}
