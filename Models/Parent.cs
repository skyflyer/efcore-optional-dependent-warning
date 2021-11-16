public class Parent
{
    public int Id { get; set; }
    public Dependent? Child { get; set; }
}

public class Dependent
{
    public string? Optional { get; set; }
    public bool HasFlag { get; set; }
}