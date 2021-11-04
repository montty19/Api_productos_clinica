using System.ComponentModel.DataAnnotations;
namespace api_farmacia.Models{
    public class Productoss{
        [Key]
        public int id{get;set;}

        public string nombre {get;set;}

        public string descripcion {get;set;}

        public string precio {get;set;}

        public string existencia {get;set;}

        public string marca {get;set;}

        public string imagen {get;set;}

    }
}