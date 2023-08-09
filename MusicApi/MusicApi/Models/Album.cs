﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MusicApi.Models
{
	public class Album
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

		public int ArtistId { get; set; }

		public ICollection<Song> Songs { get; set; }

		public Album()
		{
		}
	}
}

