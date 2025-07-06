using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Update
{
    public class UpdateIncidentPhotoResponse(string message)
    {
        public string Message { get; } = message;
    }
}
