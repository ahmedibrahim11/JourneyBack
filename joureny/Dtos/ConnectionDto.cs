using joureny.Data.Entities;

namespace joureny.Dtos
{
    public class ConnectionDto
    {
        public long Id { get; set; }
        public ConnectionStatus Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTittle { get; set; }
        public int Mobile { get; set; }

        public string Hobbies { get; set; }


    }
}