using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_BTS.Models
{
    public class ShoppingModels
    {
        private ShoppingContext context;

        public int id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
