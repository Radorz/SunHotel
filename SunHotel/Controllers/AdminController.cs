using AutoMapper;
using DataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace SunHotel.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {

        private readonly TiposHabitacionRepository _tiposHabitacionRepository;
        private readonly HabitacionRepository _HabitacionRepository;
        private readonly EdificiosRepository _EdificiosRepository;
        private readonly imghabitacionRepository _imghabitacionRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ReservaRepository _reservaRepository;
        private readonly PagoRepository _pagoRepository;


        private readonly IWebHostEnvironment hostEnvironment;

        private readonly IMapper _mapper;

        public AdminController(TiposHabitacionRepository tiposHabitacionRepository, IMapper mapper, HabitacionRepository HabitacionRepository,
         EdificiosRepository EdificiosRepository, IWebHostEnvironment hostEnvironment, imghabitacionRepository imghabitacionRepository,
         SignInManager<IdentityUser> signInManager, ReservaRepository reservaRepository, PagoRepository pagoRepository)
        {
            this.hostEnvironment = hostEnvironment;
            _tiposHabitacionRepository = tiposHabitacionRepository;
            _HabitacionRepository = HabitacionRepository;
            _EdificiosRepository = EdificiosRepository;
            _mapper = mapper;
            _imghabitacionRepository = imghabitacionRepository;
            _signInManager = signInManager;
            _reservaRepository = reservaRepository;
            _pagoRepository = pagoRepository;
        }


        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var vm = new DashboardVM();
            var tipoHabitaciones = await _tiposHabitacionRepository.GetAll();
            var Habitaciones = await _HabitacionRepository.GetAll();
            var Edificios = await _EdificiosRepository.GetAll();
            var reservas = await _reservaRepository.GetAll();
           var counres= reservas.Where(a => a.FechaPago == DateTime.Today).ToList().Count;
            vm.CantTipohabitaciones = tipoHabitaciones.Count;
            vm.Canthabitaciones = Habitaciones.Count;
            vm.Cantedificios = Edificios.Count;
            vm.reservas = counres;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Habitaciones()
        {
            var selectipos = await _tiposHabitacionRepository.Listselectipos();
            var selectedificios = await _EdificiosRepository.GetAll();
            if(selectipos != null)
            {
                ViewBag.tipos = selectipos;

            }
            if (selectedificios != null)
            {
                ViewBag.edificios = selectedificios;

            }
            var vm = await _HabitacionRepository.listahabtiacionesAdmin();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AñadirHabitaciones(HabitacionVM vm)
        {
           await _HabitacionRepository.addcustom(vm);
            return RedirectToAction("Habitaciones");
        }
      

        [HttpGet]
        public async Task<IActionResult> TiposHabitaciones()
        {
            var vm = await _tiposHabitacionRepository.GetAll();
            var vms = new TipoHabitacioneVM();
            vms.List = vm;
            return View(vms);
        }
        [HttpPost]
        public async Task<IActionResult> TiposHabitaciones(TipoHabitacioneVM vm)
        {

            if (ModelState.IsValid)
            {
                string uniqueName = null;
                var add = _mapper.Map<TipoHabitaciones>(vm);
                var save = await _tiposHabitacionRepository.Add(add);

                if (vm.photo != null)
                {
                    foreach (var pic in vm.photo)
                    {

                        uniqueName = Guid.NewGuid().ToString() + "_" + pic.FileName;
                        var folderPath = Path.Combine(hostEnvironment.WebRootPath, "img/habitacion");
                        var filepath = Path.Combine(folderPath, uniqueName);

                        if (filepath != null)
                        {

                            pic.CopyTo(new FileStream(filepath, mode: FileMode.Create));
                        }

                        var img = new ImgHabitaciones();

                        img.IdTipoHabitacion = save.IdTipoHabitacion;
                        img.Path = uniqueName;

                        await _imghabitacionRepository.Add(img);


                    }
                }
            }
            return RedirectToAction("TiposHabitaciones");


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AñadirTipo(TipoHabitacioneVM vm)
        {

            if (ModelState.IsValid)
            {
                string uniqueName = null;
                var add = _mapper.Map<TipoHabitaciones>(vm);
                var save = await _tiposHabitacionRepository.Add(add);

                if (vm.photo != null)
                {
                    foreach (var pic in vm.photo)
                    {

                        uniqueName = Guid.NewGuid().ToString() + "_" + pic.FileName;
                        var folderPath = Path.Combine(hostEnvironment.WebRootPath, "img/habitacion");
                        var filepath = Path.Combine(folderPath, uniqueName);

                        if (filepath != null)
                        {

                            pic.CopyTo(new FileStream(filepath, mode: FileMode.Create));
                        }

                        var img = new ImgHabitaciones();

                        img.IdTipoHabitacion = save.IdTipoHabitacion;
                        img.Path = uniqueName;

                        await _imghabitacionRepository.Add(img);


                    }
                }
            }
            return RedirectToAction("TiposHabitaciones");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrartipo(TipoHabitacioneVM vm)
        {
            if (vm.eliminar.Value != 0)
            {

                var imgs = await _imghabitacionRepository.GetAll();

                var imgtipo = imgs.Where(a => a.IdTipoHabitacion == vm.eliminar.Value).ToList();

                foreach (var i in imgtipo)
                {
                    await _imghabitacionRepository.Delete(i.IdImgHabitaciones);
                }
                await _tiposHabitacionRepository.Delete(vm.eliminar.Value);
            }
            return RedirectToAction("TiposHabitaciones");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editartipo(TipoHabitacioneVM vm)
        {
            if (vm.editar.Value != 0)
            {

              var tipo=  await _tiposHabitacionRepository.GetbyId(vm.editar.Value);

                tipo.Nombre = vm.Nombre;
                tipo.Descripcion = vm.Descripcion;
                tipo.CantCamas = vm.CantCamas;
                tipo.MaxHuespedes = vm.MaxHuespedes;
                tipo.PrecioNoche = vm.PrecioNoche;
                await _tiposHabitacionRepository.Update(tipo);

            }
            return RedirectToAction("TiposHabitaciones");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editarhab(HabitacionVM vm)
        {
            if (vm.editar.Value != 0)
            {

                var tipo = await _HabitacionRepository.GetbyId(vm.editar.Value);

                tipo.IdEdificio = vm.IdEdificio;
                tipo.IdTipoHabitacion = vm.IdTipoHabitacion;
                tipo.NoHabitacion = vm.NoHabitacion.Value;
              
                await _HabitacionRepository.Update(tipo);

            }
            return RedirectToAction("Habitaciones");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarHab(HabitacionVM vm)
        {
            if (vm.eliminar.Value != 0)
            {
                

                var imgs = await _HabitacionRepository.Delete(vm.eliminar.Value);

               
            }
            return RedirectToAction("Habitaciones");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarEdi(EdificioVM vm)
        {
            if (vm.eliminar.Value != 0)
            {
                var list = await _HabitacionRepository.GetAll();
                var hab = list.Where(a => a.IdEdificio == vm.eliminar).ToList();
                if (hab.Count !=0)
                {
                    foreach (var item in hab)
                    {
                        var reservas = await _reservaRepository.GetAll();
                        var res = reservas.Where(a => a.IdHabitacion == item.IdHabitacion).ToList();

                     

                        await _HabitacionRepository.Delete(item.IdHabitacion);
                    }
                }
            }
                var imgs = await _EdificiosRepository.Delete(vm.eliminar.Value);


            
            return RedirectToAction("Edificios");


        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edificios()
        {
          var li=  await _EdificiosRepository.GetAll();
            var vm = new List<EdificioVM>();
            foreach(var item in li)
            {
                var it = _mapper.Map<EdificioVM>(item);

                vm.Add(it);




            }
            var vms = new EdificioVM();
            vms.list = vm;

            return View(vms);



        }

        public async Task<IActionResult> Reserva()
        {
            var list = await _reservaRepository.GetAll();

            var newis = list.Where(a => a.IdPago != null).ToList();
            var vms = new List<ReservaAdminVM>();

            foreach (var item in newis) {
                var vm = new ReservaAdminVM();
                vm.Nombre = item.Nombre;
                vm.Apellido = item.Apellido;
                vm.Email = item.Email;
                vm.Fechaereserva = string.Concat(item.FechaLlegada.Value.ToString("dd MMMM yyyy"), " - ", item.FechaSalida.Value.ToString("dd MMMM yyyy"));
                vm.Huespedes = item.Adultos + item.Niños;
                var hab = await _tiposHabitacionRepository.GetbyId(item.IdTipoHabitacion.Value);
                vm.TipoHabitacion = hab.Nombre;
                var pago = await _pagoRepository.GetbyId(item.IdPago.Value);
                vm.pagototal = pago.Cantidadpagar.ToString();
                vm.Fechaepago = item.FechaPago.Value;

                vms.Add(vm);
    }
            vms.OrderByDescending(a => a.Fechaepago);
            return View(vms);

        }
    }
}