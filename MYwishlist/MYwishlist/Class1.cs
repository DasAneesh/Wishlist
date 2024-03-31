using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace TEstSQLITE
{
    internal class Program
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;

        static void Main(string[] args)
        {
            try
            {
                connection = new SQLiteConnection("C:\\Users\\User\\Downloads\\MYwishlist\\MYwishlist\\DBwishlist.db; Version=3; FailIfMissing=False");
                connection.Open();
                Console.WriteLine("Connected!");
                command = new SQLiteCommand(connection)
                {
                    CommandText = "SELECT * FROM \"Wishes\";"
                };
                Console.WriteLine("Результат запроса:");
                DataTable data = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(data);
                Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
                foreach (DataRow row in data.Rows)
                {
                    Console.WriteLine($"ID = {row.Field<Int64>("ID")} Productname = {row.Field<string>("Productname")}  Link = {row.Field<string>("Link")} Wishmeter = {row.Field<Int64>("Wishmeter")}  Cost = {row.Field<Int64>("Cost")}");
                }

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }
            Console.Read();
        }
    }
}

namespace MYwishlist
{
    public class Class1
    {



    }
}
