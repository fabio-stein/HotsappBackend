using DbManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbManager.Contexts
{
    public class UserContext : DataContext
    {
        public void ComplexQuery()
        {
            User.FromSql("");
        }
    }
}
