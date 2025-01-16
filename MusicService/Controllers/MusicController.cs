using Microsoft.AspNetCore.Mvc;
using MusicService.Models;
using MusicService.Services;

namespace MusicService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _service;

        public MusicController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var musics = await _service.GetAllAsync();
            return Ok(musics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var music = await _service.GetByIdAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadMusic([FromForm] string title, [FromForm] string artist, [FromForm] string genre, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file");

            var filePath = Path.Combine("/app/music_files", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var music = new Music
            {
                Title = title,
                Artist = artist,
                Genre = genre,
                FilePath = filePath,
                UploadDate = DateTime.UtcNow
            };

            await _service.AddAsync(music);

            return Ok(new FileUploadResult { FileName = file.FileName, FilePath = filePath });
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadMusic(int id)
        {
            var music = await _service.GetByIdAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(music.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(music.FilePath));
        }
    }
}