using System;
using System.Collections.Generic;

namespace Lab3OOP.Library;

public partial class Genre
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
