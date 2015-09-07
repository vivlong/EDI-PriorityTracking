using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PriorityTracking
{

    /// <summary>
    ///XMLNodeList 的摘要说明
    /// </summary>
    public class XMLNodeList : ArrayList
    {
        public XMLNode Pop()
        {
            XMLNode item = null;

            item = (XMLNode)this[this.Count - 1];
            this.Remove(item);

            return item;
        }

        public int Push(XMLNode item)
        {
            Add(item);

            return this.Count;
        }
    }
}
