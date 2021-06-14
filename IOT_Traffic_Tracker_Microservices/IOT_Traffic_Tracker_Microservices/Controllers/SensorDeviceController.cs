using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensor_Device_Service.Helpers;
using Sensor_Device_Service.Models;


namespace Sensor_Device_Service.Controllers
{
    [ApiController]
    [Route("sensor-device-service")]
    public class SensorDeviceController : Controller
    {
        public SensorDeviceController()
        {
           
        }

        [HttpPost("time-limit")]
        public IActionResult SetTimeLimit([FromBody] int newTimeLimit)
        {
            object lockObject = new object();

            lock (lockObject)
            {
                if (newTimeLimit > 4 && newTimeLimit < 15)
                {
                    DeviceParameters.TimeLimit = newTimeLimit;
                    return Ok("Time limit is set successfully");
                }
                else return BadRequest("Inalid parameter!");
            }

        }

        [HttpGet("time-limit")]
        public IActionResult GetTimeLimit()
        {
            object lockObject = new object();
            int result;
            lock (lockObject)
            {
                result = DeviceParameters.TimeLimit;
            }

            return Ok(result);
        }

        [HttpPost("ammount-of-data")]
        public IActionResult SetAmmountOfData([FromBody] int newAmmountOfData)
        {
            object lockObject = new object();

            lock (lockObject)
            {
                if (newAmmountOfData < 10 && newAmmountOfData > 0) 
                {
                    DeviceParameters.AmmountOfData = newAmmountOfData;
                    return Ok("Ammount of data is set successfully");
                }
                else
                    return BadRequest("Invalid parameter!");
            }
        }

        [HttpGet("ammount-of-data")]
        public IActionResult GetAmmountOfData()
        {
            object lockObject = new object();
            int result;
            lock (lockObject)
            {
                result = DeviceParameters.AmmountOfData;
            }

            return Ok(result);
        }

        [HttpGet("danger-mode-on")]
        public IActionResult DangerModeOn()
        {
            object lockObject = new object();
            lock (lockObject)
            {
                if (DeviceParameters.AmmountOfData < 10)
                    DeviceParameters.AmmountOfData++;

                if (DeviceParameters.TimeLimit > 5)
                    DeviceParameters.TimeLimit--;
            }

            Console.WriteLine("Danger mode is turned on!");

            return Ok("Danger mode is turned on!");
        }

        [HttpGet("normal-mode-on")]
        public IActionResult NormalModeOn()
        {
            object lockObject = new object();
            lock (lockObject)
            {
                if (DeviceParameters.AmmountOfData > 1)
                    DeviceParameters.AmmountOfData--;

                if (DeviceParameters.TimeLimit < 15)
                    DeviceParameters.TimeLimit++;
            }

            Console.WriteLine("Normal mode is turned on!");

            return Ok("Normal mode is turned on!");
        }
    }
}
