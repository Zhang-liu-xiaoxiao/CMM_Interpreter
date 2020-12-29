﻿using CMM.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMM
{
    class Constant
    {
        private static string output="";
        public static int currentScope=0;
        public static List<ScopeTable> scopeTables=new List<ScopeTable>();
        public static event Action<string> outPutAppend;
        public static event Action outPutClean;
        //控制语义分析的运行
        public static ManualResetEvent _mre = new ManualResetEvent(true);

        //唤醒线程
        public static void mreSet() {
            _mre.Set();
        }
        //停止线程
        public static void mreReset()
        {
            _mre.Reset();
        }

        public static void outputAppend(string s) {
            output += s;
            outPutAppend(s);
        }
        public static void outputClean()
        {
            output ="";
            outPutClean();
        }

        public static void currentScopeDecrease()
        {
            currentScope -= 1;
            List<ScopeTable> tables = new List<ScopeTable>();
            foreach (ScopeTable table in scopeTables)
            {
                if (table.scope == currentScope + 1)
                {
                    tables.Add(table);
                }
            }
            foreach (ScopeTable table in tables)
            {
                scopeTables.Remove(table);
            }

        }
        public static void currentScopeIncrease()
        {
            currentScope += 1;
        }
        //增||改
        public static void update(ScopeTable scopeTable)
        {
            if (check(scopeTable.name) == null)
                // 增
                scopeTables.Add(scopeTable);
            else
            //改
            {
                for (int i = 0; i < Constant.scopeTables.Count; i++)
                {
                    if (Constant.scopeTables[i].name == scopeTable.name)
                    {
                        Constant.scopeTables[i].type = scopeTable.type;
                        Constant.scopeTables[i].value = scopeTable.value;
                    }
                }
            }

        }
        //删
        public static void delete(string name)
        {
            for (int i = 0; i < Constant.scopeTables.Count; i++)
            {
                if (Constant.scopeTables[i].name == name) //赋exp表达式的值
                    Constant.scopeTables.RemoveAt(i);
            }
        }
        //查找
        public static ScopeTable check(string name)
        {
            for (int i = 0; i < Constant.scopeTables.Count; i++)
            {
                if (Constant.scopeTables[i].name == name) //赋exp表达式的值
                    return Constant.scopeTables[i];
            }
            Console.WriteLine("不存在");
            return null;
        }
    }
}

