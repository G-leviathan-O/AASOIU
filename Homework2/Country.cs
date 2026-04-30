class Country
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Country(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Country() : this(0, "") { }

    public override string ToString()
    {
        return $"[{Id}] {Name}";
    }
}