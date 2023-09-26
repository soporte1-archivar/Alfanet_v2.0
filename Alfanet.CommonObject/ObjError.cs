using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Alfanet.CommonObject
{
    public class ObjError
    {
        [XmlElement("stackTrace")]
        private string stackTrace;

        public string StackTrace
        {
            get { return stackTrace; }
            set { stackTrace = value; }
        }
        [XmlElement("messegeError")]
        private string messegeError;

        public string MessegeError
        {
            get { return messegeError; }
            set { messegeError = value; }
        }
        [XmlElement("errorCode")]
        private string errorCode;

        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }
    }
}
