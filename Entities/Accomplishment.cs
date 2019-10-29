using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Entities
{
    public class Accomplishment
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string DateOfAccomplishment { get; set; }
    }
}
