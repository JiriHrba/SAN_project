using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLibrary;
using System.Security.Cryptography;

namespace Knihovna_SAN.Client
{
    public partial class NewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertClient_Click(object sender, EventArgs e)
        {
            // Vlozeni noveho klienta do systemu
            if (IsValid)
            {

                DatabaseLibrary.Client c = new DatabaseLibrary.Client();

                c.client_name = TxtBoxName.Text;
                c.client_surname = TxtBoxSurname.Text;
                c.client_email = TxtBoxEmail.Text;
                c.client_phone = TxtBoxPhone.Text;

                // Parsovani data narozeni
                string birthDate = TxtBoxBirthDate.Text;
                string[] items = birthDate.Split('/');
                DateTime dateBirth = new DateTime(Int32.Parse(items[2]), Int32.Parse(items[1]), Int32.Parse(items[0]));
                c.client_birth_date = dateBirth;
                c.client_member_from = DateTime.Now;

                // TODO Predelat, pridat clenstvi treba na mesic, nevim... zatim jen tak, aby to fungovalo
                c.client_member_to = DateTime.Now;

                c.client_street = TxtBoxStreet.Text;
                c.client_city = TxtBoxCity.Text;
                c.client_zip = TxtBoxZIP.Text;
                c.client_country = TxtBoxCountry.Text;

                // Pridavame klienta skrze obycejnou stranku, nemuze to byt zamestnanec. Vkladani zamestancu bude asi nekde v nejake administraci.
                c.client_isEmp = false;

                // Pri vytvoreni bude ucet patrne aktivni
                c.client_is_active = true;

                c.client_login = TxtBoxLogin.Text;
                c.client_pass_hash = CalculateHashMD5(TxtBoxPass.Text);

                new DatabaseLibrary.ClientTable().Insert(c);
            }
        }

        /// <summary>
        /// Vraci MD5 hash.
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        private string CalculateHashMD5(string clearText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] tmpSource;
            byte[] tmpHash;

            tmpSource = System.Text.Encoding.UTF8.GetBytes(clearText);
            tmpHash = md5.ComputeHash(tmpSource);

            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in tmpHash)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string hash = s.ToString();
            return hash;
        }

    }
}