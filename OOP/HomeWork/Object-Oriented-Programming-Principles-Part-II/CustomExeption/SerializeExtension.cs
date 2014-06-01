namespace CustomExeption
{
    using System.Runtime.Serialization;

    public static class SerializeExtension
    {
        public static T GetValue<T>(this SerializationInfo si, string name)
        {
            return (T)si.GetValue(name, typeof(T));
        }
    }
}
