using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Delete
{
    public class DeleteInstitutionStatusRequest(Guid id) :
        IRequest<DeleteInstitutionStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
