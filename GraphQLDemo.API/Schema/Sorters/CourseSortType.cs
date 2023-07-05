using GraphQLDemo.API.Schema.Queries;
using HotChocolate.Data.Sorting;

namespace GraphQLDemo.API.Schema.Sorters
{
    public class CourseSortType : SortInputType<CourseType>
    {
        protected override void Configure(ISortInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(x => x.Id);
            descriptor.Ignore(x => x.InstructorId);
            base.Configure(descriptor);
        }
    }
}
