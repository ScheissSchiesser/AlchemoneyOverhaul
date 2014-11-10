using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AlchemoneyOverhaul
{
    class BuildDB
    {        
        static void CreateDB()
        {
            bool reorder = false;

            if (reorder)
            {
                reorderDB();
            }
            else
            {
                buildDB();
            }
        }

        public static DataTable ParseCSV(string path)
        {
            if (!File.Exists(path))
                return null;

            string full = Path.GetFullPath(path);
            string file = Path.GetFileName(full);
            string dir = Path.GetDirectoryName(full);

            //create the "database" connection string 
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;"
            + "Data Source=\"" + dir + "\\\";"
            + "Extended Properties=\"text;HDR=No;FMT=Delimited\"";

            //create the database query
            string query = "SELECT * FROM " + file;

            //create a DataTable to hold the query results
            DataTable dTbl = new DataTable();

            //create an OleDbDataAdapter to execute the query
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connString);

            dAdapter.Fill(dTbl);

            //try
            //{
            //    //fill the DataTable
            //    dAdapter.Fill(dTable);
            //}
            //catch (InvalidOperationException /*e*/)
            //{}

            dAdapter.Dispose();

            return dTbl;
        }

        public static void buildDB()
        {
            SqlConnection con;
            DataTable dt1;
            SqlDataAdapter da;

            // Create connection string and open connection
            con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Eric\\Desktop\\Alchemoney Project\\AlchemoneyOverhaul\\AlchemoneyOverhaul\\dbTestCSV.mdf;Integrated Security=True";
            con.Open();

            // Delete all the current rows, reset identity fields
            string sqlDelete = "DELETE FROM Potions3";
            SqlCommand cmdDelete = new SqlCommand(sqlDelete, con);
            cmdDelete.ExecuteNonQuery();
            con.Close();

            con.Open();
            
            // Select all columns from empty table
            string sql = "SELECT * FROM Potions3";

            // Create new data adapter 
            da = new SqlDataAdapter(sql, con);

            SqlCommandBuilder cb;
            cb = new SqlCommandBuilder(da);

            dt1 = ParseCSV(@"resources\skyrimPotions.csv");

            dt1.Columns[0].ColumnName = "Potion_ID";
            dt1.Columns[1].ColumnName = "Ingredient1";
            dt1.Columns[2].ColumnName = "Ingredient2";
            dt1.Columns[3].ColumnName = "Ingredient3";
            dt1.Columns[4].ColumnName = "Effect1";
            dt1.Columns[5].ColumnName = "Effect2";
            dt1.Columns[6].ColumnName = "Effect3";
            dt1.Columns[7].ColumnName = "Effect4";
            dt1.Columns[8].ColumnName = "Effect5";
            dt1.Columns[9].ColumnName = "Value";

            DataSet ds2 = new DataSet();

            da.Fill(ds2);

            foreach (DataRow dRow in dt1.Rows)
            {
                DataRow dsRow = ds2.Tables["Table"].NewRow();
                dsRow.ItemArray = dRow.ItemArray;
                ds2.Tables["Table"].Rows.Add(dsRow);
            }

            da.Update(ds2, "Table");

            con.Close();
            da.Dispose();

            //MessageBox.Show("sql server table data updated!");
        }

        public static void reorderDB()
        {
            SqlConnection con;
            SqlDataAdapter da;
            SqlDataAdapter daOrdered;
            DataSet ds2 = new DataSet();


            con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\dbTestCSV.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            con.Open();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM Potions3");
            sql.Append(" ORDER BY Value DESC");

            StringBuilder sqlOrdered = new StringBuilder();
            sqlOrdered.Append("SELECT * FROM Potions3_Ordered");

            da = new SqlDataAdapter(sql.ToString(), con);

            daOrdered = new SqlDataAdapter(sqlOrdered.ToString(), con);

            SqlCommandBuilder cb;
            cb = new SqlCommandBuilder(da);

            SqlCommandBuilder cbOrdered = new SqlCommandBuilder(daOrdered);

            da.Fill(ds2);

            DataSet dsOrdered = ds2.Clone();

            foreach (DataRow dsRow in ds2.Tables[0].Rows)
            {
                DataRow dsOrderedRow = dsOrdered.Tables[0].NewRow();
                dsOrderedRow.ItemArray = dsRow.ItemArray;
                dsOrdered.Tables[0].Rows.Add(dsOrderedRow);
            }

            daOrdered.Update(dsOrdered, "Table");

            con.Close();
            da.Dispose();
            daOrdered.Dispose();

            MessageBox.Show("SQL server table data updated!");
        }
    }
}
