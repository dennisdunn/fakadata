﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Timeseries.Api.Models
{
  public static  class Extensions
    {
        public static ITsInfo GetInfo(this ITsDescription item)
        {
            return new TsInfo { _id = item._id, Name = item.Name };
        }
    }
}
