using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlchemoneyOverhaul
{
    class QueryList
    {
        private List<int> querylistamounts = new List<int>();
        private List<string> querylistingredients = new List<string>();

        public QueryList(DataGridView tblQuery)
        {
            List<string> queryListIngredientsTemp = new List<string>();
            List<int> queryListAmountsTemp = new List<int>();

            foreach (DataGridViewRow row in tblQuery.Rows)
            {
                string s = row.Cells[1].Value.ToString();
                int a = Convert.ToInt32(s);
                if (a > 0)
                {
                    string ing = row.Cells[0].Value.ToString();
                    queryListAmountsTemp.Add(a);
                    queryListIngredientsTemp.Add(ing);
                }
            }

            querylistamounts = queryListAmountsTemp;
            querylistingredients = queryListIngredientsTemp;
        }

        public void updateQueryList()
        {
            List<string> queryListIngredientsTemp = new List<string>();
            List<int> queryListAmountsTemp = new List<int>();

            for (int ingAmtIndex = 0; ingAmtIndex < querylistamounts.Count; ingAmtIndex++)
            {
                int ingAmt = querylistamounts[ingAmtIndex];
                if (ingAmt > 0)
                {
                    queryListIngredientsTemp.Add(querylistingredients[ingAmtIndex]);
                    queryListAmountsTemp.Add(ingAmt);
                }
            }

            querylistamounts = queryListAmountsTemp;
            querylistingredients = queryListIngredientsTemp;

            //int index = value.BinarySearch(0);
            //value.RemoveAt(index);
            //querylistingredients.RemoveAt(index);
        }


        public List<string> IngredientNames
        {
            get
            {
                return querylistingredients;
            }
            set
            {
                querylistingredients = value;
            }
        }

        public List<int> IngredientAmounts
        {
            get
            {
                return querylistamounts;
            }
            set
            {
                querylistamounts = value;
            }
        }
    }
}
