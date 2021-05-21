using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public abstract class BaseModel
    {
        [Key]
        [DisplayName("Id")]
        public long? Id { get; set; }
        //data da inclusao 
        public DateTime? DataCriacao { get; set; }
    }
}
