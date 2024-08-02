using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace TrabajoFinal
{
    public partial class ConcesionarioVehiculo : Form
    {
        int paginaSaltar = 1;
        int paginaSiguiente = 5; 
        public ConcesionarioVehiculo()
        {
            InitializeComponent();
            CargarDato();
        }

        //Evento que se utiliza para poder cargar los datos en el DateGridView al cargar el formulario
        private void ConcesionarioVehiculo_Load(object sender, EventArgs e)
        {
            CargarRegistros();
            
        }
        //Metodo privado que se utiliza para poder cargar los registros  de vehiculos  en el DateGridView
        private void CargarRegistros()
        {
            clasNegocio CargarDatos = new clasNegocio();
            dgv_RegistrosVehiuculos.DataSource = CargarDatos.CargarDato(paginaSaltar,paginaSiguiente);
        }
         
        //Este evento se utliza para agregar un nuevo Vehiculo a la base de datos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string color = txtColor.Text;
            string ano = txtAno.Text;
            string matricula = txtMatricula.Text;
            string placa = txtPlaca.Text;
            string precio = txtPrecio.Text;

            if (marca == "" || modelo == ""|| color == "" || ano == ""|| matricula == "" ||placa == "" || precio == "" )
            {
                MessageBox.Show("Debes llenar todos los campos ","Informe" ,MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

            } else
            {

                Vehiculo vehiculoObj = new Vehiculo(); 
                vehiculoObj.Marca = marca;
                vehiculoObj.Modelo = modelo;
                vehiculoObj.Color = color;
                vehiculoObj.Ano = int.Parse(ano);
                vehiculoObj.Matricula = matricula;
                vehiculoObj.Placa = placa;
                vehiculoObj.Precio =decimal.Parse(precio);
                clasNegocio clas = new clasNegocio();
                clas.AgregarVehiculo(vehiculoObj);
                MessageBox.Show("Se agrego correctamente");
                CargarRegistros();
                LimpiarCampos();

            }

        }
        //Este metodo se utiliza para limpiar los campos
        private void LimpiarCampos()
        {
             txtId.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            txtAno.Text = "";
            txtMatricula.Text = "";
            txtPlaca.Text = "";
            txtPrecio.Text = "";
        }
        //Este evento del datagrid se utiliza para poder mostrar los registros del vehiculo al cell seleccionado
        private void dgv_RegistrosVehiuculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;


            if (indice == -1 || dgv_RegistrosVehiuculos.SelectedCells[0].Value.ToString() == "")
            {
                MessageBox.Show("Selecciona un campo valido","Importante");
            }
            else
            {
                txtId.Text = dgv_RegistrosVehiuculos.SelectedCells[0].Value.ToString();
                txtMarca.Text = dgv_RegistrosVehiuculos.SelectedCells[1].Value.ToString();
                txtModelo.Text = dgv_RegistrosVehiuculos.SelectedCells[2].Value.ToString();
                txtColor.Text = dgv_RegistrosVehiuculos.SelectedCells[3].Value.ToString();
                txtAno.Text = dgv_RegistrosVehiuculos.SelectedCells[4].Value.ToString();
                txtMatricula.Text = dgv_RegistrosVehiuculos.SelectedCells[5].Value.ToString();
                txtPlaca.Text = dgv_RegistrosVehiuculos.SelectedCells[6].Value.ToString();
                txtPrecio.Text = dgv_RegistrosVehiuculos.SelectedCells[7].Value.ToString();
                btnAgregar.Enabled = true;
            }
        }
        //Este evento se utliza para modificar Vehiculo ya registrado en la base de datos

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtMarca.Text == "" || txtModelo.Text == "" || txtColor.Text == "" || txtAno.Text == "" || txtMatricula.Text == "" || txtPlaca.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debe haber seleccionado un registro para modificar", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Id = int.Parse(txtId.Text);
                vehiculo.Marca = txtMarca.Text;
                vehiculo.Modelo = txtModelo.Text;
                vehiculo.Color = txtColor.Text;
                vehiculo.Ano = int.Parse(txtAno.Text);
                vehiculo.Matricula = txtMatricula.Text;
                vehiculo.Placa = txtPlaca.Text;
                vehiculo.Precio = decimal.Parse(txtPrecio.Text);
                clasNegocio clas = new clasNegocio();
            

                DialogResult modif = MessageBox.Show("Seguro de modificar el registro", "Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (modif == DialogResult.Yes)
                {
                    clas.ModificarVehiculo(vehiculo);
                    LimpiarCampos();
                    CargarRegistros();
                } else
                {
                    LimpiarCampos();
                    btnAgregar.Enabled = true;

                }

                
            }
        }
        //Este evento se utliza para eliminar un Vehiculo a la base de datos

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "" || txtMarca.Text == "" || txtModelo.Text == "" || txtColor.Text == "" || txtAno.Text == "" || txtMatricula.Text == "" || txtPlaca.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debe haber seleccionado un registro para eliminar","Informe",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
             
                DialogResult eliminar = MessageBox.Show("Estas seguro que quieres eliminar", "Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (eliminar == DialogResult.Yes)
                {
                    int Id = int.Parse(txtId.Text);
                    clasNegocio me = new clasNegocio();
                    Vehiculo objV = new Vehiculo(Id);
                    me.EliminarDato(objV);
                    MessageBox.Show("Registro Eliminado");
                    CargarRegistros();
                    LimpiarCampos();
                }
                
                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormListaElim listNew = new FormListaElim();
            listNew.ShowDialog();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            paginaSaltar++;
            CargarDato();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (paginaSaltar > 1)
            {
                paginaSaltar--;
                CargarDato();
            }
        }

        private void CargarDato()
        {
            clasNegocio ne = new clasNegocio();
            DataTable dt = ne.CargarDato(paginaSaltar, paginaSiguiente);
            dgv_RegistrosVehiuculos.DataSource = dt;
        }
    }
}
