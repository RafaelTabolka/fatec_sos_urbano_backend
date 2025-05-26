using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool TermsOfUse { get; set; }

        public Guid UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; } = null!;

        public Guid UserTypeId { get; set; }
 
        public UserType UserType { get; set; } = null!;

        public List<UserPhone>? UserPhones { get; set; }

        public List<Incident>? Incidents { get; set; }

        protected User() { }

        public User(string name, string email, string cpf, string password,
            bool termsOfUse, Guid userStatusId, Guid userTypeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Cpf = cpf;
            Password = password;
            TermsOfUse = termsOfUse;
            UserStatusId = userStatusId;
            UserTypeId = userTypeId;
        }

        public void AlterName(string newName)
        {
            Name = newName;
        }

        public void AlterEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void AlterPassword(string newPassword)
        {
            Password = newPassword;
        }

        public void AlterUserStatus(UserStatus newUserStatus)
        {
            UserStatus = newUserStatus;
        }

        public void AlterPhone(Guid id,
                                string newPhone)
        {
            if(UserPhones != null)
                foreach (UserPhone userPhone in UserPhones)
                {
                    if (userPhone.Id == id)
                    {
                        userPhone.Number = newPhone;
                    }
                }
        }
    }
}
