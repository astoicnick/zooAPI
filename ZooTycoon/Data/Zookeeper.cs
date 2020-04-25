using System.ComponentModel.DataAnnotations;

namespace ZooTycoon.Data
{
    public class Zookeeper
    {
        [Key]
        public int ZookeeperId { get; set; }
        public string Name { get; set; }
        public int AnimalsCaringFor { get; set; }
    }
}