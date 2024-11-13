using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;//For xml serialization
using System.Text.Json;//For json Serialization
using System.Text;
using System.Threading.Tasks;

namespace SerialiazationDemo
{
    internal class Program
    {
        //Binary,XML,Json
        static void Main(string[] args)
        {
            //BinarySerializationAndDeSerialization();
            // XMLSerializationAndDeserialization();
            //Products p = new Products();
            //p.ProductID = 1;
            //p.ProductName = "Snacks";
            //p.Price = 50;
            //p.QtyInHand = 100;
            //p.QtySold = 10;
            //string json = JsonSerializer.Serialize(p);
            //FileStream   fs=new FileStream("productDataJson.json",FileMode.Create,FileAccess.Write);    
            //StreamWriter sw=new StreamWriter(fs);
            //sw.Write(json);
            //sw.Flush();
            //sw.Close();
            //sw.Dispose();
            //fs.Close();
            //fs.Dispose();



            FileStream  fs=new FileStream("productDataJson.json",FileMode.Open,FileAccess.Read);    
            StreamReader sr = new StreamReader(fs);
            Products p1=JsonSerializer.Deserialize<Products>(fs);
            Console.WriteLine($"ProductID= {p1.ProductID}");
            Console.WriteLine($"Name={p1.ProductName}");
            Console.WriteLine($"Price={p1.Price}");
            //Console.WriteLine($"Remaining Qty={p1.QtyInHand}");
            Console.WriteLine($"Qty Sold={p1.QtySold}");
            sr.Close();
            sr.Dispose();
            fs.Close();
            fs.Dispose();


            Console.ReadLine();
        }

        private static void XMLSerializationAndDeserialization()
        {
            Products p = new Products();
            p.ProductID = 1;
            p.ProductName = "Snacks";
            p.Price = 50;
            p.QtyInHand = 100;
            p.QtySold = 10;
            FileStream fs = new FileStream("productData.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer s = new XmlSerializer(typeof(Products));
            s.Serialize(fs, p);
            fs.Close();
            fs.Dispose();


            FileStream fs1 = new FileStream("productData.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer s1 = new XmlSerializer(typeof(Products));
            Products p1 = (Products)s1.Deserialize(fs1);
            Console.WriteLine($"ProductID= {p1.ProductID}");
            Console.WriteLine($"Name={p1.ProductName}");
            Console.WriteLine($"Price={p1.Price}");
            Console.WriteLine($"Remaining Qty={p1.QtyInHand}");
            Console.WriteLine($"Qty Sold={p1.QtySold}");
            fs1.Close();
            fs1.Dispose();
        }

        private static void BinarySerializationAndDeSerialization()
        {
            Products p = new Products();
            p.ProductID = 1;
            p.ProductName = "Snacks";
            p.Price = 50;
            p.QtyInHand = 100;
            p.QtySold = 10;


            FileStream fs = new FileStream("ProductReport.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, p);//Serialize--write, what to write --p, where to write--
            fs.Close();
            fs.Dispose();

            FileStream fs2 = new FileStream("ProductReport.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf2 = new BinaryFormatter();
            Products productref = (Products)bf.Deserialize(fs2);//Deserialize--read
            Console.WriteLine($"ProductID= {productref.ProductID}");
            Console.WriteLine($"Name={productref.ProductName}");
            Console.WriteLine($"Price={productref.Price}");
            Console.WriteLine($"Remaining Qty={productref.QtyInHand}");
            Console.WriteLine($"Qty Sold={productref.QtySold}");

            fs2.Close();
            fs2.Dispose();


            p = new Products();
            p.ProductID = 1;
            p.ProductName = "Snacks";
            p.Price = 50;
            p.QtyInHand = 90;
            p.QtySold = 10;


            Console.WriteLine("------------------------------------------------");
            //FileStream fs1 = new FileStream("ProductReport1.dat", FileMode.Create, FileAccess.Write);
            //BinaryFormatter bf1 = new BinaryFormatter();
            //bf.Serialize(fs1, p);//Serialize--write, what to write --p, where to write--
            //fs1.Close();
            //fs1.Dispose();




            //FileStream fs3 = new FileStream("ProductReport1.dat", FileMode.Open, FileAccess.Read);
            //BinaryFormatter bf3 = new BinaryFormatter();
            //productref = (Products)bf.Deserialize(fs3);//Deserialize--read
            //Console.WriteLine($"ProductID= {productref.ProductID}");
            //Console.WriteLine($"Name={productref.ProductName}");
            //Console.WriteLine($"Price={productref.Price}");
            //Console.WriteLine($"Remaining Qty={productref.QtyInHand}");
            //Console.WriteLine($"Qty Sold={productref.QtySold}");
            //fs3.Close();
            //fs3.Dispose();
        }
    }
}
