
using Pub_Sub_Example_Implementation.DataModels;

namespace Pub_Sub_Example_Implementation.Arguments
{
    public class HRData : PersonBasicInfo
    {
        public HRData(string fullName, string linkedin) : base(fullName, linkedin)
        {
        }

        public string Email { get; set; }
        public decimal FrontEndScore { get; set; } = 0M;
        public decimal BacEndEndScore { get; set; } = 0M;

    }
}
