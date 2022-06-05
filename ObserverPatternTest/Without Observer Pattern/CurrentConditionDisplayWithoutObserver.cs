using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObserverPatternTest
{
    class CurrentConditionDisplayWithoutObserver
    {
        private float _temperature;
        private float _humidity;
        public CurrentConditionDisplayWithoutObserver()
        {
        }
        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature + "C degrees and " + _humidity + "% humidity");
        }
    }
}
