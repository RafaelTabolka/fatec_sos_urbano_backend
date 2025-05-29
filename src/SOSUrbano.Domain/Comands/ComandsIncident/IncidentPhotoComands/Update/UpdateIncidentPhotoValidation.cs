using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    public class UpdateIncidentPhotoValidation : 
        AbstractValidator<UpdateIncidentPhotoRequest>
    {
        public UpdateIncidentPhotoValidation()
        {
            RuleFor(photo => photo.Id)
                .NotEmpty().WithMessage("Campo Id é obrigatório.");

            RuleFor(photo => photo.SavedPath)
                .NotEmpty().WithMessage("Caminho da foto é obrigatório");
        }
    }
}
