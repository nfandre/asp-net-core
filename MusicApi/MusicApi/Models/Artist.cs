﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MusicApi.Models
{
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

		public ICollection<Album> Albums { get; set; }
		public ICollection<Song> Songs { get; set; }
	}
}