using Microsoft.AspNetCore.Mvc;
using Sensor_Device_Service.Services.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_Traffic_Tracker_Microservices.Controllers
{
    [ApiController]
    [Route("sensor-device-service")]
    public class SensorDeviceController : Controller
    {
        private readonly ISensorRepository _sensorRepository;

        //kontroler kojim ce da upravlja radom SensorDevice servisa
        public SensorDeviceController(ISensorRepository sensorRepository)
        {
            //klasa tj interfejs kojim ce da se upravlja podacima
            //njihovo slanje, primanje
            //moze i propertiji da se navedu u interferjsu, iskoristicemo ih za kontrolne signale
            //ne svidja mi se da se zove repository u ovom slucaju ali promenicemo naziv
            _sensorRepository = sensorRepository;

            //ovde se okida fja iz repository-a za ucitavanje podataka i njihovo slanje drugom servisu
            //da bi odmah po pokretanju krenuo sa radom
        }

        //TODO -- ruta za postavljanje time limit-a


        //TODO -- ruta za citanje time limit-a
    }
}
