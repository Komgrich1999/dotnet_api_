using System.Collections.Generic;

namespace KomgrichApi.Models
{
    public class Students
    {
        public long Id {get;set;}
        public string student_id {get; set;}
        public string fullname {get; set;}
        public string degree {get; set;} 

        
        public ICollection<universities> universitie {get; set;}
        
       
    }
}