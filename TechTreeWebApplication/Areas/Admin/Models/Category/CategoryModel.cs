﻿using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.Category
{
    public record CategoryModel : CategoryBaseModel
    {
        public int Id { get; set; }
    }
}
