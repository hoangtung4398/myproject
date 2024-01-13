using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
	public class InsertLectureDto
	{
		public string Name { get; set; }
		public IFormFile File { get; set; }
		public int SectionId {  get; set; }
	}
}
