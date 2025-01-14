using Newtonsoft.Json;

namespace CIDevTools;
public class AppSettings
{
    public string userPAT { get; set; }
    public string jsonDefaultLocation { get; set; }
}

public class Build
{
    [JsonProperty("branch-name")]
    public string branchname { get; set; }
    public string buildURL { get; set; }

    [JsonProperty("Build-type")]
    public string Buildtype { get; set; }
    public bool enabled { get; set; }
}

public class ConsoleAppConfig
{
    public AppSettings appSettings { get; set; }
    public List<Build> build { get; set; }
}
