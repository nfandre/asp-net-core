using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Helpers;
using MusicApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    public class OldSongsController : Controller
    {

        private ApiDbContext _dbContext;

        public OldSongsController(ApiDbContext dbContext) {
            _dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<Song>> Get()
        {
            //return BadRequest();
            //return NotFound()
            //return StatusCode(StatusCodes.Status201Created)
            return Ok( await _dbContext.Songs.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<Song>> Get(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
            return Ok(song);
        }

        // api/songs/test/id
        [HttpGet("[action]/{id}")]
        public int  Test(int id)
        {
            return id;
        }

        //// POST api/values
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Song song)
        //{
        //    await _dbContext.Songs.AddAsync(song);
        //    await _dbContext.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);
        //}


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            song.ImageUrl = await FileHelper.UploadImage(song.Image);
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Song songObj)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null) {
                return NotFound("No record found against this Id");
            }
            song.Title = songObj.Title;
            song.Language = songObj.Language;
            song.Duration = songObj.Duration;

            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfuly");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this Id");
            }
             _dbContext.Songs.Remove(song);
            await _dbContext.SaveChangesAsync();
            return Ok("Record Deleted successfuly");

        }
    }
}

