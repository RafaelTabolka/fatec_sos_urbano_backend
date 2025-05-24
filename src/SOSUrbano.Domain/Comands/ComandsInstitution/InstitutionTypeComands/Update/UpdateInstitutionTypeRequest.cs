using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Update
{
    public class UpdateInstitutionTypeRequest :
        IRequest<UpdateInstitutionTypeResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
