using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MusicApi.Models
{
	public class Song
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Title cannot be null or empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Language cannot be null or empty")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Duration cannot be null or empty")]
        public string Duration { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }

		public string ImageUrl { get; set; }

		public Song()
		{
		}
	}
}

