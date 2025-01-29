using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class UserReflectionService : IUserReflectionService
    {
        private readonly IUserReflectionRepository _userReflectionRepository;

        public UserReflectionService(IUserReflectionRepository userReflectionRepository)
        {
            _userReflectionRepository = userReflectionRepository;
        }

        public async Task<UserReflection> CreateAsync(UserReflection entity)
        {
            // check validity of entity
            if(entity == null)
            {
                throw new Exception("UserReflection cannot be null");
            }

            return await _userReflectionRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // check if id exist
            if(await _userReflectionRepository.GetByIdAsync(id) == null)
            {
                throw new Exception("UserReflection not found");
            }

            return await _userReflectionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserReflection>> GetAllAsync()
        {
            return await _userReflectionRepository.GetAllAsync();
        }

        public async Task<UserReflection> GetByIdAsync(int id)
        {
            return await _userReflectionRepository.GetByIdAsync(id);
        }

        public async Task<UserReflection> UpdateAsync(UserReflection entity)
        {
            // validate entity
            if (entity == null)
            {
                throw new Exception("UserReflection cannot be null");
            }

            // check if entity exist
            if (await _userReflectionRepository.GetByIdAsync(entity.id) == null)
            {
                throw new Exception("UserReflection not found");
            }

            return await _userReflectionRepository.UpdateAsync(entity);
        }
    }
}
