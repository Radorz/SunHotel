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
    public class ReservaRepository : RepositoryBase<Reserva, ba4cpg3zvekknrm1lhokContext>
    {
        private readonly IMapper _mapper;

        public ReservaRepository(ba4cpg3zvekknrm1lhokContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<bool> AddCustom(ResumenVM vm, int idpago)
        {
            var map = _mapper.Map<Reserva>(vm);
            map.IdTipoHabitacion = _context.TipoHabitaciones.FirstOrDefault(a => a.Nombre == vm.TipoHabitacion).IdTipoHabitacion;
            map.FechaPago = DateTime.Now;

            var reservas = await _context.Reserva.Where(a => a.FechaSalida > DateTime.Today && a.FechaSalida >= vm.FechaSalida && a.IdTipoHabitacion == map.IdTipoHabitacion).Select(p => p.IdHabitacion).ToListAsync();
          var idhabitacion= await _context.Habitacion.FirstOrDefaultAsync(a=> !reservas.Contains( a.IdHabitacion) && a.IdTipoHabitacion == map.IdTipoHabitacion);
                map.IdHabitacion = idhabitacion.IdHabitacion;
            map.IdPago = idpago;
            await Add(map);

            return(true);
        }
        public async Task<bool> getresumen(ResumenVM vm)
        {
            var map = _mapper.Map<Reserva>(vm);
            map.IdTipoHabitacion = _context.TipoHabitaciones.FirstOrDefault(a => a.Nombre == vm.TipoHabitacion).IdTipoHabitacion;
            map.FechaPago = DateTime.Now;

            var reservas = await _context.Reserva.Where(a => a.FechaSalida > DateTime.Today && a.FechaSalida <= vm.FechaSalida && a.IdTipoHabitacion == map.IdTipoHabitacion).Select(p => p.IdHabitacion).ToListAsync();
            var idhabitacion = await _context.Habitacion.FirstOrDefaultAsync(a => !reservas.Contains(a.IdHabitacion) && a.IdTipoHabitacion == map.IdTipoHabitacion);
            map.IdHabitacion = idhabitacion.IdHabitacion;

            await Add(map);

            return (true);
        }
        public async Task<TipoHabitaciones> getbyname(string name)
        {
            var tipo = await _context.TipoHabitaciones.FirstOrDefaultAsync(a => a.Nombre == name);
            if (tipo != null)
            {
                return tipo;

            }


            return (null);
        }


    }
}
