using System.Collections.Generic;

namespace KomgrichApi.Models
{
    public class universities
    {
        public long Id {get;set;}
        public string university_name {get; set;}

        public ICollection<StudentsUniversities> StudentsUniversitie {get; set;}
        
    }
}