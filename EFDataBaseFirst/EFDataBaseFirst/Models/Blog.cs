﻿using System;
using System.Collections.Generic;

namespace EFDataBaseFirst.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
