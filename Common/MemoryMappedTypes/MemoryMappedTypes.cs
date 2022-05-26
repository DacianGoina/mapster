using System.Runtime.InteropServices;

namespace Mapster.Common.MemoryMappedTypes;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct FileHeader
{
    [FieldOffset(0)] public long Version;
    [FieldOffset(8)] public int TileCount;
}

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct TileHeaderEntry
{
    [FieldOffset(0)] public int ID;
    [FieldOffset(4)] public ulong OffsetInBytes;
}

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct TileBlockHeader
{
    /// <summary>
    ///     Number of renderable features in the tile.
    /// </summary>
    [FieldOffset(0)] public int FeaturesCount;

    /// <summary>
    ///     Number of coordinates used for the features in the tile.
    /// </summary>
    [FieldOffset(4)] public int CoordinatesCount;

    /// <summary>
    ///     Number of strings used for the features in the tile.
    /// </summary>
    [FieldOffset(8)] public int StringCount;

    /// <summary>
    ///     Number of characters used by the strings in the tile.
    /// </summary>
    [FieldOffset(12)] public int CharactersCount;

    [FieldOffset(16)] public ulong CoordinatesOffsetInBytes;
    [FieldOffset(24)] public ulong StringsOffsetInBytes;
    [FieldOffset(32)] public ulong CharactersOffsetInBytes;
}

/// <summary>
///     References a string in a large character array.
/// </summary>
[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct StringEntry
{
    [FieldOffset(0)] public int Offset;
    [FieldOffset(4)] public int Length;
}

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct Coordinate
{
    [FieldOffset(0)] public double Latitude;
    [FieldOffset(8)] public double Longitude;

    public Coordinate()
    {
        Latitude = 0;
        Longitude = 0;
    }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public bool Equals(Coordinate other)
    {
        return Math.Abs(Latitude - other.Latitude) < double.Epsilon &&
               Math.Abs(Longitude - other.Longitude) < double.Epsilon;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinate other && Equals(other);
    }

    public static bool operator ==(Coordinate self, Coordinate other)
    {
        return self.Equals(other);
    }

    public static bool operator !=(Coordinate self, Coordinate other)
    {
        return !(self == other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longitude);
    }
}

public enum PropertyKeysEnum
{
    Natural = 0,
    Place = 1,
    Boundary = 2,
    Admin_level = 3,
    Name = 4,
    Highway = 5,
    Water = 6,
    Railway = 7,
    Landuse = 8,
    Building = 9,
    Leisure = 10,
    Amenity = 11,
}

public enum PropertyValuesEnum
{
    // geo enum types
    Fell = 0,
    Grassland = 0,
    Heath = 0,
    Moor = 0,
    Scrub = 0,
    Wetland = 0,
    Wood = 1,
    Tree_row = 1,

    Scree = 2,
    Rock = 2,
    Bare_rock = 2,

    Beach = 3,
    Sand = 3,
    Administrative = 4,
    RandomTwo = 13,
    Motorway = 14,
    Trunk = 14,
    Primary = 14,
    Secondary = 14,
    Tertiary = 14,
    Unclassified = 14,
    Road = 14,
    Wter = 15,


    // GeoFeatureType for Residential
    Residential = 10,
    Industrial = 10,
    Commercial = 10,
    Cemetery = 10,
    Square = 10,
    Construction = 10,
    Military = 10,
    Quarry = 10,
    Brownfield = 10,

    // GeoFeatureType for Forest
    Forest = 9,
    Orchard = 9,

    // geoFeatureType for plains
    Farm = 11,
    Meadow = 11,
    Grass = 11,
    Greenfield = 11,
    Recreation_ground = 11,
    Winter_sports = 11,
    Allotments = 11,

    
    Reservoir = 12,
    Basin = 12,

}


public class StringToEnumIdConverter
{
    public static int getEnumIdKeys(string key)
    {
        switch (key)
        {
            case ("natural"):
                return 0;
            case ("place"):
                return 1;
            case ("boundary"):
                return 2;
            case ("admin_level"):
                return 3;
            case ("name"):
                return 4;
            case ("highway"):
                return 5;
            case ("water"):
                return 6;
            case ("railway"):
                return 7;
            case ("landuse"):
                return 8;
            case ("building"):
                return 9;
            case ("leisure"):
                return 10;
            case ("amenity"):
                return 11;
            default:
                return -1;
        }
    }

    public static int getEnumIdValues(string key)
    {
        switch (key)
        {
            case ("fell"):
                return 0;
            case ("grassland"):
                return 0;
            case ("heath"):
                return 0;
            case ("moor"):
                return 0;
            case ("scrub"):
                return 0;
            case ("wetland"):
                return 0;
            case ("wood"):
                return 1;
            case ("tree_row"):
                return 1;
            case ("bare_rock"):
                return 2;
            case ("rock"):
                return 2;
            case ("scree"):
                return 2;
            case ("sand"):
                return 3;
            case ("beach"):
                return 3;
            case ("water"):
                return 15;
            case ("administrative"):
                return 4;
            case ("city"):
                return 5;
            case ("town"):
                return 5;
            case ("locality"):
                return 5;
            case ("hamlet"):
                return 5;

            case ("military"):
                return 10;
            case ("quarry"):
                return 10;
            case ("brownfield"):
                return 10;
            case ("residential"):
                return 10;
            case ("cemetery"):
                return 10;
            case ("industrial"):
                return 10;
            case ("commercial"):
                return 10;
            case ("square"):
                return 10;
            case ("construction"):
                return 10;


            case ("forest"):
                return 9;
            case ("orchard"):
                return 9;


            case ("farm"):
                return 11;
            case ("meadow"):
                return 11;
            case ("grass"):
                return 11;
            case ("greenfield"):
                return 11;
            case ("recreation_ground"):
                return 11;
            case ("winter_sports"):
                return 11;
            case ("allotments"):
                return 11;


            case ("reservoir"):
                return 12;
            case ("basin"):
                return 12;

            case ("2"):
                return 13;

            case ("motorway"):
                return 14;
            case ("trunk"):
                return 14;
            case ("primary"):
                return 14;
            case ("secondary"):
                return 14;
            case ("tertiary"):
                return 14;
            case ("unclassified"):
                return 14;
            case ("road"):
                return 14;

            default:
                return -1;
        }
    }
}

public enum GeometryType : byte
{
    Polyline,
    Polygon,
    Point
}

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct PropertyEntryList
{
    [FieldOffset(0)] public int Count;
    [FieldOffset(4)] public ulong OffsetInBytes;
}

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct MapFeature
{
    // https://wiki.openstreetmap.org/wiki/Key:highway
    public static string[] HighwayTypes =
    {
        "motorway", "trunk", "primary", "secondary", "tertiary", "unclassified", "residential", "road"
    };

    [FieldOffset(0)] public long Id;
    [FieldOffset(8)] public int LabelOffset;
    [FieldOffset(12)] public GeometryType GeometryType;
    [FieldOffset(13)] public int CoordinateOffset;
    [FieldOffset(17)] public int CoordinateCount;
    [FieldOffset(21)] public int PropertiesOffset;
    [FieldOffset(25)] public int PropertyCount;
}