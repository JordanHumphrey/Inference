﻿using SQLite;
using System;
using System.IO;

namespace Inference.ViewModel
{
    class DatabaseHelper
    {
        public static string dbFile = Path.Combine(Environment.CurrentDirectory, "reportsDb.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberofRows = conn.Insert(item);
                if (numberofRows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberOfRows = conn.Update(item);
                if (numberOfRows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberOfRows = conn.Delete(item);
                if (numberOfRows > 0)
                    result = true;
            }

            return result;
        }
    }
}
