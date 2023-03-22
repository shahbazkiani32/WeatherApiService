using DbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer
{
    public interface IDBLayerClass
    {
        Task WeaterhDataInsert(WeatherData weatherData);
    }
}
