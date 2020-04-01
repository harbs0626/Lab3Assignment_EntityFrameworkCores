﻿using System;
using System.Collections.Generic;

namespace Q3_WPFBooks.Models
{
    public partial class AuthorIsbn
    {
        public int AuthorId { get; set; }
        public string Isbn { get; set; }

        public virtual Authors Author { get; set; }
        public virtual Titles IsbnNavigation { get; set; }
    }
}
