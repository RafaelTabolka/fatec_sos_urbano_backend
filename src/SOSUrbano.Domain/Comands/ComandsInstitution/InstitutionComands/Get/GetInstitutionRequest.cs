using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Get
{
    public class GetInstitutionRequest(Guid id) :
        IRequest<GetInstitutionResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
