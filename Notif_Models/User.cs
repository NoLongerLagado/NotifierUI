﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notif_Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public User()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}

