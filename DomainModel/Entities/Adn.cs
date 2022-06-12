using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public partial class Adn
    {
        public int Id { get; set; }
        public string? CodigoAdn { get; set; }
        public bool? EsMutante { get; set; }
    }
}
