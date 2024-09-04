﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneToOneFluentDemo.Models
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Address  Address { get; set; }
    }
}