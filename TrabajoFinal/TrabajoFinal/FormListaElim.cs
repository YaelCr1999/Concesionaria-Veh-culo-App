using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace TrabajoFinal
{
    public partial class FormListaElim : Form
    {
        
        public FormListaElim()
        {
            InitializeComponent();
            
        }

        public void LeerRegistrosEliminados()
        {
            clasNegocio nuev = new clasNegocio();
            dtg_Vehiculos_Elim.DataSource = nuev.VehiculosElim();
        }

        private void FormListaElim_Load(object sender, EventArgs e)
        {
            LeerRegistrosEliminados();
            
        }

        private void dtg_Vehiculos_Elim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice == -1 || dtg_Vehiculos_Elim.SelectedCells[0].Value.ToString() == "")
            {
                MessageBox.Show("Selecciona un Registro valido");
            }
        }

      
    }
}
