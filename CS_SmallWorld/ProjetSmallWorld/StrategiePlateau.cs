﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_SmallWorld
{
    public interface StrategiePlateau
    {
        TypeCase[,] Carte
        {
            get;
        }

        void creerPlateau(int taille);

    }

}