﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class InsertDocumentDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public string Url { get; set; }
        public string NameAzure { get; set; }
        public int CreatedBy { get; set; }
    }
}
