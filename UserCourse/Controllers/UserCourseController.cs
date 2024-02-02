using AuthAPI.Repositorys.IRepository;
using BaseCourse.Dto;
using BaseCourse.Dto.Dto;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserCourseController : ControllerBase
	{
		private readonly ResponseDto _response;
		private readonly ICourseRepository _courseRepository;
		private readonly IUserCourseRepository _userCourseRepository;
		private readonly IGetUserService _getUserService;
		public UserCourseController(IGetUserService getUserService, ICourseRepository courseRepository, IUserCourseRepository userCourseRepository)
		{
			_response = new ResponseDto();
			_courseRepository = courseRepository;
			_userCourseRepository = userCourseRepository;
			_getUserService = getUserService;
		}

		[HttpGet("ViewCourseDetail/{id}")]
		public IActionResult ViewCourseDetail(int id)
		{
			var user = _getUserService.GetUser();
			var course = _courseRepository.Get(x => x.Id == id).Select(x => new CourseDetailDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Requirments = x.Requirments,
				Target = x.Target,
				Knowledge = x.Knowledge,
				IsEnrolled = x.UserCourses.Any(x => x.CourseId == id && x.UserId == user.Id),
				LectureCount = x.Sections.SelectMany(x => x.Lectures).Count(),
				EnrollmentsCount = x.UserCourses.Count,
				RelateCourses = x.Category.Courses.Select(x => new RelateCourseDto
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

		[HttpPost("EnrollCourse")]
		public IActionResult EnrollCourse([FromBody] int courseId)
		{
			var user = _getUserService.GetUser();
			var userCourse = new BaseCourse.Models.UserCourse
			{
				CourseId = courseId,
				UserId = user.Id,
				CreateAt = DateTime.Now,
			};
			_userCourseRepository.Add(userCourse);
			_response.Success = true;
			return Ok(_response);
		}

		[HttpGet("WatchCourse/{id}")]
		public IActionResult WatchCourse(int id)
		{
			var user = _getUserService.GetUser();
			var isEnrolled = _userCourseRepository.Get(x => x.CourseId == id && x.UserId == user.Id).Any();
			if (!isEnrolled)
			{
				_response.Message = "You are not enrolled this course";
				_response.Success = false;
				return BadRequest(_response);
			}
			var course = _courseRepository.Get(x => x.Id == id).Select(x => new CourseDetailDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Requirments = x.Requirments,
				Target = x.Target,
				Knowledge = x.Knowledge,

				LectureCount = x.Sections.SelectMany(x => x.Lectures).Count(),
				RelateCourses = x.Category.Courses.Select(x => new RelateCourseDto
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
						VideoUrl = x.Url,
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

		[HttpGet("MyLearning")]
		public IActionResult MyLearning()
		{
			var user = _getUserService.GetUser();
			var courses = _userCourseRepository.Get(x => x.UserId == user.Id).Select(x => new CourseLearnDto
			{
				Id = x.Course.Id,
				Name = x.Course.Name,
				ImageUrl = x.Course.ImageUrl,
				Instructor = new InstructorDto
				{
					Id = x.Course.CreateUser.Id,
					Name = x.Course.CreateUser.UserName,
				}
			}).ToList();
			_response.Result = courses;
			return Ok(_response);
		}
		[HttpDelete("RemoveCourse/{courseId}")]
		public IActionResult RemoveCourse(int courseId)
		{
			var user = _getUserService.GetUser();
			var userCourse = _userCourseRepository.Get(x => x.CourseId == courseId && x.UserId == user.Id).FirstOrDefault();
			if (userCourse == null)
			{
				_response.Message = "You are not enrolled this course";
				_response.Success = false;
				return BadRequest(_response);
			}
			_userCourseRepository.Delete(userCourse.Id);
			_response.Success = true;
			return Ok(_response);
		}
		[HttpGet("SearchList")]
		public IActionResult SearchList(int categoryId = 0, string name = "")
		{
			var listCourse = _courseRepository.Get(x =>
				(categoryId == 0 || x.CategoryId == categoryId)
				&& (string.IsNullOrEmpty(name) || x.Name.Contains(name))).Select(x => new SearchListDto
				{
					Id = x.Id,
					Name = x.Name,
					ImageUrl = x.ImageUrl,
					EnrollmentsCount = x.UserCourses.Count,
					LectureCount = x.Sections.SelectMany(x => x.Lectures).Count(),
					instructorDto = new InstructorDto
					{
						Id = x.CreateUser.Id,
						Name = x.CreateUser.UserName,
					}
				});
			_response.Result = listCourse;
			return Ok(_response);
		}
	}
}
