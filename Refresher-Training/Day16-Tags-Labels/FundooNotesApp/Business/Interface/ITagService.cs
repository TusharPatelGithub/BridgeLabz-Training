using Models.Dtos;

namespace Business.Interface
{
    public interface ITagService
    {
        Task<TagResponseDTO> CreateTagAsync(int userId, CreateTagDTO createTagDto);
        Task<List<TagResponseDTO>> GetAllTagsAsync(int userId);
        Task DeleteTagAsync(int userId, int tagId);
    }
}
