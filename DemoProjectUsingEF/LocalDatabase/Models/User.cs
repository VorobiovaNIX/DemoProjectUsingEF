﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
