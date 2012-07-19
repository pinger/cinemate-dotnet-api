using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class Update
    {
        public int Count
        {
            get { return count; }
        }

        public UpdateItem[] Items
        {
            get { return items; }
        }

        [DataMember]
        private int count;

        [DataMember(Name = "item")]
        private UpdateItem[] items;
    }
}