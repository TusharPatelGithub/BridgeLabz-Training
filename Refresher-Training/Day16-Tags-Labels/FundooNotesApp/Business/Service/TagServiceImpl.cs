using Business.Interface;
using Models.Dtos;
using Repository.Entity;
using Repository.Interface;

namespace Business.Service
{
    public class TagServiceImpl : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagServiceImpl(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagResponseDTO> CreateTagAsync(int userId, CreateTagDTO createTagDto)
        {
            var exists = await _tagRepository.NameExistsAsync(userId, createTagDto.Name);
            if (exists)
            {
                throw new InvalidOperationException("A tag with this name already exists");
            }

            var tag = new Tag
            {
                UserId = userId,
                Name = createTagDto.Name
            };

            var saved = await _tagRepository.AddAsync(tag);
            return new TagResponseDTO { TagId = saved.TagId, Name = saved.Name };
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync(int userId)
        {
            var tags = await _tagRepository.GetAllByUserIdAsync(userId);
            return tags.Select(t => new TagResponseDTO { TagId = t.TagId, Name = t.Name }).ToList();
        }

        public async Task DeleteTagAsync(int userId, int tagId)
        {
            // GetByIdAsync includes the Notes navigation, so this collection is populated
            var tag = await _tagRepository.GetByIdAsync(tagId);

            if (tag == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            if (tag.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not allowed to delete this tag");
            }

            // Detach from every note first - NoteTags no longer cascades from Tags,
            // so this must happen explicitly or the delete below would violate the FK.
            tag.Notes.Clear();

            await _tagRepository.DeleteAsync(tag);
        }
    }
}
