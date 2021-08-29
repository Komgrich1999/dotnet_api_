using Newtonsoft.Json;

namespace KomgrichApi.Models
{
    public class Students
    {
        public long Id {get;set;}
        public string student_id {get; set;}
        public string fullname {get; set;}
        public string degree {get; set;} 

        public long universities_id {get; set;}
    }
}