using AutoMapper;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repository.Repository
{
    public class HabitacionRepository : RepositoryBase<Habitacion, ba4cpg3zvekknrm1lhokContext>
    {
        private readonly IMapper _mapper;

        public HabitacionRepository(ba4cpg3zvekknrm1lhokContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<List<DateTime>> FechasOcupadas(int tipohabitacion)
        {

            var count = await _context.Habitacion.CountAsync(a => a.IdTipoHabitacion == tipohabitacion);
            var reservas = await _context.Reserva.Where(a => a.FechaLlegada > DateTime.Today && a.IdTipoHabitacion == tipohabitacion).ToListAsync();
            var listdates = new List<DateTime>();
            var fechasocupadas = new List<DateTime>();

            foreach (var res in reservas)
            {
                TimeSpan diff = (res.FechaSalida - res.FechaLlegada).Value;

                var fechainit = res.FechaLlegada.Value;
                var days = diff.Days;
                listdates.Add(fechainit);
                for (var i = days; i > 0; i--)
                {
                    listdates.Add(fechainit.AddDays(i));
                }

            }
            foreach (var fecha in listdates.Distinct())
            {
                var repettidas = listdates.Where(a => a == fecha).Count();
                if (repettidas == count)
                {
                    fechasocupadas.Add(fecha);
                }
            }

            return (fechasocupadas);

        }


        public async Task<HabitacionVM> listahabtiacionesAdmin(){


            var list = await GetAll();
            var listvm = new List<ListHabitacionVM>();
            foreach(var li in list)
            {
                var vm =  _mapper.Map<ListHabitacionVM>(li);
                var tipo = await _context.TipoHabitaciones.FindAsync(li.IdTipoHabitacion);
                var edificio = await _context.Edificio.FirstOrDefaultAsync(a => a.IdEdificio == vm.IdEdificio);
                if (edificio != null)
                {
                    vm.IdEdificio = Convert.ToInt32(edificio.NumeroEdificio);


                }
                vm.IdEdificio = 118;
                vm.TipoHabitacion = tipo.Nombre;
                listvm.Add(vm);
            }
            var vms = new HabitacionVM();
            vms.list =listvm;
            return (vms);
            }

        public async Task<bool> addcustom(HabitacionVM vm)
        {
            var add = _mapper.Map<Habitacion>(vm);

            await Add(add);

            return true;

        }

        public async Task<TipoHabitaciones> findbyname(string vm)
        {
            var hab = await _context.TipoHabitaciones.FirstOrDefaultAsync(a=>a.Nombre == vm.Trim());

            return hab;

        }


    }
}
