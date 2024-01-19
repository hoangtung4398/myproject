﻿using AuthAPI.Repositorys.IRepository;
using BaseCourse.Dto;
using CouponAPI.Models.Dto;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly ResponseDto _response;
        private readonly ICourseRepository _courseRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly ILectureStorageService _lectureStorageService;
        private readonly ICategoryCourseRepository _categoryCourseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserCourseController(ICourseRepository courseRepository, ISectionRepository sectionRepository, ILectureRepository lectureRepository, IUserCourseRepository userCourseRepository, ILectureStorageService lectureStorageService, ICategoryCourseRepository categoryCourseRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _lectureRepository = lectureRepository;
            _userCourseRepository = userCourseRepository;
            _lectureStorageService = lectureStorageService;
            _categoryCourseRepository = categoryCourseRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        [HttpGet("ViewCourseDetail/{id}")]
        public IActionResult ViewCourseDetail(int id)
        {
            var course = _courseRepository.Get(x=>x.Id == id).Select(x => new CourseDetailDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Requirments = x.Requirments,
                Target = x.Target,
                Knowledge = x.Knowledge,
                LectureCount = x.Sections.SelectMany(x=>x.Lectures).Count(),
                EnrollmentsCount = x.UserCourses.Count,
                RelateCourses = x.Category.Courses.Select(x=>new RelateCourseDto
                {
                    Id = x.Id,
                    EnrollmentsCount = x.UserCourses.Count,
                    ImageUrl = x.ImageUrl,
                    Name = x.Name,
                    CreateUser = new DataItem
                    {
                        Id = x.CreateUser.Id,
                        Name = x.CreateUser.UserName, 
                    }
                }).Take(4).ToList(),
                Sections = x.Sections.Select(x => new SectionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    LectureCount = x.Lectures.Count,
                    Lectures = x.Lectures.Select(x => new LectureDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                    }).ToList()
                }).ToList(),
                CreateUser = new Instructor
                {
                    Id = x.CreateUser.Id,
                    Name = x.CreateUser.UserName,
                    Job = x.CreateUser.Job,
                    AboutMe = x.CreateUser.AboutMe,
                    CourseCount = x.CreateUser.Courses.Count,
                    
                }
            }).FirstOrDefault();
            _response.Result = course;
            return Ok(_response);
        }
    }
}
