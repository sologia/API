using System.ComponentModel.DataAnnotations;

namespace sharedmodels
{
    public class Person
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
