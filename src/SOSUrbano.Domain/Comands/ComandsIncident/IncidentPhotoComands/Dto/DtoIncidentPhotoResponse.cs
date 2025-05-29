namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto
{
    public class DtoIncidentPhotoResponse(Guid id, string savedPath)
    {
        public Guid Id { get; } = id;
        public string SavedPath { get; } = savedPath;
    }
}
