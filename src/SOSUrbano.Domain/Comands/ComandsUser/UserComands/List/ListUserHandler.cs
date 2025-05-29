using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.List
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
