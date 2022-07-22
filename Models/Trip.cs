using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI
{
    public class Trip
    {
        public int Id { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string TypeTrip { get; set; }
      
        public string NumberTrip {get; set;}
       
        public string NameDriver { get; set; }
        
        public string PhoneNumberDriver { get; set; }

        public Trip() { }

    }
}
