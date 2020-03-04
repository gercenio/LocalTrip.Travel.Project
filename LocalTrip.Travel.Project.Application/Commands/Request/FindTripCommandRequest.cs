using System;
using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class FindTripCommandRequest :IRequest<FindTripCommandResponse>
    {
        public string CityOrigem { get; set; }
        public string CountryOrigem { get; set; }
        public DateTime DateTrip { get; set; }
        public string CityDestination { get; set; }
        public string CountryDestination { get; set; }
    }
}