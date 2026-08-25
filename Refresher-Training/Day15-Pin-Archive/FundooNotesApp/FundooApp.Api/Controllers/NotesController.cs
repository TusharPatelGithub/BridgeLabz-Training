using System.Security.Claims;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace FundooApp.Api.Controllers
{
    [ApiController]
    [Route("api/notes")]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim!);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteDTO createNoteDto)
        {
            var userId = GetUserId();
            var result = await _noteService.CreateNoteAsync(userId, createNoteDto);
            return Ok(new { message = "Note created successfully", data = result });
        }

        // Examples:
        //   GET /api/notes                          -> all non-trashed notes
        //   GET /api/notes?search=milk               -> title/description contains "milk"
        //   GET /api/notes?pin=true                  -> only pinned
        //   GET /api/notes?archive=true               -> only archived
        //   GET /api/notes?trash=true                 -> only trashed
        //   GET /api/notes?search=milk&pin=true       -> combined filters
        [HttpGet]
        public async Task<IActionResult> GetAllNotes(
            [FromQuery] string? search,
            [FromQuery] bool? pin,
            [FromQuery] bool? archive,
            [FromQuery] bool? trash)
        {
            var userId = GetUserId();
            var result = await _noteService.GetAllNotesAsync(userId, search, pin, archive, trash);
            return Ok(new { message = "Notes retrieved successfully", data = result });
        }

        [HttpPatch("{id}/pin")]
        public async Task<IActionResult> TogglePin(int id)
        {
            return await HandleToggle(id, _noteService.TogglePinAsync);
        }

        [HttpPatch("{id}/archive")]
        public async Task<IActionResult> ToggleArchive(int id)
        {
            return await HandleToggle(id, _noteService.ToggleArchiveAsync);
        }

        [HttpPatch("{id}/trash")]
        public async Task<IActionResult> ToggleTrash(int id)
        {
            return await HandleToggle(id, _noteService.ToggleTrashAsync);
        }

        private async Task<IActionResult> HandleToggle(int id, Func<int, int, Task<NoteResponseDTO>> toggleAction)
        {
            try
            {
                var userId = GetUserId();
                var result = await toggleAction(userId, id);
                return Ok(new { message = "Note updated successfully", data = result });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                var userId = GetUserId();
                await _noteService.DeleteNoteAsync(userId, id);
                return Ok(new { message = "Note deleted successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }
    }
}
