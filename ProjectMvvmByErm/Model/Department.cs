using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvmByErm.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Position> Positions { get; set; }
        [NotMapped]
        public List<Position> DepartmentPositions
        {
            get
            {
                return DataWorker.GetAllPositionsByIdDepartment(Id);
            }
        }
    }
}
