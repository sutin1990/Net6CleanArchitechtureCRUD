using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.DBModels.MappingProfile
{
    public static class MoviesRentalTransactionProfile
    {
        public static IMapper Mapper;
        //public MoviesRentalTransactionProfile()
        //{
        //    CreateMap<MoviesRentalTransaction, MoviesRentalTransaction>();          
        //}

        static MoviesRentalTransactionProfile()
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<MoviesRentalTransaction, MoviesRentalTransaction>().ForMember(dest => dest.Id,opt => opt.MapFrom(src => $"{src.Id}"));
            });

            Mapper = config.CreateMapper();
        }
    }

    
}
