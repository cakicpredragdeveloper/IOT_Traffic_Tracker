using DataProvider.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiddhiProvider.Models;
using RabbitMQProvider.Send;
using CommandProvider.Models;

namespace AnalyticsService.Controllers
{
    [ApiController]
    [Route("analytics-service")]
    public class AnalyticsController : Controller
    {
        private readonly ITrackRepository _repo;
        private readonly IAnalyticCommandSender _analyticCommandSender;

        public AnalyticsController(ITrackRepository trackRepository,  IAnalyticCommandSender analyticCommandSender)
        {
            _repo = trackRepository;
            _analyticCommandSender = analyticCommandSender;
        }

        [HttpPost("analytics-result")]
        public async Task<ActionResult> CreateAnalyticsResult([FromBody] SiddhiOutputModel siddhiOutput)
        {
            var analyticsResult = siddhiOutput.Event;

            analyticsResult.Id = await _repo.GetNextAnalyticsResultId();
            await _repo.Create(analyticsResult);

            Console.WriteLine(analyticsResult.Id + "  " + analyticsResult.RecordId + " " + analyticsResult.Status + "\n");

            Command command = null;
            if (analyticsResult.Status == "Danger")
                command = new Command(1);
            else command = new Command(0);

                _analyticCommandSender.Send(command);

            return Ok("Analytics result successfully saved to database");
        }
    }
}
