﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail1_Partie_4.Models
{
    partial class TblEmployee
    {
        public string NomComplet => $"{Nom}, {Prenom}, {Email}";
    }
}
