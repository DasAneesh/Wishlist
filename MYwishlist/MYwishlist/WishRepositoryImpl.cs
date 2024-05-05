using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MYwishlist.Repository
{

    public interface IWishRepository
    {
        List<Wish> Read();
        List<Wish> ReadById(int id);

        void Update(Wish wish);
        void Delete(int id);
        void Create(Wish wish);
    }

    //D:\\MyWishlist\\Wishlist\\MYwishlist\\MYwishlist\\wishlistDB.db
    public class WishRepositoryImpl : IWishRepository
    {
        private const string ConnectionString = "DataSource = C:\\Users\\11\\Desktop\\repos\\Wishlist\\MYwishlist\\MYwishlist\\wishlistDB.db; Version=3; FailIfMissing=False";

        public void Create(Wish wish)
        {

            try
            {
                string sql = $"INSERT INTO \"Wishes\" VALUES(NULL, \"{wish.Productname}\", \"{wish.Link}\", {wish.Wishmeter}, {wish.Cost})";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }

        }


        public void Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM \"Wishes\" WHERE \"ID\" = {id}";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }


        }


        public void Update(Wish wish)
        {
            try
            {
                string sql = $"UPDATE \"Wishes\" SET \"Productname\" = \"{wish.Productname}\",\"Link\" = \"{wish.Link}\", \"Wishmeter\" = {wish.Wishmeter},\"Cost\" = {wish.Cost} WHERE \"ID\" = {wish.ID};";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }

        }


        public List<Wish> Read()
        {
            List<Wish> wishes = new List<Wish>();
            try
            {
                string sql = "SELECT * FROM \"Wishes\";";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int index = 0;
                                int id = rdr.GetInt32(index++);
                                string Productname = rdr.GetString(index++);
                                string Link = rdr.GetString(index++);
                                int Wishmeter = rdr.GetInt32(index++);
                                int Cost = rdr.GetInt32(index++);
                                wishes.Add(new Wish(id,Productname,Link,Wishmeter,Cost));
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }
            return wishes;
        }

        public List<Wish> ReadById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
