﻿using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public static class UserMapper
    {
        public static UserDto UserToDto(User user)
        {
            List<CourseDto> courses = [];
            List<CourseDto> enrolledCourses = [];

            foreach (Course course in user.Courses)
            {
                courses.Add(new CourseDto()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                });
            }
            foreach (Course course in user.EnrolledCourses)
            {
                enrolledCourses.Add(new CourseDto()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                });
            }

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Courses = courses,
                EnrolledCourses = enrolledCourses
            };
        }
    }
}
