﻿using AutoMapper;
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
    public class PagoRepository : RepositoryBase<Pagos, SunHotelContext>
    {
        private readonly IMapper _mapper;

        public PagoRepository(SunHotelContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<Pagos> AddCustom(PagoVM vm)
        {
            var map = _mapper.Map<Pagos>(vm);
            map.Numero = vm.numeracion;
            var added = await Add(map);
            return (added);
        }




    }
}
