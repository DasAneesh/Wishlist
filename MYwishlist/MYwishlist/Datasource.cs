using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYwishlist
{
    public class Datasource
    {
        public void create(Wish wish)
        {
            SQLiteConnection connection;
            SQLiteCommand command;

            try
            {
                connection = new SQLiteConnection("C:\\Users\\User\\Downloads\\MYwishlist\\MYwishlist\\DBwishlist.db; Version=3; FailIfMissing=False");
                connection.Open();
                Console.WriteLine("Connected!");
                command = new SQLiteCommand(connection)
                {
                    CommandText = "SELECT * FROM \"Wishes\";"
                };
                DataTable data = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(data);
                foreach (DataRow row in data.Rows)
                {
                    Console.WriteLine($"ID = {row.Field<Int64>("ID")} Productname = {row.Field<string>("Productname")}  Link = {row.Field<string>("Link")} Wishmeter = {row.Field<Int64>("Wishmeter")}  Cost = {row.Field<Int64>("Cost")}");
                }

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }

        }
    }
}
