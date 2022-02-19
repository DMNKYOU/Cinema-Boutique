using AutoMapper;
using System;
using Cinema_Boutique.Models;
using CinemaBoutique.Core.Models;

namespace Cinema_Boutique.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketModel>()
                .ForMember(sr => sr.FilmSession,
                    map =>
                        map.MapFrom(sr => sr.FilmSession))
                .ReverseMap();
            
            CreateMap<Cinema, CinemaModel>()
                .ForMember(sr => sr.FilmSessions,
                    map =>
                        map.MapFrom(sr => sr.FilmSessions))
                .ForMember(sr => sr.FilmStrips,
                    map =>
                        map.MapFrom(sr => sr.FilmStrips))
                .ReverseMap();

            CreateMap<Actor, ActorModel>()
                .ForMember(sr => sr.FilmStrips,
                    map =>
                        map.MapFrom(sr => sr.FilmStrips))
                .ReverseMap();

            CreateMap<FilmStrip, FilmStripModel>()
                .ForMember(sr => sr.Actors,
                    map =>
                        map.MapFrom(sr => sr.Actors))
                .ForMember(sr => sr.Cinemas,
                    map =>
                        map.MapFrom(sr => sr.Cinemas))
                .ReverseMap();
            
            CreateMap<FilmSession, FilmSessionModel>()
                .ForMember(sr => sr.FilmName,
                    map => 
                        map.MapFrom(sr => sr.FilmStrip.Title))
                .ForMember(sr => sr.Cinema,
                    map =>
                        map.MapFrom(sr => sr.Cinema))
                .ForMember(sr => sr.FilmStrip,
                    map =>
                        map.MapFrom(sr => sr.FilmStrip))
                .ForMember(sr => sr.Tickets,
                    map =>
                        map.MapFrom(sr => sr.Tickets))
                .ReverseMap();
            
        }
    }
}
