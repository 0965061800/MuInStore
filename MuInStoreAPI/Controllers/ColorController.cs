﻿using Microsoft.AspNetCore.Mvc;
using MuInShared.Color;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ColorController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorDto>>> GetAllColors()
        {
            var colors = await _uow.ColorRepository.GetAll();
            if (colors == null)
            {
                return NotFound("No Color in your database");
            }
            var ColorDtos = colors.Select(x => x.ToColorDto());
            return Ok(colors);
        }
    }
}
