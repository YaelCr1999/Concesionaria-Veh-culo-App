namespace Capa_Entidad
{
    //Clase que no va a representar un vehiculo
    public class Vehiculo
    {
        //Prpiedades del vehiculp
        public int Id {  get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public  string Color { get; set; }
        public  int Ano {  get; set; }
        public  string Matricula {  get; set; }
        public  string Placa { get; set; }
        public  decimal Precio { get; set; }

        
        public Vehiculo(string Marca, string Modelo, string Color, int Ano, string Matricula, string Placa, decimal Precio)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Color = Color;
            this.Ano = Ano;
            this.Matricula = Matricula;
            this.Placa = Placa;
            this.Precio = Precio;
        }
        public Vehiculo()
        {

        }
        public Vehiculo(int Id)
        {
            this.Id = Id;
        }
    }
}
