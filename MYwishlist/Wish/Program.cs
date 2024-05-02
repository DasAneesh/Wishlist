using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MYwishlist.Repository;

namespace TEstSQLITE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IWishRepository rep = new WishRepositoryImpl();

            List<Wish> Tmp = rep.Read();

            Wish firstwish = new Wish(2, "scooter", "g", 3, 25000);





            Console.WriteLine("READ");
            foreach (Wish w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.ID) + " " + w.Productname + " " + w.Link + " " + w.Wishmeter + " " + w.Cost);
            }


            rep.Create(firstwish);
            Tmp = rep.Read();

            firstwish = Tmp.Last();
            
            Console.WriteLine("CREATE scooter ");
            foreach (Wish w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.ID) + " " + w.Productname + " " + w.Link + " " + w.Wishmeter + " " + w.Cost);
            }

            firstwish.Cost = 137137137;
            firstwish.Productname = "new line";
            firstwish.Wishmeter=2;
            firstwish.Link = "https//scooterstver.com"; 
            rep.Update(firstwish);
            Tmp = rep.Read();
            Console.WriteLine("Updated DB");
            foreach (Wish w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.ID) + " " + w.Productname + " " + w.Link + " " + w.Wishmeter + " " + w.Cost);
            }

            rep.Delete(firstwish.ID);
            Tmp = rep.Read();
            Console.WriteLine($"deleted colomn where id = {firstwish.ID} ");
            foreach (Wish w in Tmp)
            {
                Console.WriteLine(Convert.ToString(w.ID) + " " + w.Productname + " " + w.Link + " " + w.Wishmeter + " " + w.Cost);
            }


            //try
            //{
            //    connection = new SQLiteConnection("DataSource = C:\\Users\\User\\Downloads\\Wishlist-main\\Wishlist-main\\MYwishlist\\MYwishlist\\wishlistDB.db; Version=3; FailIfMissing=False");

            //    connection.Open();
            //    Console.WriteLine("Connected!");
            //    command = new SQLiteCommand(connection)
            //    {
            //        CommandText = "SELECT * FROM \'Wishes\';"
            //    };
            //    Console.WriteLine("Результат запроса:");
            //    DataTable data = new DataTable();
            //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            //    adapter.Fill(data);
            //    Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
            //    foreach (DataRow row in data.Rows)
            //    {
            //        Console.WriteLine($"ID = {row.Field<Int64>("ID")} Productname = {row.Field<string>("Productname")} Link = {row.Field<string>("Link")} Wishmeter = {row.Field<Int64>("Wishmeter")} Cost = {row.Field<Int64>("Cost")}");
            //    }

            //}
            //catch (SQLiteException ex)
            //{
            //    Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            //}
            //Console.Read();

            Console.ReadKey();
        }
    }
}
