using Newtonsoft.Json.Serialization;

public class DynamicContractResolver : DefaultContractResolver
{
    private readonly char _startingWithChar;

    // public DynamicContractResolver(char startingWithChar)
    // {
    //     _startingWithChar = startingWithChar;
    // }

    protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
    {
        IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

        // only serializer properties that start with the specified character
        // properties =
        //     properties.Where(p => p.PropertyName.StartsWith(_startingWithChar.ToString())).ToList();

        return properties;
    }
}