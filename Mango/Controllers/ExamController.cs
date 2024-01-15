using BaseCourse.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index(List<QuestionDto> questionDtos)
        {
            questionDtos = new List<QuestionDto>()
            {
                new QuestionDto()
                {
                    Id = 1,
                    Name = "Câu 1",
                    AnswerDtos = new List<AnswerDto>()
                    {
                        new AnswerDto()
                        {
                            Id = 1,
                            Name = "Đáp án 1",
                        },
                        new AnswerDto()
                        {
                            Id = 2,
                            Name = "Đáp án 2",
                        },
                        new AnswerDto()
                        {
                            Id = 3,
                            Name = "Đáp án 3",
                        },
                        new AnswerDto()
                        {
                            Id = 4,
                            Name = "Đáp án 4",
                        }
                    },

                },
                new QuestionDto()
                {
                    Id = 2,
                    Name = "Câu 2",
                    AnswerDtos = new List<AnswerDto>()
                    {
                        new AnswerDto()
                        {
                            Id = 1,
                            Name = "Đáp án 1",
                        },
                        new AnswerDto()
                        {
                            Id = 2,
                            Name = "Đáp án 2",
                        },
                        new AnswerDto()
                        {
                            Id = 3,
                            Name = "Đáp án 3",
                        },
                        new AnswerDto()
                        {
                            Id = 4,
                            Name = "Đáp án 4",
                        }
                    }
            },
            };
            return View(questionDtos);
        }
        [HttpPost]
        public IActionResult Submit(IFormCollection collection)
        {

            return View();
        }
    }
}
