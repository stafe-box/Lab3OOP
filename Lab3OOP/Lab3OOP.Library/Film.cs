using System;
using System.Collections.Generic;

namespace Lab3OOP.Library;

public partial class Film
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Genre { get; set; }

    public long Studio { get; set; }

    public long Director { get; set; }

    public virtual Director DirectorNavigation { get; set; } = null!;

    public virtual Genre GenreNavigation { get; set; } = null!;

    public virtual Studio StudioNavigation { get; set; } = null!;
}
