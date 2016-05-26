using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace DAL
{
    [TableName("AspNetUsers")]
    [PrimaryKey("Id", AutoIncrement = false)]
    public class User
    {
       
        public bool Metric { get; set; }
        public bool BiologicalSex { get; set; } //0 is female, 1 is male

        public decimal Height { get; set; }

       
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

       
    }
}
