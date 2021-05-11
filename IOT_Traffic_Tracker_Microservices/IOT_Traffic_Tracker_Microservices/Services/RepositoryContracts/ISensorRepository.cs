using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Services.RepositoryContracts
{
    public interface ISensorRepository
    {
        // funkcija za vracanje skupa podataka
        // i njihovo slanje putem http protokola, eventualnno to prepustamo kontroleru
        void ReadData();
    }
}
