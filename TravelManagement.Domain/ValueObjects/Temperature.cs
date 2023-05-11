using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects;

public class Temperature
{
    public double Value { get; }

    public Temperature(double value)
    {
        if (value is < -100 or > 100)
        {
            throw new InvalidTemperatureException(value);
        }
        Value = value;
    }



    public static implicit operator double(Temperature temperature) { return temperature.Value; }
    public static implicit operator Temperature(double  temperature) { return new Temperature(temperature);}
}