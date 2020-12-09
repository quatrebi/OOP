using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Lab_14
{
    public static class Serializator
    {
        public static void SerializeToBinary(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".bin", FileMode.Create))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fout, obj);
                fout.Close();
            }
        }

        public static object DeserializeFromBinary(string filename)
        {
            using (FileStream fin = new FileStream(filename, FileMode.Open))
            {
                BinaryFormatter binary = new BinaryFormatter();
                return binary.Deserialize(fin);
            }
        }

        public static void SerializeToSOAP(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".soap", FileMode.Create))
            {
                SoapFormatter soap = new SoapFormatter();
                soap.Serialize(fout, obj);
            }
        }

        public static object DeserializeFromSOAP(string filename)
        {
            using (FileStream fin = new FileStream(filename, FileMode.Open))
            {
                SoapFormatter soap = new SoapFormatter();
                return soap.Deserialize(fin);
            }
        }

        public static void SerializeToJSON(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".json", FileMode.Create))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
                json.WriteObject(fout, obj);
            }
        }

        public static object DeserializeFromJSON(string filename)
        {
            using (FileStream fin = new FileStream(filename, FileMode.Open))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(Type.GetType(filename.Replace(".json", "")));
                return json.ReadObject(fin);
            }
        }

        public static void SerializeToXML(object obj)
        {
            using (FileStream fout = new FileStream(obj.GetType().FullName + ".xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                xml.Serialize(fout, obj);
            }
        }

        public static object DeserializeFromXML(string filename)
        {
            using (FileStream fin = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(Type.GetType(filename.Replace(".xml", "")));
                return xml.Deserialize(fin);
            }
        }
    }
}
