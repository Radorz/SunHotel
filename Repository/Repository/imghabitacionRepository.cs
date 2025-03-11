using DataBase.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class imghabitacionRepository : RepositoryBase<ImgHabitaciones, SunHotelContext>
    {
        public imghabitacionRepository(SunHotelContext context) : base(context)
        {

        }



    }
}
