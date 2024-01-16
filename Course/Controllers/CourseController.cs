﻿using BaseCourse.Dto;
using BaseCourse.Models;
using CouponAPI.Models.Dto;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services;
using CourseAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ResponseDto _response;
        private readonly ICourseRepository _courseRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly ILectureStorageService _lectureStorageService;
        private readonly ICategoryCourseRepository _categoryCourseRepository;

        public CourseController(ICourseRepository courseRepository, ISectionRepository sectionRepository, ILectureRepository lectureRepository, IUserCourseRepository userCourseRepository, ILectureStorageService lectureStorageService, ICategoryCourseRepository categoryCourseRepository)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _lectureRepository = lectureRepository;
            _userCourseRepository = userCourseRepository;
            _lectureStorageService = lectureStorageService;
            _categoryCourseRepository = categoryCourseRepository;
        }
        [HttpGet("GetCourseUser")]
        public IActionResult GetAll()
        {
            var rerult = _courseRepository.Get(x => 1 == 1).Select(x => new ListCourseDto
            {
                Id = x.Id,
                Name = x.Name,
                NameCategory = x.Category.Name,
                QualityLecture = x.Sections.SelectMany(x => x.Lectures).Any() ? x.Sections.Select(x => x.Lectures).Count() : 0,
            });
            _response.Result = rerult;
            return Ok(_response);
        }
        [HttpGet("GetListSection/{id}")]
        public IActionResult GetListSection(int id)
        {
            var listSection = _sectionRepository.Get(x => x.CourseId == id).Select(x => new ListSectionDto
            {
                Id = x.Id,
                Name = x.Name,
                QualityLecture = x.Lectures.Any() ? x.Lectures.Count() : 0,
            }).ToList();
            _response.Result = listSection;
            return Ok(_response);
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var courses = _courseRepository.Get(x => x.Id == id).Select(x => new
            {
                x.Name,
                x.Id,
                x.Description,
                Section = x.Sections.Select(y => new
                {
                    y.Id,
                    y.Name,
                    Video = y.Lectures.Select(z => new { z.Id, z.Name, z.Url }).ToList()
                }).ToList()
            }).FirstOrDefault();
            _response.Result = courses;
            return Ok(_response);
        }
        [HttpGet("GetListLectures/{id}")]
        public IActionResult GetLiscLecture(int id)
        {
            var listLecture = _lectureRepository.Get(x => x.SectionId == id).Select(x => new ListLectureDto
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url
            }).ToList();
            _response.Result = listLecture;
            return Ok(_response);
        }
        [HttpPost("CreatLecture")]
        public async Task<IActionResult> CreateLecture(Lecture insertLectureDto)
        {
            var id = _lectureRepository.Add(insertLectureDto);
            if (id != 0)
            {
                return Ok(_response);
            }
            _response.Success = false;
            return Ok(_response);
        }
        [HttpGet("DetailLecture/{id}")]
        public IActionResult DetailLecture(int id)
        {
            var lecture = _lectureRepository.Get(x => x.Id == id).Select(x => new DetailLectureDto
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                SectionId = x.SectionId
            }).FirstOrDefault();
            if (lecture == null)
            {
                _response.Success = false;
                _response.Message = "Not Found";
                return Ok(_response);
            }
            _response.Result = lecture;
            return Ok(_response);
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory()
        {
            var category =_categoryCourseRepository.GetAll();
            _response.Result = category;
            return Ok(_response);
        }


    }
}