
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class PluginEffect : BaseEntityWithSoftDelete
    {
        public string Name { get; set; }
        public EffectType  Type { get; set; }

        [JsonIgnore]
        public ICollection<ImagePluginEffect> ImagePluginEffects { get; set; }
    }


    public enum EffectType
    {
        SampleEffect,
       
    }
}
