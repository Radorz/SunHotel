using DataBase.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class EdificiosRepository : RepositoryBase<Edificio, SunHotelContext>
    {
        public EdificiosRepository(SunHotelContext context) : base(context)
        {

        }



    }
}
