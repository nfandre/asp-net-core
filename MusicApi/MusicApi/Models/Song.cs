﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MusicApi.Models
{
	public class Song
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Language { get; set; }

		public string Duration { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }

		public string ImageUrl { get; set; }

		public Song()
		{
		}
	}
}

