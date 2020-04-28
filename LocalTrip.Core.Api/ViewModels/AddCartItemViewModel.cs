namespace LocalTrip.Core.Api.ViewModels
{
    public class AddCartItemViewModel
    {
        public int CartId { get; set; }
        public int DestinationId { get; set; }
        public int PeopleId { get; set; }
        public int Count { get; set; }
    }
}