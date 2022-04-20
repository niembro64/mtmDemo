using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace mtmDemo.Models
{
  public class Cast
  {
    [Key]
    public int CastId { get; set; }

    public int ActorId { get; set; }

    public int MovieId { get; set; }

    public Actor Actor { get; set; }
    public Movie Movie { get; set; }
  }
}