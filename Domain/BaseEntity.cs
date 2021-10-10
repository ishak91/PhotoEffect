using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }      
    }

    public class BaseEntityWithSoftDelete : BaseEntity, ISoftDeleteEntity
    {
        public bool Deleted { get; set; }
    }

    public class BaseEntityWithAudit : BaseEntityWithSoftDelete, IAuditEntity
    {       
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public interface IAuditEntity
    {
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public interface ISoftDeleteEntity
    {
        public bool Deleted { get; set; }
    }



}
