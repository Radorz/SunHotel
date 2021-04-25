using DataBase.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class EdificiosRepository : RepositoryBase<Edificio, ba4cpg3zvekknrm1lhokContext>
    {
        public EdificiosRepository(ba4cpg3zvekknrm1lhokContext context) : base(context)
        {

        }



    }
}
