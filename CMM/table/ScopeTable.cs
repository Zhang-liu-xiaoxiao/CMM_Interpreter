﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.table
{
    class ScopeTable
    {
        //变量名
        public string name;

        //类型
        public string type;

        //值
        public string value;

        //层数
        public int scope;

        public ScopeTable(string name, string type, string value, int scope)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.scope = scope;
        }

    }
}
