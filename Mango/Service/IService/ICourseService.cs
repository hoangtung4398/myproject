﻿using BaseCourse.Dto;
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

        Task<ResponseDto> GetCategoryCourse();
		Task<ResponseDto> CreateCourse(RequestCourseDto course);
		Task<ResponseDto> UpdateCourse(RequestCourseDto course);
        Task<ResponseDto> GetCourseById(int id);
		Task<ResponseDto> DeleteCourse(int id);
		Task<ResponseDto> CreateSection(DataItem dataItem);
		Task<ResponseDto> UpdateLecture(int id, Lecture insertCourseDto);

        Task<ResponseDto> DeleteLecture(int id);
		Task<ResponseDto> UpdateSection(int id,Section section);
		Task <ResponseDto> GetSectionById(int id);
		Task<ResponseDto> DeleteSection(int id);
    }
}
