﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI
{
    public static class MyConfig
    {
        public static string ConnectionString { get { return @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TripAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"; } }
    }
}
