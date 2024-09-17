using LIbraryAPI.DTOs.Publish;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Repository
{
    public interface IPublishRepository
    {
        public Task<List<PublishDto>> GetAllPublish();
        public Task<PublishDto> PublishBookAuthor(PublishDto publishDto);

        public Task<PublishDto> UpdatePublishBookAuthor(PublishDto publishDto);
    }
}
