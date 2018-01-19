using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Helpers
{
    public static class ConstHelper
    {

        public static string SessionDefaultName { get { return sessionDefaultName; } }

        private const string sessionDefaultName = "FunnyName";
    }
}