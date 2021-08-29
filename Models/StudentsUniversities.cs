using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KomgrichApi.Models
{
    public class StudentsUniversities
    {
        [Key]
        public long Id {get; set;}
        public long StudentId {get;set;}
        public Students Student {get;set;}

        public long UniversitieId {get;set;}
        public universities universitie {get;set;}

        
    }
}