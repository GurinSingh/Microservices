﻿using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await this._basketRepository.GetBasket(userName);

            return Ok(basket ?? new(userName));
        }
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody]ShoppingCart basket)
        {
            return Ok(await this._basketRepository.UpdateBasket(basket));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await this._basketRepository.DeleteBasket(userName);

            return Ok();
        }
    }
}
