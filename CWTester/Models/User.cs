﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int GroupId { get; set; }
        public UserAuth UserAuth { get; set; }
        public Groups Groups { get; set; }
    }
}
