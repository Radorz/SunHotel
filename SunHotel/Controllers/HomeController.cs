using AutoMapper;
using EmailHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository.Repository;
using SunHotel.Models;
using SunHotel.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;

namespace SunHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TiposHabitacionRepository _tiposHabitacionRepository;
        private readonly HabitacionRepository _HabitacionRepository;
        private readonly EdificiosRepository _EdificiosRepository;
        private readonly imghabitacionRepository _imghabitacionRepository;
        private readonly ReservaRepository _reservaRepository;
        private readonly PagoRepository _pagoRepository;
        private readonly Iemailsender _iemailsender;
        private  ITemplateHelper _templateHelper;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HomeController(TiposHabitacionRepository tiposHabitacionRepository, HabitacionRepository HabitacionRepository,
         EdificiosRepository EdificiosRepository, imghabitacionRepository imghabitacionRepository, ReservaRepository reservaRepository,
          IMapper mapper, PagoRepository pagoRepository, Iemailsender iemailsender, ITemplateHelper templateHelper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
          RoleManager<IdentityRole> roleManager, HttpClient httpClient, IConfiguration configuration)
        {
            _tiposHabitacionRepository = tiposHabitacionRepository;
            _HabitacionRepository = HabitacionRepository;
            _EdificiosRepository = EdificiosRepository;
            _imghabitacionRepository = imghabitacionRepository;
            _reservaRepository = reservaRepository;
            _mapper = mapper;
            _pagoRepository = pagoRepository;
            _iemailsender = iemailsender;
            _templateHelper = templateHelper;
            _userManager = userManager;
            _signInManager = signInManager;
            this._roleManager = roleManager;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = _configuration["GoogleMaps:ApiKey"]; 
            string latitud = "18.651889138844684";  
            string longitud = "-68.36758749680183";
            int radio = 1500; 

            string apiUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={latitud},{longitud}&radius={radio}&type=restaurant&key={apiKey}";

            try
            {
                var response = await _httpClient.GetStringAsync(apiUrl);
                ViewBag.PlacesData = response; 
            }
            catch (Exception ex)
            {
                ViewBag.PlacesData = $"Error: {ex.Message}";
            }

            var cvm = await _tiposHabitacionRepository.GetAll();
            var imgs = await _imghabitacionRepository.GetAll();
            var vm = new List<HomeVM>();
            var i = 0;
            foreach(var R in cvm)
            {
                i++;
                var add = new HomeVM();
                add.id = R.Id;
                if ((imgs.FirstOrDefault(a => a.IdTipoHabitacion == add.id)) !=null) {
                    add.Img = imgs.FirstOrDefault(a => a.IdTipoHabitacion == add.id).Path;
                }
                add.Nombre = R.Nombre;

                vm.Add(add);

                if (i == 6)
                {
                    break;
                }
            }
            return View(vm);
        }

        [HttpGet]
       
        public IActionResult Resumen()
        {
            ReservaVM vm;
            if (TempData["VM"] is string s)
            {
                 vm = JsonConvert.DeserializeObject<ReservaVM>(s);
                // use newUser object now as needed

                var vms = _mapper.Map<ResumenVM>(vm);
                vms.cantidadnoches = ((vm.FechaSalida - vm.FechaLlegada).Value.Days);
                var precio = _HabitacionRepository.findbyname(vm.TipoHabitacion).Result.PrecioNoche;
                vms.precionoche = Convert.ToDouble(precio);
                vms.preciototal = vms.precionoche * vms.cantidadnoches;
                var z = JsonConvert.SerializeObject(vms);

                TempData["VMX"] = z;
                return View(vms);
            }

            return RedirectToAction("Index");

        }
       


        [HttpGet]
        public async  Task<IActionResult> Habitacion( int? id)
        {
             if (id == null)
                {
                    return RedirectToAction("Index", "Home");

                }
                var cvm = await _tiposHabitacionRepository.GetbyId(id.Value);
                var imgs = await _imghabitacionRepository.GetAll();
                var imgss = imgs.Where(a => a.IdTipoHabitacion == id.Value);
                var fechasocupadas = await _HabitacionRepository.FechasOcupadas(cvm.Id);
                var prueba = new List<string>();
                foreach (var a in fechasocupadas)
                {
                    prueba.Add(a.ToString("yyyy-MM-dd"));

                }
                var listims = new List<string>();
                if (imgs != null)
                {
                    foreach (var i in imgss)
                    {
                        var st = i.Path;
                        listims.Add(st);
                    }

                }
                var vm = new HabitacioneVM();

                vm.Nombre = cvm.Nombre;
                vm.Descripcion = cvm.Descripcion;
                vm.CantCamas = cvm.CantCamas;
                vm.PrecioNoche = cvm.PrecioNoche;
                vm.MaxHuespedes = cvm.MaxHuespedes;
                vm.photo = listims;
                vm.fechasocupadas = prueba;
                vm.idtipo = id.Value;
                return View(vm);
         
        }
        [HttpGet]
        public  IActionResult Reserva(string fecha, int? idtipo)
        {
            if (idtipo == null || fecha==null)
            {
                return RedirectToAction("Index", "Home");

            }
            var vm = new ReservaVM();
            var fechas = fecha.Split(" - ");
            vm.FechaLlegada = DateTime.Parse(fechas[0]);
            vm.FechaSalida = DateTime.Parse(fechas[1]);
            vm.TipoHabitacion =  _tiposHabitacionRepository.GetbyId(idtipo.Value).Result.Nombre;

            return View(vm);
        }
        [HttpPost]

        public IActionResult Reserva( ReservaVM vm)
        {
            var s = JsonConvert.SerializeObject(vm);

            TempData["VM"] = s;

            return RedirectToAction("Resumen");

        }

        [HttpPost]
        public IActionResult redirectreserva(string datepicker, int idtipo)
        {

            return RedirectToAction("Reserva", new { fecha = datepicker, idtipo= idtipo });
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel vm)
        {

            ViewBag.mostrar = "none";
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(vm.usuario, vm.Contraseña, false, false);

                if (resultado.IsLockedOut)
                {

                    ModelState.AddModelError("Error", "Esta cuenta ha sido Inactivada");
                    return View(vm);
                }
                if (resultado.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(vm.usuario);
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");

                    }


                }
                ModelState.AddModelError("UserOrPasswordInvalid", "El usuario o contraseña es invalido");
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Pago()
        {
            ViewBag.mostrar = "none";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pago(PagoVM vms)
        {
            ViewBag.mostrar = "none";

            if (ModelState.IsValid)
            {
                if (TempData["VMX"] is string z)
                {

                    ResumenVM vm = JsonConvert.DeserializeObject<ResumenVM>(z);
                    vms.cantidadpagar = Convert.ToDecimal( vm.preciototal);
                     var adeddpago=   await _pagoRepository.AddCustom(vms);
                    await _reservaRepository.AddCustom(vm, adeddpago.Id);

                    var response = await _templateHelper.GetTemplateHtmlAsStringAsync<ResumenVM>($"/Views/Shared/Email.cshtml", vm);
                    var message = new Message(new string[] { vm.Email }, "Rerservacion SunHotel", response);
                    await _iemailsender.SendMailAsync(message);

                }
                ViewBag.mostrar = "block";

                return View();
            }
            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }
        public IActionResult Mapa()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ListHabitacion()
        {

            var cvm = await _tiposHabitacionRepository.GetAll();
            var imgs = await _imghabitacionRepository.GetAll();
            var vm = new List<ListHomeVM>();
            var i = 0;
            foreach (var R in cvm)
            {
                i++;
                var add = new ListHomeVM();
                add.id = R.Id;
                if ((imgs.FirstOrDefault(a => a.IdTipoHabitacion == add.id)) != null)
                {
                    add.Img = imgs.FirstOrDefault(a => a.IdTipoHabitacion == add.id).Path;
                }
                add.Nombre = R.Nombre;
                add.Descripcion = R.Descripcion;
                vm.Add(add);

                if (i == 6)
                {
                    break;
                }
            }
            return View(vm);
        }
        [AllowAnonymous]
        public async Task<IActionResult> validatehuespedes(int? Adultos, int? Niños, string TipoHabitacion)
        {
            if (!Niños.HasValue)
            {
                Niños = 0;
            }
            var tipo = await _reservaRepository.getbyname(TipoHabitacion);
            if (tipo != null)
            {
                if ( (Adultos.Value + Niños.GetValueOrDefault())> tipo.MaxHuespedes)
                {
                    return Json(data: "La cantidad maxima de huespedes para: " + TipoHabitacion +" es: " +  tipo.MaxHuespedes.ToString());
                }
                return Json(data: true);

            }
            return Json(data: false);

        }
    }
}
