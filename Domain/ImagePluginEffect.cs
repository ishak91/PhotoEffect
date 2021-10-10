using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ImagePluginEffect : BaseEntity
    {
        public int ImageId { get; set; }
        public int PluginEffectId { get; set; }


        public PluginEffect PluginEffect { get; set; }
        [JsonIgnore]
        public Image Image { get; set; }
    }
}
