using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList.models
{
    enum Farbe
    {
        black, white, blue, rose, notSpecified
    }
    class Phone
    {

       
        public string Hersteller { get; set; }
        public string Model { get; set; }

        public Farbe Farbe { get; set; }

        public Phone() : this("", "", Farbe.notSpecified) { }

        public Phone(string hersteller, string model, Farbe farbe)
        {
            this.Hersteller = hersteller;
            this.Model = model;
            this.Farbe = farbe;
        }


        public override string ToString()
        {
            return this.Hersteller + " " + this.Model + " " + this.Farbe;
        }


        public override bool Equals(object obj)
        {
            //as versucht obj in den Datentyp umzuwandeln 
            //falls es funktioniert -> ein Instanz von Person wird an die Equals methode übergeben
            //falls es nicht funktioniert ->null wird übergeben
            //es wird keine Exception geworfen
            return Equals(obj as Phone);
        }




        public bool Equals(Phone obj)
        {
            //Parameter prüfen
            if (obj == null)
            {
                return false;
            }
            if ((obj.Hersteller == this.Hersteller) && (obj.Model == this.Model) && (obj.Farbe == this.Farbe))
            {
                return true;
            }

            return false;
        }


        public override int GetHashCode()
        {
            //Startwert ist eine Primzahl
            var hashCode = -1786895991;


            //die 2te Zahl ist ebnefalss eine Primzahl
            //es müssen die gliechen Felder (Firstname,Lastname,Birthdate)
            //wie in equals() verwendet werden

            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Hersteller);
            hashCode = hashCode * -1521134295 +
            EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 +
            Farbe.GetHashCode();

            return hashCode;
        }

    }
}
