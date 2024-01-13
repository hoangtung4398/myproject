using BaseCourse.Dto;
using BaseCourse.Models;
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
	public interface ICourseService
	{
		Task<ResponseDto> GetlistCourse();
		Task<ResponseDto> GetListSection(int id);
		Task<ResponseDto> GetListLecture(int id);
		Task<ResponseDto> CreateLecture(Lecture insertLectureDto);
		Task<ResponseDto> GetDetailLecture(int id);

	}
}
