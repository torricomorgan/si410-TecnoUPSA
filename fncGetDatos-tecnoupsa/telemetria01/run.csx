#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, IEnumerable<dynamic> datos1)
{
     return new OkObjectResult(datos1);
}
