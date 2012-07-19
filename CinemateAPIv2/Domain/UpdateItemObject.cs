using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class UpdateItemObject
    {
        public UpdateItemObjectMovie Movie
        {
            get { return movie; }
        }

        [DataMember]
        private UpdateItemObjectMovie movie;
    }
}