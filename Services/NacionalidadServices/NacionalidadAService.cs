using DataAccess;
using System.Collections.Generic;

namespace Services.NacionalidadServices
{
    public class NacionalidadAService : INacionaliadadService
    {
        private readonly GestionDB _GestionDB;
        public NacionalidadAService()
        {
            _GestionDB = new GestionDB();
        }
        public IEnumerable<nacionalidad> GetallEstudiantes()
        {
              return _GestionDB.nacionalidads;
        }
    }
}
