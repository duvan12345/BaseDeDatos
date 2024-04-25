using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
   public  class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandID { get; set; }

        //costructor donde va recibir la informacion

        public Beer (int id, string name, int brandId)
        {
            this.Id = id;
            this.Name = name;
            this.BrandID = brandId;
        }

        public Beer( string name, int brandId)
        {
            this.Name = name;
            this.BrandID = brandId;
        }

    }
}
