using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;
using System;

namespace Capza_Datos
{
    public class ConeccionBd
    {
        private SqlConnection coneccion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        //Metodo para cargar todos los vehiculos de la basse de datos
        public DataTable CargarVehiculos()
        {
            coneccion.Open();
            string queryCargar = "P_cargarVehiculos";
            SqlCommand cmd = new SqlCommand(queryCargar, coneccion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tablaVehiculos = new DataTable();
            da.Fill(tablaVehiculos);
            coneccion.Close();
            return tablaVehiculos;
        }

        //Metodo para agregar un nuevo vehiculo a la base de datos
        public void AgregarVehiculo(Vehiculo objVehiculo)
        {
            coneccion.Open();
            string queryAgregar = "P_AgregarVehiculo";

            SqlCommand cmd = new SqlCommand(queryAgregar, coneccion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Marca", objVehiculo.Marca);
            cmd.Parameters.AddWithValue("Modelo", objVehiculo.Modelo);
            cmd.Parameters.AddWithValue("Color", objVehiculo.Color);
            cmd.Parameters.AddWithValue("AÑo", objVehiculo.Ano);
            cmd.Parameters.AddWithValue("Matricula", objVehiculo.Matricula);
            cmd.Parameters.AddWithValue("Placa", objVehiculo.Placa);
            cmd.Parameters.AddWithValue("Precio", objVehiculo.Precio);
            cmd.ExecuteNonQuery();
           

        }
        //Metodo para modificar un vehiculo exixtente en la base de datos
        public int ModificarVehiculo(Vehiculo objVehi)
        {
            coneccion.Open();
            string queryModi = "P_actualizarVehiculos";
            SqlCommand cmd = new SqlCommand(queryModi,coneccion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", objVehi.Id);
            cmd.Parameters.AddWithValue("@Marca", objVehi.Marca);
            cmd.Parameters.AddWithValue("@Modelo", objVehi.Modelo);
            cmd.Parameters.AddWithValue("@Color", objVehi.Color);
            cmd.Parameters.AddWithValue("@AÑo", objVehi.Ano);
            cmd.Parameters.AddWithValue("@Matricula", objVehi.Matricula);
            cmd.Parameters.AddWithValue("@Placa", objVehi.Placa);
            cmd.Parameters.AddWithValue("@Precio", objVehi.Precio);
            int numAfec = cmd.ExecuteNonQuery();
            return numAfec;
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
