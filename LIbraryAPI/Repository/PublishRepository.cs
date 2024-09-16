using AutoMapper;
using LIbraryAPI.DataContext;
using LIbraryAPI.DTOs.Publish;
using LIbraryAPI.Entity;
using LIbraryAPI.Validator;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Repository
{
    public class PublishRepository : IPublishRepository
    {
        private readonly ProjectDbContext _dbContext;

        private readonly IMapper _mapper;

        public PublishRepository(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PublishDto> PublishBookAuthor(PublishDto publishDto)
        {
            try
            {
                var validator = new PublishDtoValidator();
                var valid = await validator.ValidateAsync(publishDto);   

                if(valid.IsValid == false)
                {
                    throw new Exception("Book is not publish by an author. Validation Failed");
                } else
                {
                    var publishRequest = _mapper.Map<Publish>(publishDto);
                    _dbContext.Publish.Add(publishRequest);
                    _dbContext.SaveChanges();

                    PublishDto result = _mapper.Map<PublishDto>(publishRequest);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<PublishDto> UpdatePublishBookAuthor(PublishDto publishDto)
        {
            throw new NotImplementedException();
        }
    }
}
