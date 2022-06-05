using System;
using System.Collections.Generic;


namespace ObserverPatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
        /*WithObserverPattern:*/
            WeatherData data = new WeatherData();
            new CurrentConditionDisplay(data);
            data.SetMeasurements(16, 50, 10);
            data.SetMeasurements(16, 70, 10);
            data.SetMeasurements(10, 90, 20);

            /*WithoutObserver*//*
            WeatherDataWithoutObserver data = new WeatherDataWithoutObserver();
            data.SetMeasurements(16, 50, 10);
            data.SetMeasurements(16, 70, 10);
            data.SetMeasurements(10, 90, 20);*/
        }
    }
}
