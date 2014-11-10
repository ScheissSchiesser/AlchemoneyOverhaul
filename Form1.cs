using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using AlchemoneyOverhaul.Properties;

namespace AlchemoneyOverhaul
{
    public partial class AlchemoneyOverhaul : Form
    {
        QueryList qlist;
        DataTable foundPotions;
        DataTable ingredientsQueryTable;
        AppDomain currentDomain = AppDomain.CurrentDomain;
        string ingredientsFile = @"resources\ingredients.csv";
       
        // Make the connection string relative to the working directory
        //string exec1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //string path = (System.IO.Path.GetDirectoryName(exec1));
        //currentDomain.SetData("DataDirectory", path);
        
        string dbConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\dbTestCSV.mdf;Integrated Security=True";
        public AlchemoneyOverhaul()
        {
            InitializeComponent();
        }
        
        private void AlchemoneyOverhaul_Load(object sender, EventArgs e)
        {
            
            ingredientsQueryTable = BuildDB.ParseCSV(ingredientsFile);
            ingredientsQueryTable.Columns[0].ColumnName = "Ingredient";
            ingredientsQueryTable.Columns[1].ColumnName = "Amount";

            tblQuery.DataSource = ingredientsQueryTable;

            qlist = new QueryList(tblQuery);

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            int a = Convert.ToInt32(txtNumPots.Text);
            foundPotions = findTopMatches(a);
            dataGridView1.DataSource = foundPotions;
            stopwatch1.Stop();
            lblCompTime.Text="Computation Time: " + stopwatch1.Elapsed.TotalSeconds.ToString();
        }
                
        private DataTable findMatches(int numToFind)
        {
            DataTable matchesTable = new DataTable("Table1");
            SqlConnection con = new SqlConnection(dbConnectionString);

            matchesTable.Columns.Add("Potion ID");
            matchesTable.Columns.Add("Ingredient 1");
            matchesTable.Columns.Add("Ingredient 2");
            matchesTable.Columns.Add("Ingredient 3");
            matchesTable.Columns.Add("Effect 1");
            matchesTable.Columns.Add("Effect 2");
            matchesTable.Columns.Add("Effect 3");
            matchesTable.Columns.Add("Effect 4");
            matchesTable.Columns.Add("Effect 5");
            matchesTable.Columns.Add("Value");

            DataRow dRow;

            SqlCommand cmd = buildSqlString(qlist.IngredientNames, con);

            try
            {
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    int count = 1;

                    while (dr.Read() & count <= numToFind)
                    {
                        dRow = matchesTable.NewRow();

                        dRow[0] = Convert.ToInt32(dr[0].ToString());
                        dRow[1] = dr[1].ToString();
                        dRow[2] = dr[2].ToString();
                        dRow[3] = dr[3].ToString();
                        dRow[4] = dr[4].ToString();
                        dRow[5] = dr[5].ToString();
                        dRow[6] = dr[6].ToString();
                        dRow[7] = dr[7].ToString();
                        dRow[8] = dr[8].ToString();
                        dRow[9] = Convert.ToInt32(dr[9].ToString());

                        matchesTable.Rows.Add(dRow);

                        count++;
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                con.Close();
            }

            return matchesTable;

        }

        private DataTable findTopMatches(int numToFind)
        {
            DataTable matchesTable = new DataTable("Table1");
            SqlConnection con = new SqlConnection(dbConnectionString);

            matchesTable.Columns.Add("Potion ID");
            matchesTable.Columns.Add("Ingredient 1");
            matchesTable.Columns.Add("Ingredient 2");
            matchesTable.Columns.Add("Ingredient 3");
            matchesTable.Columns.Add("Effect 1");
            matchesTable.Columns.Add("Effect 2");
            matchesTable.Columns.Add("Effect 3");
            matchesTable.Columns.Add("Effect 4");
            matchesTable.Columns.Add("Effect 5");
            matchesTable.Columns.Add("Value");

            DataRow dRow;
            QueryList qlistTemp = new QueryList(tblQuery);

            for (int j = 0; j < numToFind; j++)
            {                
                try
                {
                    SqlCommand cmd = buildSqlString(qlistTemp.IngredientNames, con);
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        dRow = matchesTable.NewRow();

                        dRow[0] = Convert.ToInt32(dr[0].ToString());
                        dRow[1] = dr[1].ToString();
                        dRow[2] = dr[2].ToString();
                        dRow[3] = dr[3].ToString();
                        dRow[4] = dr[4].ToString();
                        dRow[5] = dr[5].ToString();
                        dRow[6] = dr[6].ToString();
                        dRow[7] = dr[7].ToString();
                        dRow[8] = dr[8].ToString();
                        dRow[9] = Convert.ToInt32(dr[9].ToString());

                        matchesTable.Rows.Add(dRow);

                        for (int k = 1; k <= 3; k++)
                        {
                            int index1 = qlistTemp.IngredientNames.BinarySearch(dRow[k].ToString());
                            qlistTemp.IngredientAmounts[index1]--;
                        }
                        qlistTemp.updateQueryList();
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
                finally
                {
                    con.Close();
                }
            }
            
            return matchesTable;
        }
        
        static SqlCommand buildSqlString(List<string> components, SqlConnection con)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("(");

            foreach (string s in components)
            {
                string s2 = s.Replace("'", "''");
                string stemp = "'" + s2 + "'" + ",";
                sb1.Append(stemp);
            }

            int start = sb1.ToString().Length - 2;

            sb1.Replace(",", ")", start, 2);

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT [Potion_ID], [Ingredient1], [Ingredient2], [Ingredient3], [Effect1], [Effect2], [Effect3], [Effect4], [Effect5], [Value] ");
            sb.Append("FROM Potions3");
            sb.Append(" WHERE [Ingredient1] IN");
            sb.Append(sb1.ToString());
            sb.Append(" AND [Ingredient2] IN");
            sb.Append(sb1.ToString());
            sb.Append(" AND [Ingredient3] IN ");
            sb.Append(sb1.ToString());
            sb.Append(" ORDER BY Value DESC");

            SqlCommand cmd = new SqlCommand(sb.ToString(), con);

            return cmd;
        }

        private void btnBuildDB_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            progressBar1.Value = 50;

            BuildDB.buildDB();

            progressBar1.Value = 100;
        }

        private void tblQuery_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            qlist = new QueryList(tblQuery);
        }

        private void btnBrewTop_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow topPot = foundPotions.Rows[0];
                brewPotion(topPot);
                foundPotions.Rows[0].Delete();
                dataGridView1.DataSource = foundPotions;
                tblQuery.DataSource = ingredientsQueryTable;
            }
            catch
            {
                MessageBox.Show("No potion to brew! Click \"Find!\"");
            }
        }

        private void AlchemoneyOverhaul_Resize(object sender, EventArgs e)
        {

        }

        private void tblQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void brewPotion(DataRow potion)
        {
            DataRow foundRow;
            string filter;
            int amount;
            string ingredient;
            for (int i = 1; i <= 3; i++)
            {
                ingredient = potion.Field<string>(i).Replace("'", "''");
                filter = "Ingredient = '" + ingredient + "'";
                foundRow = ingredientsQueryTable.Select(filter)[0];
                amount = foundRow.Field<int>("Amount");
                amount--;
                foundRow.SetField<int>("Amount", amount);
            }
        }
    }
}