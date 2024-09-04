using CommonDataLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.Entities
{
    [Table("Configuration")]
    public class Configuration : BaseModel
    {
        [Key]
        public Guid ConfigId { get; set; } = Guid.NewGuid();
        [Desc("Name")]
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }

    }
}
