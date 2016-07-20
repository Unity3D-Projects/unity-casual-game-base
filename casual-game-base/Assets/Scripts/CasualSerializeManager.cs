using System;
using System.IO;

namespace CasualBase {
    public class CasualSerializeManager {
        
        private static CasualSerializeManager self = null;
        private CasualSerializeManager(){ }
        
        public static CasualSerializeManager getInstance(){
            if (CasualSerializeManager.self == null) {
                CasualSerializeManager.self = new CasualSerializeManager();
            }
            return CasualSerializeManager.self;
        }
        
        public static DateTime GetDateTime()
        {
            return DateTime.Today;
        }
        
        //TODO: Should we use Application.persistentDataPath ?
        public void saveToFile<T>(string filePath, T serializedObject)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, serializedObject);
            }
        }
        //TODO: Should we use Application.persistentDataPath ?
        public T loadFile<T>(string filePath)
        {
            if(!File.Exists(filePath)){
                return default (T); //Null?
            }
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
