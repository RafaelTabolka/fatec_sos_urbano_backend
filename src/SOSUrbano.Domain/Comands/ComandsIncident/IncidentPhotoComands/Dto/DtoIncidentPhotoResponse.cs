namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto
{
    public class DtoIncidentPhotoResponse(string savedPath)
    {
        public string SavedPath { get; } = savedPath;
    }
}
