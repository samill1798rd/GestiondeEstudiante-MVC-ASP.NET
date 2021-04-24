using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Services.NacionalidadServices
{
    public class NacionalidadAService : INacionaliadadService
    {
        private readonly GestionDB _GestionDB;
        public NacionalidadAService()
        {
            _GestionDB = new GestionDB();
        }
        public IEnumerable<nacionalidad> GetAllNacionalidades()
        {
            return _GestionDB.nacionalidads;
        }
    }
}
