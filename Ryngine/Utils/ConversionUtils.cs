using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Ryngine.Utils
{
    public static class ConversionUtils
    {

        // TODO: Deprecate for BitConverter.ToInt128 when .NET 9 comes out.
        public static Int128 ToInt128(this byte[] bytes)
        {
            return new Int128(
                BitConverter.ToUInt64(bytes.AsSpan(0, 8)),
                BitConverter.ToUInt64(bytes.AsSpan(8, 8)));
        }

        // TODO: Deprecate for BitConverter.ToInt128 when .NET 9 comes out.
        public static byte[] ToBytes(this Int128 num)
        {
            if (BitConverter.IsLittleEndian)
            {
                return [
                    .. BitConverter.GetBytes((ulong)num),
                    .. BitConverter.GetBytes((ulong)(num >> 64)),
                ];
            }
            else
            {
                return [
                    .. BitConverter.GetBytes((ulong)(num >> 64)),
                    .. BitConverter.GetBytes((ulong)num),
                ];
            }
        }

        public static readonly JsonSerializer JsonSerializer = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static JObject ToJObject(this object obj)
        {
            return JObject.FromObject(obj, JsonSerializer);
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}
