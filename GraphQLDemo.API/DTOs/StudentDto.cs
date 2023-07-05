using GraphQLDemo.API.Schema.Queries;

namespace GraphQLDemo.API.DTOs
{
    public class StudentDto : SchoolPersonType
    {
        public double GPA { get; set; }
    }
}
