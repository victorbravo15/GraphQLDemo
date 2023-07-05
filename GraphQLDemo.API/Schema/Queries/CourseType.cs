using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.ExtensionMethods;
using GraphQLDemo.API.Models;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDemo.API.Schema.Queries
{

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLIgnore]
        public Guid InstructorId { get; set; }

        [GraphQLNonNullType]
        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorsDataLoader)
        {
            return (await instructorsDataLoader.LoadAsync(this.InstructorId, CancellationToken.None)).MapToInstructorType();
        }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
