using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
 
namespace SessionWrapper
{
    [Serializable]
    public class Wrapper : ISerializable
    {
        public object Value { get; set; }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Value != null)
            {
                info.AddValue("IsNull", false);
                if (Value.GetType().GetCustomAttributes(typeof(DataContractAttribute), false).Length == 1)
                {
                    using (var ms = new MemoryStream())
                    {
                        var serializer = new DataContractSerializer(Value.GetType());
                        serializer.WriteObject(ms, Value);
                        info.AddValue("Bytes", ms.ToArray());
                        info.AddValue("IsDataContract", true);
                    }
                }
                else if (Value.GetType().IsSerializable)
                {
                    info.AddValue("Value", Value);
                    info.AddValue("IsDataContract", false);
                }
                info.AddValue("Type", Value.GetType());
            }
            else
            {
                info.AddValue("IsNull", true);
            }
        }

        public Wrapper(SerializationInfo info, StreamingContext context)
        {
            if (!info.GetBoolean("IsNull"))
            {
                var type = info.GetValue("Type", typeof(Type)) as Type;

                if (info.GetBoolean("IsDataContract"))
                {
                    using (var ms = new MemoryStream(info.GetValue("Bytes", typeof(byte[])) as byte[]))
                    {
                        var serializer = new DataContractSerializer(type);
                        Value = serializer.ReadObject(ms);
                    }
                }
                else
                {
                    Value = info.GetValue("Value", type);
                }
            }
        }
    }
}
