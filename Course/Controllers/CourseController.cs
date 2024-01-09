using CouponAPI.Models.Dto;
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
        public IActionResult Get()
        {
            var courses = _courseRepository.Get(x=>x.Id ==1).Select(x => new
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
    }
}
