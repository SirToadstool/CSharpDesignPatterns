namespace Patterns.DesignPatterns;

public class Pizza
{
    public string Size { get; private set; }

    public bool HasCheese { get; private set; }
    public bool HasPepperoni { get; private set; }
    public bool HasSausage { get; private set; }
    public bool HasMushrooms { get; private set; }
    public bool HasOlives { get; private set; }
    public string Crust { get; private set; }

    private Pizza(PizzaBuilder builder)
    {
        Size = builder.Size;
        HasCheese = builder.HasCheese;
        HasPepperoni = builder.HasPepperoni;
        HasSausage = builder.HasSausage;
        HasMushrooms = builder.HasMushrooms;
        HasOlives = builder.HasOlives;
        Crust = builder.Crust;
    }

    public override string ToString()
    {
        List<string> toppings = [];

        if (HasCheese) toppings.Add("cheese");
        if (HasPepperoni) toppings.Add("pepperoni");
        if (HasSausage) toppings.Add("sausage");
        if (HasMushrooms) toppings.Add("mushrooms");
        if (HasOlives) toppings.Add("olives");

        string toppingsList = toppings.Count > 0 ? string.Join(", ", toppings) : "no toppings";

        return $"{Size} pizza with {Crust} crust and {toppingsList}";
    }

    public class PizzaBuilder(string size)
    {
        public string Size { get; private set; } = size;

        public bool HasCheese { get; private set; } = false;
        public bool HasPepperoni { get; private set; } = false;
        public bool HasSausage { get; private set; } = false;
        public bool HasMushrooms { get; private set; } = false;
        public bool HasOlives { get; private set; } = false;
        public string Crust { get; private set; } = "regular";

        public PizzaBuilder AddCheese()
        {
            HasCheese = true;
            return this;
        }

        public PizzaBuilder AddPepperoni()
        {
            HasPepperoni = true;
            return this;
        }

        public PizzaBuilder AddSausage()
        {
            HasSausage = true;
            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            HasMushrooms = true;
            return this;
        }

        public PizzaBuilder AddOlives()
        {
            HasOlives = true;
            return this;
        }

        public PizzaBuilder WithCrust(string crust)
        {
            Crust = crust;
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(this);
        }
    }
}