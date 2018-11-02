using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Repositories
{
    interface ICandyRepository
    {
        List<string> GetList();
        void Insert(string candy);
        void Delete(int id);
    }
}
