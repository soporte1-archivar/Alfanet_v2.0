using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfanet.CommonObject
{
    public class ConfigData
    {
        private int dataBaseEngine;

        public int DataBaseEngine
        {
            get
            {
                return dataBaseEngine;
            }
            set
            {
                this.dataBaseEngine = value;
            }
        }
        public ConfigData()
        {
        }
    }
}
