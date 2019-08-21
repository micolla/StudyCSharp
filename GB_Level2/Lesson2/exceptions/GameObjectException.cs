using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level2.exceptions
{
    class GameObjectException:ApplicationException
    {
        /// <summary>
        /// Generates new Instanse with message
        /// </summary>
        /// <param name="Message">text error</param>
        public GameObjectException(string Message):base(Message){}
        public GameObjectException() : base() { }
    }
}
