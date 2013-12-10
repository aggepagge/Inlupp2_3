using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explotion.Model
{
    class ExplotionModel
    {
        public Level Level { get; private set; }

        //Initsierar Level-objektet
        internal ExplotionModel()
        {
            Level = new Level();
        }
    }
}
