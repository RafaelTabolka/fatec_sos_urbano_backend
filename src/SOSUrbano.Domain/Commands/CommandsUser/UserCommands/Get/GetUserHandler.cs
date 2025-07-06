using MediatR;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Get
{
    internal class GetUserHandler(IRepositoryUser repositoryUser) :
        IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserRequest request, 
            CancellationToken cancellationToken)
        {
            var validator = new GetUserValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await repositoryUser.GetUserByIdAsync(request.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado.");

            var response = new DtoUserResponse(
                user.Id,
                user.Name,
                user.Email,
                user.Cpf,

                new DtoUserTypeResponse(user.UserType.Name),

                new DtoUserStatusResponse(
                    user.UserStatusId, 
                    user.UserStatus.Name),

                user.UserPhones != null ? user.UserPhones.Select(phone =>
                new DtoUserPhoneResponse(
                    phone.Id, 
                    phone.Number)).ToList() :
                new List<DtoUserPhoneResponse>(),

                user.Incidents is not null ?
                user.Incidents.Select(incident => 
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
                    new List<DtoIncidentResponse>());

            return new GetUserResponse(response);
        }
    }
}
