﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Entities
{
    public class PointOfInternet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("CityId")]
        public City city {get;set;}
        public int CityId { get; set;}

        public PointOfInternet(string name)
        {
            Name = name;
        }
    }
}
