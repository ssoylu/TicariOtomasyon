﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=OMERSARP\SQLEXPRESS;Initial Catalog=Dbo_Ticariotomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }

    }
}