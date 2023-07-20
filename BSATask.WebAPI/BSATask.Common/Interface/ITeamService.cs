using BSATask.Common.DTO;
using BSATask.DAL.Entities;

namespace BSATask.Common.Interface
{
    public interface ITeamService
    {
        IEnumerable<DTO.TeamDTO> GetTeams();
        DTO.TeamDTO GetTeamById(int id);

        void AddTeam(DTO.TeamDTO teamDTO);

        void UpdateTeam(DTO.TeamDTO teamDTO);

        void DeleteTeam(int id);
    }
}
