using AutoMapper;
using DataBase.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repository.Repository
{
    public class TiposHabitacionRepository : RepositoryBase<TipoHabitaciones, ba4cpg3zvekknrm1lhokContext>
    {
        private readonly IMapper _mapper;

        public TiposHabitacionRepository(ba4cpg3zvekknrm1lhokContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<List<selectipo>> Listselectipos()
        {
            var list = await GetAll();
            var vm = new List<selectipo>();
            foreach(var li in list)
            {
                var map = _mapper.Map<selectipo>(li);
                map.Idtipo = li.IdTipoHabitacion;
                vm.Add(map);
            }

            return(vm);
        }


    }
}
