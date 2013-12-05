using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLibrary
{
    public class ActionReservation
    {
        public int act_reservation_id { get; set; }
        public DateTime act_reservation_date{ get; set; }
        public Boolean act_reservation_client_came { get; set; }
        public int action_id { get; set; }
        public int client_id { get; set; }

        public ActionReservation() { }

        /// <summary>
        /// Vytvori rezervaci. Datum bude nastaveno na aktualni a flag, zda klient prisel, bude nastaven na false. Az prijde, zmeni se to na true.
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="clientId"></param>
        public ActionReservation(int actionId, int clientId)
        {
            this.action_id = actionId;
            this.client_id = clientId;

            // Zatim jeste klient neprisel. Az prijde, provede se zmena.
            act_reservation_client_came = false;

            // Rezervace se provadi prave ted
            act_reservation_date = DateTime.Now;

        }
    }
}
