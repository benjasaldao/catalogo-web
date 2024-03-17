using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Descripción")]
        public string description { get; set; }

        public Brand() { }

        public Brand(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public override string ToString()
        {
            return description;
        }
    }
}
