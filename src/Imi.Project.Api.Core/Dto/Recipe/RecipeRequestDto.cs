using Imi.Project.Api.Core.Dto.Category;
using Imi.Project.Api.Core.Dto.Instruction;
using Imi.Project.Api.Core.Helpers.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto.Recipe
{
    public class RecipeRequestDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "{0} can't be more than {1} characters!")]
        public string Title { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "{0} can't be more than {1} characters!")]
        public string Description { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "{0} must be between {1} and {2}")]
        public int PrepTime { get; set; }
        [Required]
        [Range(1, 999, ErrorMessage = "{0} must be between {1} and {2}")]
        public int CookTime { get; set; }
        [Required]
        [Range(1, 30, ErrorMessage = "{0} must be between {1} and {2}")]
        public int Servings { get; set; }
        public string ImgURL { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string DietName { get; set; }

    }
}
