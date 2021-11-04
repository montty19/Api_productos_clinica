using Microsoft.EntityFrameworkCore;
namespace api_farmacia.Models{
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base(options){}

        public DbSet<Productoss> Productoss {get;set;}
    }    class Conectar{
        private const string cadenaConexion = "server=11.10.2.75;port=3306;database=db_clinica;userid=PP1;pwd=123456789";
        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion (constructor.Options);
            return cn;
        }
    }
}