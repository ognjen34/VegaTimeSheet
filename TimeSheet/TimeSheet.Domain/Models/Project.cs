
namespace TimeSheet.Domain.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Client Client { get; set; }
        public User Lead {  get; set; }
        public Guid LeadId { get; set; }
        public Guid ClientId {  get; set; }

    }
}
