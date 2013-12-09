using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wrapperLibSmallWorld;

namespace CS_SmallWorld
{
    public sealed class WrapperLibSmallWorld
    {
        private static readonly WrapperLibSmallWorld instance = new WrapperLibSmallWorld();

        private WrapperLibSmallWorld() { }

        public static WrapperLibSmallWorld Instance
        {
            get
            {
                return instance;
            }
        }
    }
}