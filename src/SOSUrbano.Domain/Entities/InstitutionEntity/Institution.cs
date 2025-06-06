﻿using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Entities.InstitutionEntity
{
    public class Institution : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string? UrlSite { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid InstitutionStatusId { get; set; }
        public InstitutionStatus InstitutionStatus { get; set; } = null!;
        public Guid InstitutionTypeId { get; set; }
        public InstitutionType InstitutionType { get; set; } = null!;
        public List<InstitutionEmail> InstitutionEmails { get; set; } = [];
        public List<InstitutionPhone> InstitutionPhones { get; set; } = [];
        public List<Incident>? Incidents { get; set; }

        public Institution
            (string name, 
            string cnpj, 
            string? urlSite, 
            string description,
            string address,
            Guid institutionStatusId,
            Guid institutionTypeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cnpj = cnpj;
            UrlSite = urlSite;
            Description = description;
            Address = address;
            InstitutionStatusId = institutionStatusId;
            InstitutionTypeId = institutionTypeId;
        }

    }
}
