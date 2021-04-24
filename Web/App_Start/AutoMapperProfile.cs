using AutoMapper;
using DataAccess;
using Web.ViewModel;

namespace Web.App_Start
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EstudianteViewModel, Estudiante>();
            CreateMap<Estudiante, EstudianteViewModel>();
            CreateMap<NacionalidadesViewModel, nacionalidad>();
            CreateMap<nacionalidad, NacionalidadesViewModel>();
        }
    }
}