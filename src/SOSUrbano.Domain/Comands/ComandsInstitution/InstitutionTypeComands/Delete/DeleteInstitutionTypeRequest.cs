using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Delete
{
    public class DeleteInstitutionTypeRequest(Guid id) :
        IRequest<DeleteInstitutionTypeResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
