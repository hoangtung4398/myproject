using BaseCourse.Models;
using CouponAPI.Models.Dto;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services;
using CourseAPI.Services.IService;
using Microsoft.AspNetCore.Http;
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

        public CourseController( ICourseRepository courseRepository, ISectionRepository sectionRepository, ILectureRepository lectureRepository, IUserCourseRepository userCourseRepository, ILectureStorageService lectureStorageService)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _lectureRepository = lectureRepository;
            _userCourseRepository = userCourseRepository;
            _lectureStorageService = lectureStorageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var url = await _lectureStorageService.UploadLectureAsync(file);
            return Ok(_response);
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var courses = _courseRepository.Get(x=>x.Id == id).Select(x => new
            {
                x.Name,
                x.Id,
                x.Description,
                Section = x.Sections.Select(y=> new
                {
                    y.Id,
                     y.Name,
                    Video = y.Lectures.Select(z=>new { z.Id, z.Name,z.Url }).ToList()
                }).ToList()
            }).FirstOrDefault();
            _response.Result = courses;
            return Ok(_response);
        }
        [HttpPost("Create")]
        public IActionResult Create()
        {
            var course = new Course
            {
                CategoryId = 1,
                Name = "Test",
                Description = "Test",
                Requirments = "test",
                Target = "test",
                CreateUserId = 1,
                Sections = new List<Section>()
                {
                    new Section()
                    {
                        Name = "Test",
						Lectures = new List<Lecture>()
                        {
                            new Lecture()
                            {
                                Name = "test",
                                Url = "test",
                                Time = new System.TimeSpan(0,0,10,0,0)
                            }
                        }
                    }
                }
            };
            _courseRepository.Add(course);
            return Ok(_response);
        }
    }
}
