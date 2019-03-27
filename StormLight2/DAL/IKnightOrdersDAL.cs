﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormLight2.Models;

namespace StormLightArchive.DAL
{
    public interface IKnightOrdersDAL
    {
        List<KnightOrdersModel> GetAllKnightOrders();

        KnightOrdersModel GetKnightOrder(string name);
    }
}
