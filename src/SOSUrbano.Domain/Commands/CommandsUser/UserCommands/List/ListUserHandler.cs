using MediatR;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.List
{
    internal class ListUserHandler(IRepositoryUser repositoryUser) :
        IRequestHandler<ListUserRequest, ListUserResponse>
    {
        public async Task<ListUserResponse> Handle(ListUserRequest request, 
            CancellationToken cancellationToken)
        {
            var users = await repositoryUser.GetAllUsersAsync();

            var response = users.Select(user =>
            new DtoUserResponse(
                user.Id,
                user.Name,
                user.Email,
                user.Cpf,
                new DtoUserTypeResponse(user.UserType.Name),
                new DtoUserStatusResponse(user.UserStatusId, user.UserStatus.Name),
                user.UserPhones != null ? user.UserPhones.Select(phone =>
                new DtoUserPhoneResponse(phone.Id, phone.Number)).ToList() :
                new List<DtoUserPhoneResponse>(),
                user.Incidents is not null ? user.Incidents.Select(incident => 
                new DtoIncidentResponse(
                    incident.Id,
                    incident.Description,
                    incident.LatLocalization,
                    incident.LongLocalization,
                    incident.Address,
                    new DtoIncidentStatusResponse(incident.Id, incident.IncidentStatus.Name),
                    incident.IncidentPhotos.Select(photo => 
                    new DtoIncidentPhotoResponse(photo.Id, photo.SavedPath)).ToList(),
                    incident.UserId,
                    incident.InstitutionId)).ToList() : 
                    new List<DtoIncidentResponse>())).ToList();

            return new ListUserResponse(response);
        }
    }
}
