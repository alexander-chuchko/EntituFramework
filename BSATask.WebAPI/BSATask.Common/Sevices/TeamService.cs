using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Interfaces;

namespace BSATask.Common.Sevices
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TeamDTO AddTeam(TeamDTO teamDTO)
        {
            if (teamDTO != null)
            {
                var team = _mapper.Map<DAL.Entities.Team>(teamDTO);
                _unitOfWork.Teams.Insert<DAL.Entities.Team>(team);
                _unitOfWork.Commit();
                var lastAddedTeam = _unitOfWork.Teams.GetAll<DAL.Entities.Team>().ToList().LastOrDefault();
                return _mapper.Map<TeamDTO>(lastAddedTeam);
            }
            return null;
        }

        public TeamDTO GetTeamById(int id)
        {
            TeamDTO teamDTO = null;

            var team = _unitOfWork.Teams.GetAll<DAL.Entities.Team>().FirstOrDefault(v => v.Id == id);
            if (team != null)
            {
                teamDTO = _mapper.Map<TeamDTO>(team);
            }

            return teamDTO;
        }

        public IEnumerable<TeamDTO> GetTeams()
        {
            IEnumerable<TeamDTO> teamsDTO = null;
            var teams = _unitOfWork.Teams.GetAll<DAL.Entities.Team>();
            teamsDTO = _mapper.Map<IEnumerable<TeamDTO>>(teams);

            return teamsDTO;
        }

        public void UpdateTeam(TeamDTO teamDTO)
        {
            var foundTeam = _unitOfWork.Teams.GetAll<DAL.Entities.Team>().FirstOrDefault(v => v.Id == teamDTO.Id);
            if (foundTeam != null)
            {
                var team = _mapper.Map<DAL.Entities.Team>(teamDTO);
                _unitOfWork.Teams.Update<DAL.Entities.Team>(team);
                _unitOfWork.Commit();
            }
        }

        public void DeleteTeam(int id)
        {
            var team = _unitOfWork.Teams.GetAll<DAL.Entities.Team>().FirstOrDefault(v => v.Id == id);
            if (team != null)
            {
                _unitOfWork.Teams.Delete<DAL.Entities.Team>(id);
                _unitOfWork.Commit();
            }
        }
    }
}
