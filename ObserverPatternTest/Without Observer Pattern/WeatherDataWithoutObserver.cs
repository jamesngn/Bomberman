using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternTest
{
    class WeatherDataWithoutObserver
    {
        private CurrentConditionDisplayWithoutObserver _currentConditionDisplay;
        private float _temperature;
        private float _humidity;
        private float _pressure;
        public WeatherDataWithoutObserver()
        {
            _currentConditionDisplay = new CurrentConditionDisplayWithoutObserver();
        }
        public void MeasurementsChanged()
        {
            _currentConditionDisplay.Update(_temperature, _humidity, _pressure);
        }
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            MeasurementsChanged();
        }
    }
}
