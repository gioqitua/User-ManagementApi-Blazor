using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_BLL.DTOs;
using User_Management_BLL.Repositories;

namespace User_Management_BLL.Services
{
    public class UserProfileService : ICrudService<UserProfileDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserProfileService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public void Delete(int id)
        {
            var profile = _unitOfWork.UserProfiles.GetById(id) ?? throw new Exception($"Can't Find Profile With Id : {id}");

            _unitOfWork.UserProfiles.Remove(profile);

            _unitOfWork.Commit();
        }

        public IEnumerable<UserProfileDto> GetAll()
        {
            return _unitOfWork.UserProfiles.Entities.Select(x => new UserProfileDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                PersonalNumber = x.PersonalNumber,
                UserId = x.User.Id
            });
        }

        public UserProfileDto GetById(int id)
        {
            var data = _unitOfWork.UserProfiles.GetById(id);

            if (data != null)
            {
                var result = new UserProfileDto
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Id = data.Id,
                    PersonalNumber = data.PersonalNumber,
                    UserId = data.User.Id
                };
                return result;
            }

            throw new Exception($"Can't Find Profile With Id : {id}");
        }

        public void Save(UserProfileDto entity)
        {
            var profile = _unitOfWork.UserProfiles.GetById(entity.Id);

            if (profile?.Id > 0)
            {
                profile.PersonalNumber = entity.PersonalNumber;
                profile.FirstName = entity.FirstName;
                profile.LastName = entity.LastName;

                _unitOfWork.UserProfiles.Update(profile);
            }
            else
            {
                _unitOfWork.UserProfiles.Add(entity.Map());
            }

            _unitOfWork.Commit();

        }
    }
}
