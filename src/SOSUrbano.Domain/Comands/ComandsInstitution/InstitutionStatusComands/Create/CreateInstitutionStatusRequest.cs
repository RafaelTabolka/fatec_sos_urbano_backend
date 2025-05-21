using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create
{
    public class CreateInstitutionStatusRequest :
        IRequest<CreateInstitutionStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
