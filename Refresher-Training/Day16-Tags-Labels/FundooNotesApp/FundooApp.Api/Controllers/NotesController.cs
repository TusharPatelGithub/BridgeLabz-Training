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

        [HttpPost("{noteId}/tags/{tagId}")]
        public async Task<IActionResult> AddTag(int noteId, int tagId)
        {
            try
            {
                var userId = GetUserId();
                var result = await _noteService.AddTagToNoteAsync(userId, noteId, tagId);
                return Ok(new { message = "Tag added to note", data = result });
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

        [HttpDelete("{noteId}/tags/{tagId}")]
        public async Task<IActionResult> RemoveTag(int noteId, int tagId)
        {
            try
            {
                var userId = GetUserId();
                var result = await _noteService.RemoveTagFromNoteAsync(userId, noteId, tagId);
                return Ok(new { message = "Tag removed from note", data = result });
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
