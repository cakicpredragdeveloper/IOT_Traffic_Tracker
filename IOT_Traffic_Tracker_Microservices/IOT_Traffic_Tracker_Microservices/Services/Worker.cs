using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using Sensor_Device_Service.Helpers;
using System.IO;
using ExcelDataReader;
using Sensor_Device_Service.Models;
using System.Reflection;

namespace Sensor_Device_Service.Services
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> _logger;
        private int _timeLimit;
        private int _ammountOfData;
        private bool _started;
        private int counter = 0;
        private List<Signal> dataFromSensor = new List<Signal>();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _started = false;

            object lockObject = new object();

            lock (lockObject)
            {
                _ammountOfData = DeviceParameters.AmmountOfData;
            }
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (!cancellationToken.IsCancellationRequested)
            {
                using (var stream = File.Open("dataSource.xlsx", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (!cancellationToken.IsCancellationRequested && reader.Read()) //Each ROW
                            {
                                _logger.LogInformation("New row!\n");

                                if (_started)
                                {
                                    Signal signal = new Signal();
                                    Type signalType = typeof(Signal);
                                    string currentRow = "";

                                    for (int column = 0; column < reader.FieldCount; column++)
                                    {
                                        if (reader.GetValue(column) != null)
                                        {
                                            currentRow += reader.GetValue(column).ToString() + ", ";

                                            PropertyInfo piInstance = signalType.GetProperty(DeviceParameters.SignalProperties[column]);
                                            string propertyTypeFullName = piInstance.PropertyType.FullName;

                                            if (propertyTypeFullName.Contains("System.Int32"))
                                            {
                                                int convertedValue = Int32.Parse(reader.GetValue(column).ToString());
                                                piInstance.SetValue(signal, convertedValue);
                                            }
                                            else piInstance.SetValue(signal, reader.GetValue(column));
                                        }
                                    }

                                    dataFromSensor.Add(signal);
                                    currentRow += "\n";
                                    _logger.LogInformation(currentRow);
                                    counter++;

                                    if(counter == _ammountOfData)
                                    {
                                        counter = 0;
                                        dataFromSensor.Clear();

                                        // slanje podataka drugom mikroservisu

                                        //uspavljivanje thread-a, za timeLimit

                                        object lockObject = new object();

                                        lock (lockObject)
                                        {
                                            _timeLimit = DeviceParameters.TimeLimit;
                                            _ammountOfData = DeviceParameters.AmmountOfData;
                                        }
                                        await Task.Delay(_timeLimit * 1000);
                                    }
                                }
                                else _started = true;
                            }

                        } while (!cancellationToken.IsCancellationRequested && reader.NextResult());
                    }
                }
            }
        }
    }
}
