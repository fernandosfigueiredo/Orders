using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OrderApp.Domain.AggregateModels;

namespace OrderApp.API.Models
{
    public class OrderModel
    {
        [Required]
        public string Symbol { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Preço deve ser um valor maior que 0 e expresso em centavos")]
        public int Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Quantidade deve ser um valor maior que 0")]
        public int Quantity { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType? Operation { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType? Type { get; set; }
    }
}
