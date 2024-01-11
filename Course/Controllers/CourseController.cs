using CouponAPI.Models.Dto;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;
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
        private readonly IVideoRepository _videoRepository;
        private readonly IUserCourseRepository _userCourseRepository;

        public CourseController( ICourseRepository courseRepository, ISectionRepository sectionRepository, IVideoRepository videoRepository, IUserCourseRepository userCourseRepository)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _videoRepository = videoRepository;
            _userCourseRepository = userCourseRepository;
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
                    Video = y.Videos.Select(z=>new { z.Id, z.Name,z.Url }).ToList()
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
                CreateUserId = "15b6bb00-f84e-4702-ad52-50d4b3742c7f",
                Sections = new List<Section>()
                {
                    new Section()
                    {
                        Name = "Test",
                        Videos = new List<Video>()
                        {
                            new Video()
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
