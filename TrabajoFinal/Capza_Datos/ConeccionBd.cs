using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;

namespace Capza_Datos
{
    public class ConeccionBd
    {
        private SqlConnection coneccion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        //Metodo para cargar todos los vehiculos de la basse de datos
        public DataTable CargarVehiculos()
        {
            coneccion.Open();
            string queryCargar = "SELECT * FROM Vehiculo";
            SqlCommand cmd = new SqlCommand(queryCargar, coneccion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tablaVehiculos = new DataTable();
            da.Fill(tablaVehiculos);
            coneccion.Close();
            return tablaVehiculos;
        }

        //Metodo para agregar un nuevo vehiculo a la base de datos
        public DataTable AgregarVehiculo(Vehiculo objVehiculo)
        {
            coneccion.Open();
            string queryAgregar = "INSERT INTO Vehiculo VALUES (@Marca, @Modelo, @Color, @AÑo,@Matricula,@Placa, @Precio)";

            SqlCommand cmd = new SqlCommand(queryAgregar, coneccion);
            //cmd.Parameters.AddWithValue("Id",objVehiculo.Id);
            cmd.Parameters.AddWithValue("Marca", objVehiculo.Marca);
            cmd.Parameters.AddWithValue("Modelo", objVehiculo.Modelo);
            cmd.Parameters.AddWithValue("Color", objVehiculo.Color);
            cmd.Parameters.AddWithValue("AÑo", objVehiculo.Ano);
            cmd.Parameters.AddWithValue("Matricula", objVehiculo.Matricula);
            cmd.Parameters.AddWithValue("Placa", objVehiculo.Placa);
            cmd.Parameters.AddWithValue("Precio", objVehiculo.Precio);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tablaVehiculo = new DataTable();
            da.Fill(tablaVehiculo);
            coneccion.Close();
            return tablaVehiculo;

        }
        //Metodo para modificar un vehiculo exixtente en la base de datos
        public DataTable ModificarVehiculo(Vehiculo objVehi)
        {
            coneccion.Open();
            string queryModi = "UPDATE Vehiculo SET Marca = @Marca, Modelo = @Modelo, Color = @Color, AÑo = @AÑo, Matricula = @Matricula, Placa = @Placa,  Precio = @Precio WHERE Id = @Id"; 
            SqlCommand cmd = new SqlCommand(queryModi,coneccion);
            cmd.Parameters.AddWithValue("@Id", objVehi.Id);
            cmd.Parameters.AddWithValue("@Marca", objVehi.Marca);
            cmd.Parameters.AddWithValue("@Modelo", objVehi.Modelo);
            cmd.Parameters.AddWithValue("@Color", objVehi.Color);
            cmd.Parameters.AddWithValue("@AÑo", objVehi.Ano);
            cmd.Parameters.AddWithValue("@Matricula", objVehi.Matricula);
            cmd.Parameters.AddWithValue("@Placa", objVehi.Placa);
            cmd.Parameters.AddWithValue("@Precio", objVehi.Precio);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tablaVehiculo = new DataTable();
            da.Fill(tablaVehiculo);
            coneccion.Close();
            return tablaVehiculo;

        }

        //Metodo para eliminar un vehiculo de la base de datos
        public DataTable ElimarVehiculo(Vehiculo vehiculo)
        {
            coneccion.Open();
            string consultaEliminar = "DELETE FROM Vehiculo WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(consultaEliminar, coneccion);
            cmd.Parameters.AddWithValue("Id", vehiculo.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable registroEliminado = new DataTable();
            da.Fill(registroEliminado);
            coneccion.Close();
            return registroEliminado;
        }



    }
}
