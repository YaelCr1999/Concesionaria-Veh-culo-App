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
        public DataTable CargarVehiculos(int numSaltar, int numRegist)
        {
            coneccion.Open();
            string queryCargar = "P_cargarVehiculos";
            SqlCommand cmd = new SqlCommand(queryCargar, coneccion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumSaltar",numSaltar);
            cmd.Parameters.AddWithValue("@NumRegist",numRegist);
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
        public int ElimarVehiculo(Vehiculo vehiculo)
        {
            coneccion.Open();
            string consultaEliminar = "P_EliminarVehiculo";
            SqlCommand cmd = new SqlCommand(consultaEliminar, coneccion);
            cmd.Parameters.AddWithValue("@Id", vehiculo.Id);
            cmd.CommandType = CommandType.StoredProcedure;
            int resul = cmd.ExecuteNonQuery();
            coneccion.Close();
            return resul; 
        }

        public DataTable MostrarVehiculoElim()
        {
            coneccion.Open();
            SqlCommand cmd = new SqlCommand("P_ListaElim", coneccion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            d.Fill(table);
            coneccion.Close();
            return table;


        }
        public bool Login(Usuarios usuario)
        {
            coneccion.Open();

            // Usamos un procedimiento almacenado llamado Pr_login para verificar el usuario
            SqlCommand cmd = new SqlCommand("Pr_login", coneccion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Añadir parámetros
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);

            // Asumimos que el procedimiento almacenado devuelve el ID del usuario si es válido, o 0 si no lo es
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());

            coneccion.Close();
            return resultado > 0;
        }

    }
}
