using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruebaNN.S.A.Domain.SeedWorks
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? Id { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}
