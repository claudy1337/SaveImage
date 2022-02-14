using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace SaveImage.sql
{
    internal class ImageBD
    {
        SQLiteConnection db;
        public ImageBD(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Image>();
        }

        public IEnumerable<Image> GetItems()
        {
            return db.Table<Image>().ToList();
        }

        public Image GetItem(int id)
        {
            return db.Get<Image>(id);
        }

        public int DeleteItem(int id)
        {
            return db.Delete<Image>(id);
        }

        public int SaveItem(Image item)
        {
            if (item.Id != 0)
            {
                db.Update(item);
                return item.Id;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
