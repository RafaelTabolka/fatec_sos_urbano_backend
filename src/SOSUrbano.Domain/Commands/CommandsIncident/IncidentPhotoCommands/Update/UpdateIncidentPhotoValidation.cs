using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Update
{
    public class UpdateIncidentPhotoValidation : 
        AbstractValidator<UpdateIncidentPhotoRequest>
    {
        public UpdateIncidentPhotoValidation()
        {
            RuleFor(photo => photo.Id)
                .NotEmpty().WithMessage("Campo Id é obrigatório.");

            RuleFor(photo => photo.File)
                .NotEmpty().WithMessage("Caminho da foto é obrigatório");
        }
    }
}
