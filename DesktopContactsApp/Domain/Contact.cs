using SQLite;

namespace DesktopContactsApp.Domain
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        [Unique]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
