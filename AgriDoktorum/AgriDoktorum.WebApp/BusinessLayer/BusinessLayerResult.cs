using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.BusinessLayer
{
    public class BusinessLayerResult<T> where T : class
    {
        public List<string> ErrorList { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            ErrorList = new List<string>();
        }
    }
}