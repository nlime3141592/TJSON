using System;
using System.Collections.Generic;

namespace nl.TJSON
{
    public class TJSON
    {
        public bool ParseNumber(string _str)
        {
            int ptr = 0;
            int radix = 10;
            char bufferedChar = '\u0000';
            bool isValidNumber = false;
            bool isFloatNumber = false;
            bool isFloatNumberE = false;

            if(string.IsNullOrEmpty(_str))
                return false;

            if(_str[ptr] == '-' || _str[ptr] == '+')
                ++ptr;
            else if (_str[ptr] < '0' || _str[ptr] > '9')
                return false;

            bufferedChar = _str[ptr];
            isValidNumber = true;
            ++ptr;

            if(ptr >= _str.Length)
                return isValidNumber;
            else if(bufferedChar == '0')
            {
                if(_str[ptr] == 'x' || _str[ptr] == 'X')
                {
                    radix = 22;
                    isValidNumber = false;
                    ++ptr;
                }
                else if(_str[ptr] == 'b' || _str[ptr] == 'B')
                {
                    radix = 2;
                    isValidNumber = false;
                    ++ptr;
                }
            }

            string digits = "0123456789ABCDEFabcdef".Substring(0, radix);

            while(ptr < _str.Length)
            {
                if(radix == 10 && isValidNumber)
                {
                    if(_str[ptr] == '.' && !isFloatNumber && !isFloatNumberE)
                    {
                        isValidNumber = false;
                        isFloatNumber = true;
                        ++ptr;
                        continue;
                    }
                    else if((_str[ptr] == 'e' || _str[ptr] == 'E') && !isFloatNumberE)
                    {
                        isFloatNumberE = true;

                        if(ptr + 1 >= _str.Length)
                            return false;
                        else if(digits.Contains(_str[ptr + 1]))
                        {
                            isValidNumber = true;
                            ptr += 2;
                            continue;
                        }
                        else if(_str[ptr + 1] == '+' || _str[ptr + 1] == '-')
                        {
                            isValidNumber = false;
                            ptr += 2;
                            continue;
                        }
                        else
                            return false;
                    }
                }

                if(!digits.Contains(_str[ptr]))
                {
                    return false;
                }
                else
                {
                    isValidNumber = true;
                    ++ptr;
                }
            }

            return isValidNumber;
        }

        public bool ParseString(string _str)
        {
            int indentLevel = 0;
            bool isBackSlashed = false;
            int i = 0;

            if(string.IsNullOrEmpty(_str) || _str[0] != '\"')
                return false;

            indentLevel = 1;
            ++i;

            while(i < _str.Length && indentLevel == 1)
            {
                if(isBackSlashed)
                {
                    switch(_str[i])
                    {
                        case '\"':
                        case '\\':
                        case '/':
                        case 'b':
                        case 'f':
                        case 'n':
                        case 'r':
                        case 't':
                            isBackSlashed = false;
                            break;
                        case 'u':
                            if(i + 4 >= _str.Length || !char.IsDigit(_str[i + 1]) || !char.IsDigit(_str[i + 2]) || !char.IsDigit(_str[i + 3]) || !char.IsDigit(_str[i + 4]))
                                return false;
                            i += 4;
                            isBackSlashed = false;
                            break;
                        default:
                            System.Diagnostics.Debug.Assert(false, "");
                            return false;
                    }
                }
                else if(char.IsControl(_str, i))
                    return false;
                else if(_str[i] == '\\')
                    isBackSlashed = true;
                else if(_str[i] == '\"')
                    --indentLevel;

                ++i;
            }

            return indentLevel == 0 && i == _str.Length;
        }

        public bool ParseArray(string _str)
        {
            int indentLevel = 0;
            bool canTerminate = true;
            bool isCommaSplited = false;
            int i = 0;

            if(string.IsNullOrEmpty(_str) || _str[0] != '[')
                return false;

            indentLevel = 1;
            ++i;

            while(i < _str.Length && indentLevel == 1)
            {
                if(canTerminate && _str[i] == ']')
                    --indentLevel;
                else if(!isCommaSplited)
                {
                    if(_str[i] == ',')
                    {
                        canTerminate = false;
                        isCommaSplited = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}