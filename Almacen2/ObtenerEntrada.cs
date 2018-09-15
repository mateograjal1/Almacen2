using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Almacen2
{
    public partial class ObtenerEntrada : Form
    {
        public enum Tipo { String, Entero, Real };

        private Tipo tipo;
        private object entrada;

        public object Entrada { get => entrada; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo">Tipo de entrada que se espera obtener</param>
        public ObtenerEntrada(Tipo tipo)
        {
            this.tipo = tipo;
            InitializeComponent();
        }

        private void ObtenerEntrada_Load(object sender, EventArgs e)
        {
            this.AcceptButton = butAceptar;
            this.CancelButton = butCancelar;
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtEntrada.Text))
            {
                epError.SetError(txtEntrada, "El campo no debe estar vacio");
                return false;
            }
            else
            {
                switch (tipo)
                {
                    case Tipo.String:
                        entrada = txtEntrada.Text;
                        epError.Clear();
                        return true;
                    case Tipo.Entero:
                        int i;
                        if (Int32.TryParse(txtEntrada.Text, out i))
                        {
                            entrada = i;
                            epError.Clear();
                            return true;
                        }
                        else
                        {
                            epError.SetError(txtEntrada, "El campo debe ser un numero entero");
                            return false;
                        }
                    case Tipo.Real:
                        double d;
                        if (Double.TryParse(txtEntrada.Text, out d))
                        {
                            entrada = d;
                            epError.Clear();
                            return true;
                        }
                        else
                        {
                            epError.SetError(txtEntrada, "El campo debe ser un numero real");
                            return false;
                        }
                    default:
                        return false;
                }
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
