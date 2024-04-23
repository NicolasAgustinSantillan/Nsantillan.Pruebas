using Calculadora.View.Properties;
using System.Configuration;
using System.Windows.Forms;

namespace Calculadora.View
{
    public partial class View : Form
    {
        public string connectionString { get; }

        private readonly string user;

        public View()
        {
            InitializeComponent();

            this.connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            this.user = ConfigurationManager.AppSettings["User"].ToString();
        }
    }
}
