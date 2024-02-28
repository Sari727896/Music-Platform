using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface IRepoBl<T>
    {
        public List<T> GetAll();
        public T Add(T something);
        public T Update(T something, int somethimgCode);
        public T Delete(int code);
    }
}
