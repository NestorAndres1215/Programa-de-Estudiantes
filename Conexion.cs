﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Estudiantes
{
    class Conexion
    {
        public static SqlConnection Conectar() {
            SqlConnection cn = new SqlConnection("SERVER=(local);DATABASE=REGISTRO;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
