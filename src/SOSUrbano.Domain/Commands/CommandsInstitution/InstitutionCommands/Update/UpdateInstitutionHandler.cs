using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Update
{
    internal class UpdateInstitutionHandler
        (IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<UpdateInstitutionRequest, UpdateInstitutionResponse>
    {
        public async Task<UpdateInstitutionResponse> Handle
            (UpdateInstitutionRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstitutionValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institution = await repositoryInstitution.GetByIdAsync(request.Id);

            if (institution is null)
                throw new Exception("Instituição não encontrada.");

            institution.Name = request.Name;
            institution.UrlSite = request.UrlSite;
            institution.Description = request.Description;
            institution.Address = request.Address;

            repositoryInstitution.Update(institution);
            await repositoryInstitution.CommitAsync();

            return new UpdateInstitutionResponse("Atualizado com sucesso");
    }
    }
}
