namespace Disqussing
{
	using System.Globalization;
	using System.IO;
	using System.Text;
	using Newtonsoft.Json;

	class SerializationHelper
	{
		/// <summary>
		/// Deserializes json into an instance of T.
		/// </summary>
		/// <typeparam name="T">The type to be returned.</typeparam>
		/// <param name="json">The json.</param>
		/// <returns>An instance of T</returns>
		public static T DeserializeJson<T>(string json)
			  where T : new()
		{
			JsonSerializer ser = new JsonSerializer();

			ser.NullValueHandling = NullValueHandling.Ignore;
			ser.ObjectCreationHandling = ObjectCreationHandling.Replace;
			ser.MissingMemberHandling = MissingMemberHandling.Ignore;
			ser.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

			using (StringReader sr = new StringReader(json))
			{
				JsonTextReader reader = new JsonTextReader(sr);
				return (T)ser.Deserialize(reader, typeof(T));
			}
		}

		/// <summary>
		/// Serializes T to json.
		/// </summary>
		/// <typeparam name="T">The type to be serialized.</typeparam>
		/// <param name="item">The object to be serialized.</param>
		/// <returns>Json represntation of item.</returns>
		public static string SerializeJson<T>(T item)
			where T : new()
		{
			JsonSerializer ser = new JsonSerializer();

			ser.NullValueHandling = NullValueHandling.Ignore;
			ser.ObjectCreationHandling = ObjectCreationHandling.Replace;
			ser.MissingMemberHandling = MissingMemberHandling.Ignore;
			ser.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

			StringBuilder sb = new StringBuilder();
			using (StringWriter sw = new StringWriter(sb, CultureInfo.CurrentCulture))
			{
				JsonTextWriter writer = new JsonTextWriter(sw);
				ser.Serialize(sw, item);
			}
			return sb.ToString();
		}
	}
}