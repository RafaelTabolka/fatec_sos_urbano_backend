using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Create
{
    public class CreateInstitutionTypeRequest :
        IRequest<CreateInstitutionTypeResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
