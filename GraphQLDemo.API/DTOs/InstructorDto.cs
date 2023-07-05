using GraphQLDemo.API.Schema.Queries;

namespace GraphQLDemo.API.DTOs
{
    public class InstructorDto : SchoolPersonType
    {
        public double Salary { get; set; }
    }
}
