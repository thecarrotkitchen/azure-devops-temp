using Newtonsoft.Json;// ConsoleAppSettings myDeserializedClass = JsonConvert.DeserializeObject<ConsoleAppSettings>(myJsonResponse);
    public class AppSettings
    {
        public string userPAT { get; set; }
        public string jsonDefaultLocation { get; set; }
        public string adoWorkItemUri { get; set; }
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

    public class ConsoleAppSettings
    {
        public AppSettings AppSettings { get; set; }
        public List<Build> build { get; set; }
        public StandAloneCalls StandAloneCalls { get; set; }
    }

    public class StandAloneCalls
    {
        public string userPAT { get; set; }
        public string jsonDefaultLocation { get; set; }
        public string adoWorkItemUri { get; set; }
    }

