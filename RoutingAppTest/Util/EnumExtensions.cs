/*
* Copyright 2021 ALE International
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of this 
* software and associated documentation files (the "Software"), to deal in the Software 
* without restriction, including without limitation the rights to use, copy, modify, merge, 
* publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons 
* to whom the Software is furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all copies or 
* substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
* BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
* DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using o2g;
using o2g.Types;
using o2g.Types.RoutingNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingAppTest.Util
{
    public class EnumUtil
    {
        public static int IndexOf(Forward.ForwardCondition? condition)
        {
            if ((condition == null) || (condition == Forward.ForwardCondition.Immediate)) return 0;
            else if (condition == Forward.ForwardCondition.Busy) return 1;
            else if (condition == Forward.ForwardCondition.NoAnswer) return 2;
            else return 3;
        }

        public static Forward.ForwardCondition GetForwardCondition(int index)
        {
            if (index == 0) return Forward.ForwardCondition.Immediate;
            else if (index == 1) return Forward.ForwardCondition.Busy;
            else if (index == 2) return Forward.ForwardCondition.NoAnswer;
            else return Forward.ForwardCondition.BusyOrNoAnswer;
        }

        public static int IndexOf(Overflow.OverflowCondition? condition)
        {
            if ((condition == null) || (condition == Overflow.OverflowCondition.Busy)) return 0;
            else if (condition == Overflow.OverflowCondition.NoAnswer) return 1;
            else return 2;
        }

        public static Overflow.OverflowCondition GetOverflowCondition(int index)
        {
            if (index == 0) return Overflow.OverflowCondition.Busy;
            else if (index == 1) return Overflow.OverflowCondition.NoAnswer;
            else return Overflow.OverflowCondition.BusyOrNoAnswer;
        }
    }
}