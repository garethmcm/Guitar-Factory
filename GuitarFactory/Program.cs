// choose a guitar and produce it using factory method
// TODO integrate 

Console.WriteLine("What guitar do you want?");
Console.WriteLine("1 - Telecaster");
Console.WriteLine("2 - Stratocaster");
Console.WriteLine("3 - SG");
Console.WriteLine("3 - Les Paul");
Console.WriteLine("5 - Build your own");

string choice = Console.ReadLine();

Guitar guitar = choice switch
{
    "1" => Guitar.CreateStandardTelecaster(),
    "2" => Guitar.CreateStandardStratocaster(),
    "3" => Guitar.CreateStandardSG(),
    "4" => Guitar.CreateStandardLesPaul(),
    _ => CreateCustomGuitar(),
};

Console.WriteLine($"That guitar costs £{guitar.Cost}.");

Guitar CreateCustomGuitar()
{
    Colour colour = GetColour();
    Neck neck = GetNeck();
    Pickups pickups = GetPickups();
    
    double length = GetLength();

    return new Guitar(colour, neck, pickups, length);
}

Colour GetColour()
{
    Console.Write("Please choose a colour: (butterscotch, sunburst, cherry red, surf green): ");
    string input = Console.ReadLine();
    return input switch
    {
        "butterscotch" => Colour.Butterscotch,
        "sunburst" => Colour.Sunburst,
        "cherry red" => Colour.CherryRed,
        "surf green" => Colour.SurfGreen
    };
}

Neck GetNeck()
{
    Console.Write("Please pick a neck: (maple, rosewood, mahogany): ");
    string input = Console.ReadLine();
    return input switch
    {
        "maple" => Neck.Maple,
        "rosewood" => Neck.Rosewood,
        "mahogany" => Neck.Mahogany
    };
}

Pickups GetPickups()
{
    Console.Write("Please pick a pickup: (single coil, humbucker, P90, wide range): ");
    string input = Console.ReadLine();
    return input switch
    {
        "single coil" => Pickups.SingleCoil,
        "humbucker" => Pickups.Humbucker,
        "P90" => Pickups.P90,
        "Wide range" => Pickups.WideRange,
    };
}

double GetLength()
{
    double length = 0;

    while (length < 24 || length > 26.5)
    {
        Console.Write("Item length (between 24 and 26.5): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

public class Guitar
{
    public Colour Colour { get; }
    public Neck Neck { get; }
    public Pickups Pickups { get; }
    public double Length { get; }

    public Guitar(Colour colour, Neck neck, Pickups pickups, double length)
    {
        Colour = colour;
        Neck = neck;
        Pickups = pickups;
        Length = length;
    }

    public double Cost
    {
        get
        {
            double colourCost = Colour switch
            {
                Colour.Butterscotch => 200,
                Colour.Sunburst => 150,
                Colour.CherryRed => 175,
                Colour.SurfGreen => 190
            };

            double neckCost = Neck switch
            {
                Neck.Maple => 125,
                Neck.Rosewood => 125,
                Neck.Mahogany => 125
            };

            double pickupsCost = Pickups switch
            {
                Pickups.SingleCoil => 75,
                Pickups.Humbucker => 75,
                Pickups.P90 => 80,
                Pickups.WideRange => 90
            };

            return colourCost + neckCost + pickupsCost + Length;
        }
    }

    public static Guitar CreateStandardTelecaster() => new Guitar(Colour.Butterscotch, Neck.Maple, Pickups.WideRange, 25.5);
    public static Guitar CreateStandardStratocaster() => new Guitar(Colour.SurfGreen, Neck.Rosewood, Pickups.SingleCoil, 25.5);
    public static Guitar CreateStandardSG() => new Guitar(Colour.CherryRed, Neck.Mahogany, Pickups.P90, 24.75);
    public static Guitar CreateStandardLesPaul() => new Guitar(Colour.Sunburst, Neck.Mahogany, Pickups.Humbucker, 24.75);
}

public enum Colour { Butterscotch, Sunburst, CherryRed, SurfGreen }
public enum Neck { Maple, Rosewood, Mahogany }
public enum Pickups { SingleCoil, Humbucker, P90, WideRange }
// TODO enum for scale length with custom option which allows user input for double scalelength