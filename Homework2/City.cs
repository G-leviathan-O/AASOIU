class City
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }

    private int _population;

    public int PopulationK
    {
        get { return _population; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Population cannot be negative");
            _population = value;
        }
    }

    public City(int id, int countryId, string name, int populationK)
    {
        Id = id;
        CountryId = countryId;
        Name = name;
        PopulationK = populationK;
    }

    public City() : this(0, 0, "", 0) { }

    public override string ToString()
    {
        return $"[{Id}] {Name}, Country #{CountryId}, Pop: {PopulationK}k";
    }
}