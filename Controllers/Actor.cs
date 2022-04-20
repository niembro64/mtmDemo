using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace mtmDemo.Models
{
  public class Actor
  {
    [Key]
    public int ActorId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Cast> MoviesActedIn { get; set; }
  }


}