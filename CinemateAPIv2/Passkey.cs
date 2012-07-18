using System;
using System.Xml.Serialization;

namespace CinemateAPI
{
    [Serializable]
    public class PasskeyHolder
    {
        [XmlElement("passkey")]
        public string Passkey;
    }
}