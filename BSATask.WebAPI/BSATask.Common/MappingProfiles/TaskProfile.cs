namespace BSATask.Common.MappingProfiles
{
    public class TaskProfile : AutoMapper.Profile
    {
        public TaskProfile()
        {
            CreateMap<DAL.Entities.Team, DTO.TeamDTO>();

            CreateMap<DTO.TeamDTO, DAL.Entities.Team>();
        }
    }
}
