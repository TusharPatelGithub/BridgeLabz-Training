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
        public async Task<IActionResult> GetAllNotes()
        {
            var userId = GetUserId();
            var result = await _noteService.GetAllNotesAsync(userId);
            return Ok(new { message = "Notes retrieved successfully", data = result });
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
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }
    }
}
