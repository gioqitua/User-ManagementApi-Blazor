
using User_Management_BLL.DTOs;
using User_Management_BLL.Repositories;

namespace User_Management_BLL.Services
{
    public class UserService : ICrudService<UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            var currentUser = _unitOfWork.Users.GetById(id) ?? throw new Exception($"Can't Find User With Id : {id}");

            if (currentUser.UserProfile?.Id > 0)
            {
                _unitOfWork.UserProfiles.Remove(currentUser.UserProfile);
            }

            _unitOfWork.Users.Remove(currentUser);

            _unitOfWork.Commit();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _unitOfWork.Users.Entities.Select(x => x.Map());
        }

        public UserDto GetById(int id)
        {
            return _unitOfWork.Users.GetById(id)?.Map() ?? throw new Exception($"Can't Find User With Id : {id}");
        }

        public void Save(UserDto entity)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(entity.Id);

                if (user?.Id > 0)
                {
                    user.IsActive = entity.IsActive;
                    user.UserProfileId = entity.UserProfileId;
                    user.UserName = entity.UserName;
                    user.Email = entity.Email;
                    user.PasswordHash = entity.PasswordHash;

                    _unitOfWork.Users.Update(user);
                }
                else
                {
                    _unitOfWork.Users.Add(entity.Map());
                }

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
