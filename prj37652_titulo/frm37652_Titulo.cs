using Prj37652_Titulo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm37652_Titulo : Form
    {
        public frm37652_Titulo()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            #region Validação do titulo

            try
            {
                string titulo = txtTitulo.Text.Trim().Replace(".", "").Replace("-", "").Replace(",", "");

                #region Validação caixa de texto
                if (string.IsNullOrEmpty(txtTitulo.Text))
                {
                    MessageBox.Show("Caixa de texto vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTitulo.Focus();
                    return;
                }
                else if (txtTitulo.TextLength < 12)
                {
                    MessageBox.Show("Caractere insulficiente para validar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTitulo.Focus();
                    return;
                }
                #endregion

                btnValidar.Text = cls37652_Titulo.vldTitulo(titulo) ? "válido" : "inválido";
                if(btnValidar.Text == "inválido")
                {
                    btnValidar.ForeColor= Color.Red;
                    cmbEstado.SelectedIndex = 29 - 1;
                }
                else if(btnValidar.Text == "válido")
                {
                    btnValidar.ForeColor= Color.Green;
                }
                string indice = titulo[8].ToString() + titulo[9].ToString();
                cmbEstado.SelectedIndex = int.Parse(indice) - 1;
            }

            catch
            {
                MessageBox.Show("Erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Clear();
                txtTitulo.Focus();
                return;
            }
            #endregion
        }
        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete &&
                e.KeyChar != (char)3 && e.KeyChar != (char)22)
            {
                e.Handled = true;
            }
        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            btnValidar.ForeColor = Color.Black;
            btnValidar.Text = "Validar";
            cmbEstado.SelectedIndex = 29 -1;
        }
    }
}
