﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDemo.Interfaces;

namespace UnityDemo
{
    public class PriceySpeaker : ISpeaker
    {
        public void Start()
        {
            Console.WriteLine("Sounds Pricey");
        }
    }
}

