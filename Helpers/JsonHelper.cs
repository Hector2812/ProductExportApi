using System.Text.Json;

namespace ProductExportApi.Helpers;

public static class JsonHelper
{
    public static T? LoadFromJson<T>(string path)
    {
        if (!File.Exists(path)) return default;
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static void SaveToJson<T>(T data, string path)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}