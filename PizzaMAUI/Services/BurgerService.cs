using JustDelivery.Models;

namespace JustDelivery.Services
{
    public class BurgerService
    {
        private readonly static IEnumerable<Burger> burgers = new List<Burger>
        {
            new() {
                Name = "KARMA TOURIST",
                Image = "burger1img",
                Price = 18.50,
                Description = "Brioche Bun mit gegrillter Aubergine und Tomatenhumus, orientalischen Gewürzen, gepickeltem Rotkabis, Essiggurken und roten Zwiebeln"
            },

            new() {
                Name = "LONG BEACH",
                Image = "burger2img",
                Price = 17.50,
                Description = "Plant-based Cheeseburger, Brioche Bun, veganer Käse, Salat, Essiggurken, Zwiebeln, getrocknete Tomaten und Veganaise"
            },

            new() {
                Name = "VANCOUVER NIGHT",
                Image = "burger3img",
                Price = 19.50,
                Description = "Plant-based Bacon-Cheeseburger , veganes Bun, veganer Käse, veganer Speck, Salat, Essiggurken, Zwiebeln, getrocknete Tomaten und BBQ- Sauce"
            },

            new() {
                Name = "THE BUTCHER",
                Image = "burger4img",
                Price = 19.50,
                Description = "Bacon-Cheeseburger mit 100% Swiss Beef, Brioche Bun, Cheddar Käse, Salat, Essiggurken, getrockneten Tomaten, Zwiebeln und BBQ Sauce"
            },


            new() {
                Name = "STREET SPIRIT",
                Image = "burger6img",
                Price = 19.50,
                Description = "Brioche Bun mit gebackenem Halloumi, Sweet Potato Fries, getrockneten Tomaten, veganer BBQ Sauce und Tortilla Chips"
            },

            new() {
                Name = "SECRET GARDEN",
                Image = "burger7img",
                Price = 19.50,
                Description = "Knuspriger Bagel mit gegrillter Zucchetti, Paprika-Maissalat, Avocado, gepickelten roten Zwiebeln, Tortilla Chips und veganem Pesto"
            },

            new() {
                Name = "FULL MONTY",
                Image = "burger8img",
                Price = 26.50,
                Description = "Double Cheeseburger mit 100% Swiss Beef, Brioche Bun, Cheddar Käse, Speck, Salat, Essiggurken, getrockneten Tomaten, Zwiebeln und Burger Sauce"
            },

            new() {
                Name = "LOUISIANA PARK",
                Image = "burger9img",
                Price = 18.50,
                Description = "Planted.crispy Chickenburger, Brioche Bun, Ananas, Rucola, Zwiebeln, getrocknete Tomaten, Mango-Chutney, Chili Tortilla Chips, Chipotle Salsa und Butcher BBQ-Sauce"
            },

            new() {
                Name = "THE BUTCHER JUNIOR",
                Image = "burger10img",
                Price = 12.50,
                Description = "Bacon-Cheeseburger mit 100% Swiss Beef, Brioche Bun, Cheddar Käse, Salat, Essiggurken, Zwiebeln und Veganaise"
            },
        };
        public BurgerService()
        {
            _burgers = burgers; 
        }
        private IEnumerable<Burger> _burgers;

        public IEnumerable<Burger> GetAllBurgers() => _burgers;

        public IEnumerable<Burger> GetPopularBurgers(int count = 6) =>
            _burgers.OrderBy(p => Guid.NewGuid()).Take(count);

        public IEnumerable<Burger> SearchBurgers(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _burgers
            : _burgers.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
