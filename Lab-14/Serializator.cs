using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Lab_14
{
    public class Serializator
    {
        public void SerializeToBinary(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".bin", FileMode.Create))
            {
                BinaryFormatter binary = new BinaryFormatter();
            }
        }

        public void SerializeToSOAP(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".", FileMode.Create))
            {
                SoapFormatter soap = new SoapFormatter();
            }
        }

        public void SerializeToJSON(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".", FileMode.Create))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer();
            }
        }

        public void SerializeToXML(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer();
            }
    }
}
