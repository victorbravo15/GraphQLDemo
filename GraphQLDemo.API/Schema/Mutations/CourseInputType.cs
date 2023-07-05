﻿using GraphQLDemo.API.Models;
using GraphQLDemo.API.Schema.Queries;
using System;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
