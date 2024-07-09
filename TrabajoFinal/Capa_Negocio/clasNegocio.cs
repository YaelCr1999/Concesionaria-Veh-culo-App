using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capza_Datos;
using Capa_Entidad;
using System.Data;

namespace Capa_Negocio
{
    public class clasNegocio
    {
        //Intancia de la clase coneccion
        ConeccionBd conecObj = new ConeccionBd();

        //Metodo para cargar los datos en el datagrid
        public DataTable CargarDato()
        {
            return conecObj.CargarVehiculos();
        }

        //Metodo para poder agregar un nuevo vehiculo a la base de datos
        public void AgregarVehiculo(Vehiculo objVehiculo)
        {
             conecObj.AgregarVehiculo(objVehiculo);
        }
        //Metodo para poder actualizar  un vehiculo de la base de datos
        public int ModificarVehiculo(Vehiculo objVehiculo)
        {
            return conecObj.ModificarVehiculo(objVehiculo);
        }

        //Metodo para poder eliminar un vehiculo dela base de datos
        public int EliminarDato(Vehiculo vehiculoObj)
        {
            return conecObj.ElimarVehiculo(vehiculoObj);
        }





    }
}
