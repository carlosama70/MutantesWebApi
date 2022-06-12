using DomainModel.Entities;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Services
{ 
    /// <summary>
    /// funcionalidades comunes a las services de logica de negocio.  
    /// </summary>
    public abstract class ServiceBase
    {
        public readonly IRepository<Adn> _AdnRepository;

        public ServiceBase()
        {               
            var AdnRepository = new Repository<Adn>();
            _AdnRepository = AdnRepository;
        }
    }
}
