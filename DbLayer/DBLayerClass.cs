using DbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DbLayer
{
    public  class DBLayerClass //:IDBLayerClass
    {
        DataContext _context;
        public DBLayerClass()
        {
            _context = new DataContext();
        }
        public async Task WeaterhDataInsert(WeatherData weatherData)
        {
            try
            {
                await _context.WeatherData.AddAsync(weatherData);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}
