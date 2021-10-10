using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image :BaseEntityWithAudit
    {
        public double? Radius { get; set; }
        public int? SizeX { get; set; }
        public int? SizeY { get; set; }
        public Guid StorageReference{ get; set; }


        public ICollection<ImagePluginEffect> ImagePluginEffects { get; set; }
    }
}
