using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Interfaces;

namespace BSATask.Common.Sevices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddUser(UserDTO userDTO)
        {
            if (userDTO != null)
            {
                var user = _mapper.Map<DAL.Entities.User>(userDTO);
                _unitOfWork.Users.Insert<DAL.Entities.User>(user);
            }
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO userDTO = null;

            var user = _unitOfWork.Users.GetAll<DAL.Entities.User>().FirstOrDefault(v => v.Id == id);
            if (user != null)
            {
                userDTO = _mapper.Map<UserDTO>(user);
            }

            return userDTO;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<UserDTO> userDTOs = null;
            var users = _unitOfWork.Users.GetAll<DAL.Entities.User>();
            userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

            return userDTOs;
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var foundUser = _unitOfWork.Users.GetAll<DAL.Entities.User>().FirstOrDefault(v => v.Id == userDTO.Id);
            if (foundUser != null)
            {
                var user = _mapper.Map<DAL.Entities.User>(userDTO);
                _unitOfWork.Users.Update<DAL.Entities.User>(user);
            }
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetAll<DAL.Entities.User>().FirstOrDefault(v => v.Id == id);
            if (user != null)
            {
                _unitOfWork.Users.Delete<DAL.Entities.User>(id);
            }
        }
    }
}
