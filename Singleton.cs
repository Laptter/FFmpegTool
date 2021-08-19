using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegSharpTest
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;

        public static T Instancia
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }
    }
}
