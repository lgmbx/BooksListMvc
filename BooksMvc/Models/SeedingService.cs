using System.Linq;

namespace BooksMvc.Models {
    public class SeedingService {

        private readonly AppDbContext _db;
        public SeedingService(AppDbContext db) {
            _db = db;
        }

        public void Seed() {
            if (_db.Book.Any()) {
                return;
            }
            Book b1 = new Book("Judgment", "Reynard", "123");
            Book b2 = new Book("Millenium", "Larson", "456");
            Book b3 = new Book("LOTR", "Tolkien", "789");
            Book b4 = new Book("Eragon", "Paolini", "1011");

            _db.Book.AddRange(b1, b2, b3, b4);
            _db.SaveChanges();
        }
    }
}
