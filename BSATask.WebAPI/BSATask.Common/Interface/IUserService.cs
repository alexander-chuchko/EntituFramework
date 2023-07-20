
namespace BSATask.Common.Interface
{
    public interface IUserService
    {
        IEnumerable<DTO.UserDTO> GetUsers();
        DTO.UserDTO GetUserById(int id);

        void AddUser(DTO.UserDTO userDTO);
        void UpdateUser(DTO.UserDTO userDTO);

        void DeleteUser(int id);
    }
}
