using WLWD4.Interfaces;

namespace WLWD4.Entities
{
    internal class Computer
    {
        public int Id { set; get; } 
        public bool IsAdmin { get; set; }
        public string Name { get; set; }

        public Computer(int id = -1, bool isAdmin = false, string name = "") 
            => (Id, IsAdmin, Name) = (id, isAdmin, name);

        public override string ToString()
            => $"Id: {Id}; IsAdmin: {IsAdmin}; Name: {Name}";
    }
}
