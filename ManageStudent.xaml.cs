using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Learn_English
{
    /// <summary>
    /// Interaction logic for ManageStudent.xaml
    /// </summary>
    public partial class ManageStudent : Window
    {
       
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        

        public ManageStudent()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {          
            dtgrd.DataContext = bindingSource1;
            GetData("SELECT * FROM Students");

        }

        private void GetData(string selectCommand)
        {
            try
            {
                
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                    

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                table.Columns[0].ColumnName = "Student ID";
                table.Columns[1].ColumnName = "Username";
                table.Columns[2].ColumnName = "Password";
                table.Columns[3].ColumnName = "Lastname";
                table.Columns[4].ColumnName = "General Grade";
                bindingSource1.DataSource = table;            
                
            }
            catch (SqlException)
            {
                System.Windows.MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }
    }
}
