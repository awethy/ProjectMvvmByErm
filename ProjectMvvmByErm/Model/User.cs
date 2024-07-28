using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvmByErm.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        [NotMapped]
        public Position UserPosition
        {
            get
            {
                return DataWorker.GetPositionById(PositionId);
            }
        }
    }
}