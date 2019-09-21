using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortoTurismo.Data.Models
{
    public class Passenger
    {
        public Passenger()
        {

        }

        public Passenger(string name, string document, string telephone)
        {
            this.Name = name;
            this.Document = document.Replace("-", String.Empty).Replace(".", String.Empty);
            this.Telephone = telephone.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Telephone { get; private set; }

        public string PassengerDetails
        {
            get
            {
                
                return string.Format("RG:{0}, Telefone:{1}", Convert.ToUInt64(Document).ToString(@"00\.000\.000\-0"), Convert.ToUInt64(Telephone).ToString(@"\(00\)\ 0\ 0000\-0000"));
            }
           
        }

    }
}
