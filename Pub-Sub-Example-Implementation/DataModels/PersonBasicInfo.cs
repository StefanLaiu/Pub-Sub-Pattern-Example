using System.ComponentModel.DataAnnotations;

namespace Pub_Sub_Example_Implementation.DataModels
{
    public class PersonBasicInfo
    {
        public string FullName { get; private set; }
        public string Linkedin { get; set; }
        /// <summary>
        /// Basic Information neede for any interested party.
        /// </summary>
        /// <param name="fullName">Name of applicant</param>
        /// <param name="linkedin">Linkedin profile of applicant (optional)</param>
        public PersonBasicInfo(string fullName, string linkedin)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException();
            FullName = fullName;
            Linkedin = linkedin;
        }
      
        public DateTime TimeAndDateOfApply { get; protected set; } = DateTime.UtcNow;
    }
}
