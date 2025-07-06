using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.List
{
    public class ListInstitutionStatusesRequest :
        IRequest<ListInstitutionStatusesResponse>
    {
    }
}
