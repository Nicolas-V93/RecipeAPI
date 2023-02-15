using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Review : BaseEntity
    {
        [MaxLength(500)]
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTimeStamp { get; set; }

        // Navigation Properties
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
    }
}
