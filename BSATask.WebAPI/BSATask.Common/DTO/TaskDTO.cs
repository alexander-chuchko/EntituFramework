using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSATask.Common.DTO
{
    public class TaskDTO : EntityBaseDTO
    {
        public int ProjectId { get; set; }
        public int PerformerId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public TaskStateDTO State { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? FinishedAt { get; set; }
    }
}
