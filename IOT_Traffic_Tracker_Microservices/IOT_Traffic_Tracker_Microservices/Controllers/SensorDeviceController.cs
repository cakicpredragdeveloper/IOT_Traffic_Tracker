using Microsoft.AspNetCore.Mvc;
using Sensor_Device_Service.Services.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensor_Device_Service.Helpers;

namespace Sensor_Device_Service.Controllers
{
    [ApiController]
    [Route("sensor-device-service")]
    public class SensorDeviceController : Controller
    {
        public SensorDeviceController(ISensorRepository sensorRepository)
        {

        }

        //TODO: POST ruta za postavljanje time limit-a

        //TODO: GET ruta za citanje time limit-a

        //TODO: POST ruta za postavljanje ammount of data

        //TODO: GET ruta za citanje ammount of data
    }
}
