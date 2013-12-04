using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLibrary;

namespace DatabaseTest
{
    class Program
    {
        /// <summary>
        /// Tato trida slouzi pouze pro otestovani metod, ktere pracuji s databazi.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*
             * Otestovani tridy CategoryTable.
             */
            CategoryTable catTable = new CategoryTable();
            Category cat1, cat2;

            // Vlozeni dvou kategorii
            catTable.InsertCategory((cat1 = new Category("Vystava", 1)));
            catTable.InsertCategory((cat2 = new Category("Autogramiada", 2)));

            // Editace prvni kategorie
            cat1.category_name = "Prednaska";
            catTable.Update(cat1);

            // Vypis vsech kategorii
            List<Category> list = catTable.SelectAll();
            Console.WriteLine("Prehled kategorii:");
            foreach (Category cat in list)
                Console.WriteLine("Name: " + cat.category_name + " Type:" + cat.category_type.ToString());


            // Smazani kategorii
            foreach (Category cat in list)
                catTable.Delete(cat.category_id);



            /*
             * Otestovani tridy ClientTable.
             */
            //ClientTable clientTable = new ClientTable();

            // Vlozeni klienta
            //Client c1 = new Client();
            //c1.client_name = "Pepa";
            //c1.client_surname = "Z depa";
            //c1.client_email = "pepa.zdepa@depo.cz";
            //c1.client_phone = "123456789";
            //c1.client_member_from = DateTime.Now;
            //c1.client_birth_date = DateTime.Now;
            //c1.client_isEmp = false;
            //c1.client_is_active = true;
            //c1.client_login = "pepazdepa";
            //c1.client_pass_hash = "rnfguiNFUI1518";

            //clientTable.Insert(c1);

            // Vypis klientu
            //foreach (Client c in clientTable.SelectAll())
            //{
            //    c1 = c;
            //    Console.WriteLine(c.client_name + " " + c.client_surname + " " + c.client_email);
            //}

            //// Editace udaju
            //c1.client_street = "V depu 123";
            //clientTable.Update(c1);

            // Odstraneni clienta
            //clientTable.Delete(c1.client_id);



            /*
             * Otestovani tridy BorrowingTable
             */
            //BorrowingTable borrTable = new BorrowingTable();

            //Borrowing b = new Borrowing();
            //b.borrowing_from = DateTime.Now;
            //b.borrowing_to = DateTime.Now;
            //b.borrowing_is_returned = false;
            //b.client_id = 7;
            //b.copy_id = 1;

            //borrTable.Insert(b);

            // Vypsani vypujcek
            //foreach (Borrowing borr in borrTable.SelectAll())
            //{
            //    b = borr;
            //    Console.WriteLine(borr.borrowing_id.ToString() + " " + borr.borrowing_to);
            //}

            //// Editace vypujcky
            //b.borrowing_is_returned = true;
            //borrTable.Update(b);

            //// Odstraneni vypujcky
            //borrTable.Delete(b.borrowing_id);

        }
    }
}
