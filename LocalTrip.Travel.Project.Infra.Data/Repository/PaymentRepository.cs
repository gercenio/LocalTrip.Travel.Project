using LocalTrip.Travel.Project.Infra.Data.Dtos;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;

namespace LocalTrip.Travel.Project.Infra.Data.Repository
{
    public class PaymentRepository : Repository<PaymentDto> , IPaymentRepository
    {
        
    }
}