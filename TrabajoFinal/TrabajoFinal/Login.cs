using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace TrabajoFinal
{
    public partial class Login : Form
    {
        clasNegocio obj = new clasNegocio();
        Usuarios usuario = new Usuarios();
        public Login()
        {
            InitializeComponent();

            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;
            validacionCampos(usuario);
           
        }

        private void validacionCampos(Usuarios usuario)
        {
            
            if (usuario.NombreUsuario == "" && usuario.Contraseña == "")
            {
                MessageBox.Show("Tienes que ingresar nombre de usuario y contraseña");
            }
            else if (usuario.NombreUsuario == "")
            {
                MessageBox.Show("Tienes que ingresar un nombre usuario");

            }
            else if (usuario.Contraseña == "")
            {
                MessageBox.Show("Tienes que ingresar una contraseña");
            }
            else
            {
                // Llamamos al método login de la capa de negocio
                bool loginExitoso = obj.login(usuario); // Modifica este método para que devuelva un bool

                // Si el login es exitoso, abrimos la siguiente ventana
                if (loginExitoso)
                {
                  
                    ConcesionarioVehiculo con = new ConcesionarioVehiculo();
                    con.ShowDialog();
                    this.Close();


                }
                // Si el login falla, mostramos un mensaje de error
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
