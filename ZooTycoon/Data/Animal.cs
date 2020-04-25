using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooTycoon.Data
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AgeInYears { 
            get {
                var ageTimeSpan = DateTime.Now - DateOfBirth;
                int ageInYears = Convert.ToInt32(ageTimeSpan.TotalDays / 365);
                return ageInYears;
            }
        }
        [Required]
        // Name of entity
        [ForeignKey("Zookeeper")]
        public int ZookeeperId { get; set; }
        public virtual Zookeeper Zookeeper { get; set; }
    }
}