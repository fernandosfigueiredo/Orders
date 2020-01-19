using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderApp.API.Filters;
using OrderApp.API.Mappers;
using OrderApp.API.Models;
using OrderApp.Application.Services.Abstractions;

namespace OrderApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderService OrderService { get; set; }

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        //TODO criar agendamento de ordens e Stop
        // 1- Agendamento - Criar uma collection com as ordens, o tipo de Trigger (Data ou Preço)
        //   - Uma Function que roda diariamente (ou minuto a minuto), ve tem ordens para o DIA, verifica se o Mercado para o Papel já está aberto e envia a ordem, remover da collection de ordens
        // 2- Stop - Criar collections de ordens stop, assinar o changestream de Cotações, se houver cotação no preço, enviar ordem e remover da collection de ordens

        [HttpPost]
        [ValidateModelStateFilter]
        public IActionResult Post([FromBody] OrderModel order)
        {
            var accountNumber = GetAccountNumberFromHeader();
            var orderDto = order.Map(accountNumber);
            var success = OrderService.PlaceOrder(orderDto);

            if (!success)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            // TODO Implementar CQRS?
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO implementar alteração, validando se o Status da Ordem Permite
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO implementar Deleção, validando se o Status da Ordem Permite
        }

        //// PATCH: api/ApiWithActions/5
        //[HttpPatch("{id}")]
        //public void Patch(int id)
        //{
        //    //TODO implementar Deleção, validando se o Status da Ordem Permite
        //}

        private string GetAccountNumberFromHeader()
        {
            return "550556";
        }
    }
}
