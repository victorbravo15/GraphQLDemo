using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.ExtensionMethods;
using GraphQLDemo.API.Schema.Queries;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services.Courses;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        #region Campos
        private readonly CoursesRepository _coursesRepository;
        #endregion

        #region Constructor
        public Mutation(CoursesRepository coursesRepository)
        {
            this._coursesRepository = coursesRepository;
        }
        #endregion

        #region Métodos
        public async Task<CourseResult> CreateCourseAsync(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            var course = new CourseDto()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            var courseResult = (await this._coursesRepository.CreateCourse(course)).MapToCourseResult();

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);

            return courseResult;
        }

        public async Task<CourseResult> UpdateCourseAsync(Guid id, CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult course = (await this._coursesRepository.UpdateCourse(courseInput.MapToCourseDto(id))).MapToCourseResult();

            if (course == null)
            {
                throw new GraphQLException(new Error("Course not found.", "COURSE_NOT_FOUND"));
            }

            string updatedCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updatedCourseTopic, course);

            return course;
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {

            return await this._coursesRepository.DeleteCourse(id);
        }
        #endregion
    }
}
