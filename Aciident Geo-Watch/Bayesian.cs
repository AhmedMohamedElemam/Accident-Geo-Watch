using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Aciident_Geo_Watch
{
    class Bayesian
    {

        public static String bayesian(String news)
        {
            double maxx = 0.0;
            int maxn = 0;
            String label = "";
            Stemmer stemmer = new Stemmer();
            ClassLabel[] cl1 = new ClassLabel[5];
            double[] resClass = new double[5];

            string query;
            string query1 = "select count(*) from DataSet";
            object total;
            object total1;

            double c;
            double cc;

            SqlCommand command;
            SqlConnection conn;

            double[] p1;

            conn = new SqlConnection(" Server=.\\SQLEXPRESS;Database=GP_1;Trusted_Connection=True;MultipleActiveResultSets=true");
            conn.Open();

            cl1[0] = new ClassLabel();
        
            cl1[1] = new ClassLabel();
            cl1[2] = new ClassLabel();
            cl1[3] = new ClassLabel();
            cl1[4] = new ClassLabel();

            cl1[0].Set_Class_label(1, "accident", 0, 0);
            cl1[1].Set_Class_label(2, "murder", 0, 0);
            cl1[2].Set_Class_label(3, "fires", 0, 0);
            cl1[3].Set_Class_label(4, "theft", 0, 0);
            cl1[4].Set_Class_label(5, "others", 0, 0);

            p1 = new double[5];
            for (int i = 0; i < 5; i++)
            {
                p1[i] = 1;
            }

            for (int l = 0; l < 5; l++)
            {
                resClass[l] = 1.0;
            }
            for (int j = 0; j < 5; j++)
            {
                query = "select count('label') from DataSet where label='" + cl1[j].name + "'";

                command = new SqlCommand(query, conn);
                total = command.ExecuteScalar();
                command = new SqlCommand(query1, conn);
                total1 = command.ExecuteScalar();

                c = System.Convert.ToInt32(total);
                cl1[j].update_length(System.Convert.ToInt32(total));

                cc = System.Convert.ToInt32(total1);
                cl1[j].update_prob(c / cc);

            }
            String[] temp = news.Split(' ');

            Term[] at1 = new Term[temp.Count()];

            for (int i = 0; i < temp.Count(); i++)
            {
                at1[i] = new Term();
                try
                {
                    temp[i] = stemmer.Stem(temp[i]);
                    at1[i].Set_term(temp[i], i + 1, p1);
                }
                catch
                {
                    at1[i].Set_term(temp[i], i + 1, p1);

                }

            }


            for (int i = 0; i < temp.Count(); i++)
            {
                try
                {
                    for (int k = 0; k < 5; k++)
                    {
                        query = "select " + at1[i].name + " from DataSet_1 where label='" + cl1[k].name + "' ";
                        command = new SqlCommand(query, conn);
                        total = command.ExecuteScalar();
                        c = System.Convert.ToDouble(total);
                        p1[k] = c;
                    }
                    at1[i].update_prob(p1);
                    for (int k = 0; k < 5; k++)
                    {
                        resClass[k] = at1[i].prob[k] * resClass[k];
                    }
                }
                catch
                {

                }
            }
                for (int k = 0; k < 5; k++)
                {
                    resClass[k] = resClass[k] * cl1[k].prob;
                    if (resClass[k] > maxx)
                    {
                        maxx = resClass[k];
                        maxn = k;
                    }
                }
                conn.Close();

                label = cl1[maxn].name;



                return label;

        }
    }
}
