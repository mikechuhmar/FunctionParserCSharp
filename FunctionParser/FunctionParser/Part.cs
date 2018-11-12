﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionParser
{
    public class Part
    {
        //Разделители
        static string Signs = "()+-*/^" /*+ " "*/;
        //Проверки
        public bool IsNumber(string s)
        {
            bool flag = true;
            foreach (char symb in s)
                if (!char.IsDigit(symb))
                {
                    if (symb == ',' && flag && s.IndexOf(symb) > 0)
                        flag = true;
                    else return false;
                }
            return true;
        }
        public bool IsVariable(string s)
        {
            bool flag = true;
            if (char.IsLetter(s[0]))
            {
                foreach (char symb in s)
                {
                    if (char.IsDigit(symb))
                        flag = false;
                    else if (!char.IsLetter(symb) || char.IsLetter(symb) && !flag)
                        return false;
                }
                return true;
            }
            else return false;
        }
        public bool IsFunction(string s)
        {
            if ((s == "ln") || (s == "cos") || (s == "sin") || (s == "tg") || (s == "ctg") || (s == "exp"))
                return true;
            else
                return false;
        }
        public bool IsOperation(string s)
        {
            if ((s == "+") || (s == "-") || (s == "*") || (s == "/") || (s == "^"))
                return true;
            else
                return false;
        }
        public static bool IsSign(char symb)
        {
            foreach (char ch in Signs)
                if (symb == ch)
                    return true;
            return false;
        }
        //Часть выражения и её тип
        string term;
        TypeOfPart type;
        public string Term
        {
            get
            {
                return term;
            }
        }
        public TypeOfPart ttype
        {
            get
            {
                return type;
            }
        }
        //Определение типа
        void WhatType()
        {
            if (term[0] == '(')
                type = TypeOfPart.openBracket;
            if (term[0] == ')')
                type = TypeOfPart.closeBracket;
            if (IsOperation(term))
                type = TypeOfPart.operation;
            if (IsNumber(term))
                type = TypeOfPart.number;
            if (IsFunction(term))
                type = TypeOfPart.function;
            else if (IsVariable(term))
                type = TypeOfPart.variable;
        }
        //Конструкторы
        public Part(string s)
        {
            term = s;
            WhatType();
        }
        public Part()
        {

        }
    }
}
