using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Delete
{
    public class DeleteInstitutionRequest (Guid id) :
        IRequest<DeleteInstitutionResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
