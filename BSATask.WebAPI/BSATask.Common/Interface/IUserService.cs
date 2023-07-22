
using BSATask.Common.DTO;

namespace BSATask.Common.Interface
{
    public interface IUserService
    {
        IEnumerable<DTO.UserDTO> GetUsers();
        DTO.UserDTO GetUserById(int id);

        UserDTO AddUser(UserDTO userDTO);
        void UpdateUser(DTO.UserDTO userDTO);

        void DeleteUser(int id);
    }
}
