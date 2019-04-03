﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public static  class Extensions
    {
        public static ITsInfo GetInfo(this ITsDescription item)
        {
            return new TsInfo { Id = item.Id, Name = item.Name };
        }
    }
}
