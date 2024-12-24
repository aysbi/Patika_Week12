using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstBasic.Data.Entity
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Platform { get; set; }

        public decimal Rating { get; set; }
    }
}
