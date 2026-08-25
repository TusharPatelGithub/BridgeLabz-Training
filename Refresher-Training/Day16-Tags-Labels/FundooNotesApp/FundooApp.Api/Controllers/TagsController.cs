using System.Security.Claims;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace FundooApp.Api.Controllers
{
    [ApiController]
    [Route("api/tags")]
    [Authorize]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim!);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagDTO createTagDto)
        {
            try
            {
                var userId = GetUserId();
                var result = await _tagService.CreateTagAsync(userId, createTagDto);
                return Ok(new { message = "Tag created successfully", data = result });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var userId = GetUserId();
            var result = await _tagService.GetAllTagsAsync(userId);
            return Ok(new { message = "Tags retrieved successfully", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            try
            {
                var userId = GetUserId();
                await _tagService.DeleteTagAsync(userId, id);
                return Ok(new { message = "Tag deleted successfully" });
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
