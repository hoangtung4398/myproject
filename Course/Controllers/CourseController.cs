using BaseCourse.Dto;
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
        private readonly IGetUserService _getUserService;

        public CourseController(ICourseRepository courseRepository, ISectionRepository sectionRepository, ILectureRepository lectureRepository, IUserCourseRepository userCourseRepository, ILectureStorageService lectureStorageService, ICategoryCourseRepository categoryCourseRepository, IGetUserService getUserService)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
            _sectionRepository = sectionRepository;
            _lectureRepository = lectureRepository;
            _userCourseRepository = userCourseRepository;
            _lectureStorageService = lectureStorageService;
            _categoryCourseRepository = categoryCourseRepository;
            _getUserService = getUserService;
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
            var category = _categoryCourseRepository.GetAll();
            _response.Result = category;
            return Ok(_response);
        }
        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse(RequestCourseDto course)
        {
            var courseInsert = new Course
            {
                Name = course.Name,
                Description = course.Description,
                Knowledge = course.Knowledge,
                Requirments = course.Requirments,
                ImageUrl = course.ImageUrl,
                CategoryId = course.CategoryId,
                Target = course.Target,
                //fix when have authen
                CreateUserId = 1
            };
            var Id = _courseRepository.Add(courseInsert);
            if (Id == 0)
            {
                _response.Success = false;
                return Ok(_response);
            }
            return Ok(_response);
        }
        [HttpPut("UpdateCourse/")]
        public IActionResult UpdateCourse(RequestCourseDto course)
        {
            var courseUpdate = _courseRepository.Get(x => x.Id == course.Id).Select(x => new Course
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Knowledge = x.Knowledge,
                Requirments = x.Requirments,
                ImageUrl = x.ImageUrl,
                CreateUserId = x.CreateUserId,
                CategoryId = x.CategoryId,
                Target = x.Target,
            }).FirstOrDefault();
            if (courseUpdate == null)
            {
                _response.Success = false;
                _response.Message = "Not Found";
                return Ok(_response);
            }

            courseUpdate.Name = course.Name;
            courseUpdate.Description = course.Description;
            courseUpdate.Knowledge = course.Knowledge;
            courseUpdate.Requirments = course.Requirments;
            if (!string.IsNullOrEmpty(course.ImageUrl))
                courseUpdate.ImageUrl = course.ImageUrl;
            courseUpdate.CategoryId = course.CategoryId;
            courseUpdate.Target = course.Target;
            //fix when have authen
            courseUpdate.CreateUserId = 1;
            _courseRepository.Update(courseUpdate);

            return Ok(_response);
        }
        [HttpGet("GetCourseById/{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseRepository.Get(x => x.Id == id).Select(x => new RequestCourseDto
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Requirments = x.Requirments,
                Target = x.Target,
                Knowledge = x.Knowledge,
            }).FirstOrDefault();
            if (course == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            _response.Result = course;
            return Ok(_response);
        }
        [HttpDelete("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var courseDelete = _courseRepository.Get(x => x.Id == id).FirstOrDefault();
            if (courseDelete == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            _courseRepository.Delete(id);
            return Ok(_response);
        }
        [HttpPost("CreateSection")]
        public IActionResult CreateSection(DataItem section)
        {
            var sectionInsert = new Section
            {
                CourseId = section.Id,
                Name = section.Name,
            };
            var id = _sectionRepository.Add(sectionInsert);
            if (id == 0)
            {
                _response.Success = false;
                return Ok(_response);
            }
            return Ok(_response);
        }
        [HttpPut("UpdateLecture/{id}")]
        public IActionResult UpdateLecture(int id, Lecture insertLectureDto)
        {
            var lectureUpdate = _lectureRepository.Get(x => x.Id == id).FirstOrDefault();
            if (lectureUpdate == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            lectureUpdate.Name = insertLectureDto.Name;
            lectureUpdate.Url = insertLectureDto.Url;
            lectureUpdate.NameFileAzure = insertLectureDto.NameFileAzure;
            _lectureRepository.Update(lectureUpdate);
            _response.Success = true;
            return Ok(_response);  
        }
        [HttpDelete("DeleteLecture/{id}")]
        public IActionResult DeleteLecture(int id)
        {
            _lectureRepository.Delete(id);
            return Ok(_response);
        }
        [HttpPut("UpdateSection/{id}")]
        public IActionResult UpdateSection(int id, Section section)
        {
            var sectionUpdate = _sectionRepository.Get(x => x.Id == id).FirstOrDefault();
            if (sectionUpdate == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            sectionUpdate.Name = section.Name;
            _sectionRepository.Update(sectionUpdate);
            return Ok(_response);
        }
        [HttpGet("GetSectionById/{id}")]
        public IActionResult GetSectionById(int id)
        {
            var section = _sectionRepository.Get(x => x.Id == id).Select(x => new Section
            {
                Id = x.Id,
                Name = x.Name,
                CourseId = x.CourseId,
            }).FirstOrDefault();
            if (section == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            _response.Result = section;
            return Ok(_response);
        }
        [HttpDelete("DeleteSection/{id}")]
        public IActionResult DeleteSection(int id)
        {
            var sectionDelete = _sectionRepository.Get(x => x.Id == id).FirstOrDefault();
            if (sectionDelete == null)
            {
                _response.Success = false;
                return Ok(_response);
            }
            _sectionRepository.Delete(id);
            return Ok(_response);
        }
    }
}
