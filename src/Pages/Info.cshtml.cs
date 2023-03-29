using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetDemoapp.Pages
{
    // [Authorize]
    public class SystemInfoModel : PageModel
    {
        private readonly ILogger<SystemInfoModel> _logger;
        private readonly TelemetryClient _telemetryClient;
        private readonly IConfiguration _config;

        public bool isInContainer { get; private set; } = false;
        public bool isInKubernetes { get; private set; } = false;
        public bool isAppInsightsEnabled { get; private set; } = false;
        public string hostname { get; private set; } = "";
        public string osDesc { get; private set; } = "";
        public string osArch { get; private set; } = "";
        public string osVersion { get; private set; } = "";
        public string framework { get; private set; } = "";
        public string processorCount { get; private set; } = "";
        public string workingSet { get; private set; } = "";
        public string physicalMem { get; private set; } = "";
        public Dictionary<string, string> envVars { get; private set; } = new Dictionary<string, string>();

        public SystemInfoModel(ILogger<SystemInfoModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {}
    }
}
