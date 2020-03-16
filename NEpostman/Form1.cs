using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEpostman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //хэндлеры
        private void btnGO_Click(object sender, EventArgs e)
        {
            RestClient restClient = new RestClient();
            restClient.EndPoint = txtURL.Text;
            txtResponse.Text = restClient.MakeRequest();
        }


    }
}
