using CommandProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace APIGateway.Services
{
    public class CommandGateway : ICommandGateway
    {
        public async Task<IEnumerable<Command>> GetCommands()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://commandservice/command"))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Command>>(stringResponse);
                }
            }
        }
    }
}
