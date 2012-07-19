using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    internal class PasskeyHolder
    {
        [DataMember]
        private string passkey;

        public string Passkey
        {
            get { return passkey; }
        }
    }
}