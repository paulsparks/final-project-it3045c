namespace final_project_it3045c.HelperFunctions
{
    public class CopyProperties
    {
        public static void Copy<T>(T source, T destination) where T : class
        {
            // Use reflection to copy properties from source to destination
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // Exclude properties that should not be updated (e.g., Id)
                if (property.Name != "Id")
                {
                    var value = property.GetValue(source, null);
                    property.SetValue(destination, value, null);
                }
            }
        }
    }
}