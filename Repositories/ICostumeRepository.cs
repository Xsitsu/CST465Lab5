using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Repositories
{
    interface ICostumeRepository
    {
        List<string> GetList();
        void Insert(string costume);
        void Delete(int id);
    }
}
