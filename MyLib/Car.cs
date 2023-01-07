namespace MyLib
{
  public class Car
{
    public string manufacturer;
    public int price;
    public NumberOfSeatsAndDoors numberOfSeatsAndDoors;

    public int MyProperty { get; set; }
    public static string staticField;

    public Car(string manufacturerL, int price, NumberOfSeatsAndDoors numberOfSeatsAndDoors)
    {
        this.manufacturer = manufacturerL;
        this.price = price;
        this.numberOfSeatsAndDoors = numberOfSeatsAndDoors;
    }

    public void AccessTest()
    {
        staticField = "Test";
        MyProperty = 1;
    }
}

public struct NumberOfSeatsAndDoors
{
    public int numSeats;
    public int numDoors;

    public NumberOfSeatsAndDoors(int numSeats, int numDoors)
    {
        this.numSeats = numSeats;
        this.numDoors = numDoors;
    }
}  
}
