using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Domain.Entities
{
    public class FluxoCaixa
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set;}
        public DateTime Data { get; set; }

    }
}
