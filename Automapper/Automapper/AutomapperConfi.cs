using AutoMapper;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Automap.Automapper
{
    public class AutomapperConfinew : Profile
    {

        public AutomapperConfinew()
        {
            Addtipo();
            Habitacion();
            selectipos();
            AddHabitacion();
            addreserva();
            mapresumen();
            addreservabyresumen();
            Pagos();
            listedificios();
        }

            private void Addtipo()
            {
                CreateMap<TipoHabitacioneVM, TipoHabitaciones>().ReverseMap().ForMember
                (dest => dest.List, opt => opt.Ignore()); 

            }

        private void selectipos()
        {
            CreateMap<TipoHabitaciones, selectipo>().ReverseMap().ForMember
            (dest => dest.CantCamas, opt => opt.Ignore()).ForMember
            (dest => dest.Descripcion, opt => opt.Ignore()).ForMember
            (dest => dest.PrecioNoche, opt => opt.Ignore()).ForMember
            (dest => dest.MaxHuespedes, opt => opt.Ignore());

        }

        private void addreserva()
        {
            CreateMap<ReservaVM, Reserva>().ReverseMap().ForMember
            (dest => dest.RepeatEmail, opt => opt.Ignore()).ForMember
            (dest => dest.TipoHabitacion, opt => opt.Ignore());

        }
        private void listedificios()
        {
            CreateMap<EdificioVM, Edificio>().ReverseMap().ForMember
            (dest => dest.list, opt => opt.Ignore()).ForMember
            (dest => dest.eliminar, opt => opt.Ignore()).ForMember
            (dest => dest.editar, opt => opt.Ignore());

        }
        private void addreservabyresumen()
        {
            CreateMap<ResumenVM, Reserva>().ReverseMap().ForMember
            (dest => dest.RepeatEmail, opt => opt.Ignore()).ForMember
            (dest => dest.TipoHabitacion, opt => opt.Ignore()).ForMember
            (dest => dest.cantidadnoches, opt => opt.Ignore()).ForMember
            (dest => dest.preciototal, opt => opt.Ignore()).ForMember
            (dest => dest.precionoche, opt => opt.Ignore()).ForMember
            (dest => dest.TipoHabitacion, opt => opt.Ignore());

        }
        private void Habitacion()
        {
            CreateMap<ListHabitacionVM, Habitacion>().ReverseMap().ForMember
            (dest => dest.TipoHabitacion, opt => opt.Ignore()); 

        }
        private void Pagos()
        {
            CreateMap<PagoVM, Pagos>().ReverseMap().ForMember
            (dest => dest.CVV, opt => opt.Ignore()).ForMember
            (dest => dest.fechavencimientoAño, opt => opt.Ignore()).ForMember
            (dest => dest.fechavencimientoMes, opt => opt.Ignore());


        }
        private void AddHabitacion()
        {
            CreateMap<HabitacionVM, Habitacion>().ReverseMap().ForMember
            (dest => dest.list, opt => opt.Ignore());

        }

        private void mapresumen()
        {
            CreateMap<ReservaVM, ResumenVM>().ReverseMap();

        }
    }
}
