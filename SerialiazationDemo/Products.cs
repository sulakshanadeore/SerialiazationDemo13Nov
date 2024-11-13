using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialiazationDemo
{
    [Serializable]
    internal class Products
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int QtyInHand { get; set; }

        int soldQty;
        public int QtySold 
        {
            get 
            { 
                return soldQty; 
            } 
            set 
            { 
            soldQty=value;
            QtyInHand = QtyInHand - soldQty;
            
            } 
        }
    }

}
