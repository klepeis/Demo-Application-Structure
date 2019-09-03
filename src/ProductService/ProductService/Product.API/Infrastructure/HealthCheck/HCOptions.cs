using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Mime;

namespace Product.API.Infrastructure.HealthCheck
{
    public class HCOptions : HealthCheckOptions
    {
        public HCOptions()
        {
            this.ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;
                var result = JsonConvert.SerializeObject(
                   new
                   {
                       checks = r.Entries.Select(e =>
                      new
                      {
                          description = e.Key,
                          status = e.Value.Status.ToString(),
                          responseTime = e.Value.Duration.TotalMilliseconds
                      }),
                       totalResponseTime = r.TotalDuration.TotalMilliseconds
                   });
                await c.Response.WriteAsync(result);
            };
        }
    }
}
