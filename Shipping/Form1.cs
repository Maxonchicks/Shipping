using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection.Emit;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;

namespace Shipping
{
    public partial class Form1 : Form
    {
        NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;Port=5432;Database=ShippingDB;User Id=postgres;Password=vfrcjyxbr11788;");


        delegate String DataString(NpgsqlDataReader rd);

        private string placeholderText1 = "";
        private string placeholderText2 = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //�����, ������������ ������ ������� ����������� �� ��
        private List<String> Get_Info()
        {
            List<String> res = new List<String>();
            try
            {
                cn.Open(); //��������� ����������
                NpgsqlCommand cmd = new NpgsqlCommand();
                // ��������� ����� ����� �������� �������� SQL-�������� � 
                // �����������
                cmd.Connection = cn;
                String table_name = "ship";
                DataString dataString;
                dataString = get_ship_data;
                //����_���������� f2;
                textBox1.ForeColor = Color.Gray;
                textBox2.ForeColor = Color.Gray;
                textBox3.ForeColor = Color.Gray;

                if (radioButton1.Checked)
                {
                    table_name = "ship";
                    dataString = get_ship_data;
                    res.Add("RegNumber\\\\Name\\\\Skipper\\\\Type\\\\Capacity\\\\Year\\\\Dockyard");
                    toolTip1.SetToolTip(this.textBox1, "RegNumber\\Name\\Skipper\\Type\\Capacity\\Year\\Dockyard");
                    toolTip1.SetToolTip(this.textBox2, "RegNumber\\Name\\Skipper\\Type\\Capacity\\Year\\Dockyard");
                    toolTip1.SetToolTip(this.textBox3, "RegNumber");

                    placeholderText1 = "RegNumber\\Name\\Skipper\\Type\\Capacity\\Year\\Dockyard";
                    textBox1.Text = placeholderText1;
                    textBox2.Text = placeholderText1;
                    placeholderText2 = "RegNumber";
                    textBox3.Text = placeholderText2;
                }
                else if (radioButton2.Checked)
                {
                    table_name = "cargo";
                    dataString = get_cargo_data;
                    res.Add("CustomValue\\\\RegNumber\\\\Departure Date(YYYY-MM-DD)\\\\Arrive Date(YYYY-MM-DD)\\\\Origin\\\\Destination\\\\Number\\\\Shipment\\\\DeclareValue\\\\Unit\\\\InsureValue\\\\INNsender\\\\INNconsignee");
                    toolTip1.SetToolTip(this.textBox1, "CustomValue\\RegNumber\\Departure Date(YYYY-MM-DD)\\Arrive Date(YYYY-MM-DD)\\Origin\\Destination\\Number\\Shipment\\DeclareValue\\Unit\\InsureValue\\INNsender\\INNconsignee");
                    toolTip1.SetToolTip(this.textBox2, "CustomValue\\RegNumber\\Departure Date(YYYY-MM-DD)\\Arrive Date(YYYY-MM-DD)\\Origin\\Destination\\Number\\Shipment\\DeclareValue\\Unit\\InsureValue\\INNsender\\INNconsignee");
                    toolTip1.SetToolTip(this.textBox3, "CustomValue");

                    placeholderText1 = "CustomValue\\RegNumber\\Departure Date(YYYY-MM-DD)\\Arrive Date(YYYY-MM-DD)\\Origin\\Destination\\Number\\Shipment\\DeclareValue\\Unit\\InsureValue\\INNsender\\INNconsignee";
                    textBox1.Text = placeholderText1;
                    textBox2.Text = placeholderText1;
                    placeholderText2 = "CustomValue";
                    textBox3.Text = placeholderText2;
                }
                else if (radioButton3.Checked)
                {
                    table_name = "senders";
                    dataString = get_senders_data;
                    res.Add("INNsender\\\\Sender\\\\AddressSender");
                    toolTip1.SetToolTip(this.textBox1, "INNsender\\Sender\\AddressSender");
                    toolTip1.SetToolTip(this.textBox2, "INNsender\\Sender\\AddressSender");
                    toolTip1.SetToolTip(this.textBox3, "INNsender");

                    placeholderText1 = "INNsender\\Sender\\AddressSender";
                    textBox1.Text = placeholderText1;
                    textBox2.Text = placeholderText1;
                    placeholderText2 = "INNsender";
                    textBox3.Text = placeholderText2;
                }
                else if (radioButton4.Checked)
                {
                    table_name = "consignees";
                    dataString = get_consignees_data;
                    res.Add("INNconsignees\\\\Consignee\\\\BankConsignee\\\\AddressConsignee");
                    toolTip1.SetToolTip(this.textBox1, "INNconsignees\\Consignee\\BankConsignee\\AddressConsignee");
                    toolTip1.SetToolTip(this.textBox2, "INNconsignees\\Consignee\\BankConsignee\\AddressConsignee");
                    toolTip1.SetToolTip(this.textBox3, "INNconsigne");

                    placeholderText1 = "INNconsignees\\Consignee\\BankConsignee\\AddressConsignee";
                    textBox1.Text = placeholderText1;
                    textBox2.Text = placeholderText1;
                    placeholderText2 = "INNconsignee";
                    textBox3.Text = placeholderText2;
                }
                res.Add(" ");

                cmd.CommandText = $"SELECT * FROM {table_name}";
                NpgsqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(dataString(rd));
                    }
                }
            }
            catch (NpgsqlException er)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("�� ������� �������� ������ � ���� ������!");
                /*listBox1.Items.Add(er.ToString());*/
            }
            catch (Exception)
            {
            }
            finally
            {
                cn.Close();
            }
            return res;
        }

        private String get_ship_data(NpgsqlDataReader rd)
        {
            return $"{rd.GetValue(rd.GetOrdinal("regnumber"))}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Name")),15}" +
                $"\t{rd.GetValue(rd.GetOrdinal("skipper")),30}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Type")),30}" +
                $"\t{rd.GetValue(rd.GetOrdinal("capacity")),30}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Year")),30}" +
                $"\t{rd.GetValue(rd.GetOrdinal("dockyard")),30}";
        }



        private String get_cargo_data(NpgsqlDataReader rd)
        {
            return $"{rd.GetValue(rd.GetOrdinal("customvalue"))}" +
                $"\t{rd.GetValue(rd.GetOrdinal("regnumber")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Departure Date")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Arrive Date")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("origin")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("destination")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("Number")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("shipment")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("declarevalue")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("unit")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("insurevalue")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("innsender")),20}" +
                $"\t{rd.GetValue(rd.GetOrdinal("innconsignee")),20}";
        }

        private String get_senders_data(NpgsqlDataReader rd)
        {
            return $"{rd.GetValue(rd.GetOrdinal("innsender"))}" +
                $"\t{rd.GetValue(rd.GetOrdinal("sender")),35}" +
                $"\t{rd.GetValue(rd.GetOrdinal("addresssender")),65}";
            /*int innsenderWidth = 10; // ������������ ����� ��� innsender
            int senderWidth = 60; // ������������ ����� ��� sender
            int addresssenderWidth = 50; // ������������ ����� ��� addresssender

            return $"{rd.GetValue(rd.GetOrdinal("innsender")).ToString().PadRight(innsenderWidth)}\t" +
                   $"{rd.GetValue(rd.GetOrdinal("sender")).ToString().PadRight(senderWidth)}\t" +
                   $"{rd.GetValue(rd.GetOrdinal("addresssender")).ToString().PadRight(addresssenderWidth)}";*/
        }

        private String get_consignees_data(NpgsqlDataReader rd)
        {
            return $"{rd.GetValue(rd.GetOrdinal("innconsignee"))}" +
                $"\t{rd.GetValue(rd.GetOrdinal("consignee")),10}" +
                $"\t{rd.GetValue(rd.GetOrdinal("bankconsignee")),40}" +
                $"\t{rd.GetValue(rd.GetOrdinal("addressconsignee")),30}";
        }

        private void show_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Clear();
            foreach (String i in Get_Info())
                listBox1.Items.Add(i);
        }

        private void add_new_row(object sender, EventArgs e)
        {
            label2.Text = "";
            try
            {
                cn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = cn;
                String[] args;

                if (radioButton1.Checked)
                {
                    args = textBox1.Text.Split('\\');
                    /*res.Add("RegNumber\\\\Name\\\\Skipper\\\\Type\\\\Capacity\\\\Year\\\\Dockyard");*/
                    cmd.CommandText =
                        "INSERT INTO ship([regnumber], [Name], [skipper], [Type], [capacity], [Year], [dockyard]) " +
                        "VALUES (@regnumber, @Name, @skipper, @Type, @capacity, @Year, @dockyard)";
                    cmd.Parameters.AddWithValue("@regnumber", args[0]);
                    cmd.Parameters.AddWithValue("@Name", args[1]);
                    cmd.Parameters.AddWithValue("@skipper", args[2]);
                    cmd.Parameters.AddWithValue("@Type", args[3]);
                    cmd.Parameters.AddWithValue("@capacity", args[4]);
                    cmd.Parameters.AddWithValue("@Year", args[5]);
                    cmd.Parameters.AddWithValue("@dockyard", args[6]);
                }
                else if (radioButton2.Checked)
                {
                    args = textBox1.Text.Split('\\');
                    /*res.Add("CustomValue\\\\RegNumber\\\\Departure Date(YYYY-MM-DD)\\\\Arrive Date(YYYY-MM-DD)\\\\Origin\\\\Destination\\\\Number\\\\Shipment\\\\DeclareValue\\\\Unit\\\\InsureValue\\\\INNsender\\\\INNconsignee");*/
                    cmd.CommandText =
                        "INSERT INTO cargo([customvalue], [regnumber], [Departure Date], [Arrive Date], [origin], [destination], [Number], [shipment], [declarevalue], [unit], [insurevalue], [innsender], [innconsignee]) " +
                        "VALUES (@customvalue, @regnumber, @Departure_Date, @Arrive_Date, @origin, @destination, @Number, @shipment, @unit, @insurevalue, @innsender, @innconsignee)";
                    cmd.Parameters.AddWithValue("@customvalue", args[0]);
                    cmd.Parameters.AddWithValue("@regnumber", args[1]);
                    cmd.Parameters.AddWithValue("@Departure_Date", args[2]);
                    cmd.Parameters.AddWithValue("@Arrive_Date", args[3]);
                    cmd.Parameters.AddWithValue("@origin", args[4]);
                    cmd.Parameters.AddWithValue("@destination", args[5]);
                    cmd.Parameters.AddWithValue("@Number", args[6]);
                    cmd.Parameters.AddWithValue("@shipment", args[7]);
                    cmd.Parameters.AddWithValue("@declarevalue", args[8]);
                    cmd.Parameters.AddWithValue("@unit", args[9]);
                    cmd.Parameters.AddWithValue("@insurevalue", args[10]);
                    cmd.Parameters.AddWithValue("@innsender", args[11]);
                    cmd.Parameters.AddWithValue("@innconsignee", args[12]);
                }
                else if (radioButton3.Checked)
                {
                    args = textBox1.Text.Split('\\');
                    /* res.Add("INNsender\\\\Sender\\\\AddressSender");*/
                    cmd.CommandText =
                        "INSERT INTO senders([innsender], [sender], addresssender) " +
                        "VALUES (@innsender, @sender, @addresssender)";
                    cmd.Parameters.AddWithValue("@innsender", args[0]);
                    cmd.Parameters.AddWithValue("@sender", args[1]);
                    cmd.Parameters.AddWithValue("@addresssender", args[2]);
                }
                else if (radioButton4.Checked)
                {
                    args = textBox1.Text.Split('\\');
                    /* res.Add("INNconsignees\\\\Consignee\\\\BankConsignee\\\\AddressConsignee");*/
                    cmd.CommandText =
                        "INSERT INTO consignees(innconsignee, consignee, bankconsignee, addressconsignee) " +
                        "VALUES (@innconsignee, @consignee, @bankconsignee, @addressconsignee)";
                    cmd.Parameters.AddWithValue("@innconsignee", args[0]);
                    cmd.Parameters.AddWithValue("@consignee", args[1]);
                    cmd.Parameters.AddWithValue("@bankconsignee", args[2]);
                    cmd.Parameters.AddWithValue("@addressconsignee", args[3]);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                label2.BackColor = System.Drawing.Color.Red;
                label2.Text = "������!!!";
            }
            finally
            {
                cn.Close();
            }
        }

        private void change_row(object sender, EventArgs e)
        {
            label3.Text = "";
            try
            {
                cn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = cn;
                String[] args;

                if (radioButton1.Checked)
                {
                    args = textBox2.Text.Split('\\');
                    cmd.CommandText = $"UPDATE ship " +
                        $"SET Name = {args[1]}, skipper = {args[2]}, Type = {args[3]}, capacity = \"{args[4]}\", Year = \"{args[5]}\", dockyard = {args[6]} " +
                        $"WHERE [regnumber] = {args[0]}";
                }
                else if (radioButton2.Checked)
                {
                    args = textBox2.Text.Split('\\');
                    cmd.CommandText = $"UPDATE cargo " +
                        $"SET regnumber = \"{args[1]}\", [Departure Date] = \"{args[2]}\", [Arrive Date] = \"{args[3]}\", origin = \"{args[4]}\", destination = \"{args[5]}\", Number = \"{args[6]}\", shipment = \"{args[7]}\", declarevalue = \"{args[8]}\", unit = \"{args[9]}\", insurevalue = \"{args[10]}\", innsender = \"{args[11]}\", innconsignee = \"{args[12]}\" " +
                        $"WHERE customvalue = {args[0]}";
                }
                else if (radioButton3.Checked)
                {
                    args = textBox2.Text.Split('\\');
                    cmd.CommandText = $"UPDATE senders " +
                        $"SET sender = \"{args[1]}\", addresssender = \"{args[2]}\" " +
                        $"WHERE innsender = {args[0]}";
                }
                else if (radioButton4.Checked)
                {
                    args = textBox2.Text.Split('\\');
                    cmd.CommandText = $"UPDATE consignees " +
                        $"SET consignee = \"{args[1]}\", bankconsignee = \"{args[2]}\", addressconsignee = \"{args[3]}\" " +
                        $"WHERE innconsignee = {args[0]}";
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                label3.BackColor = System.Drawing.Color.Red;
                label3.Text = "������!!!";
            }
            finally
            {
                cn.Close();
            }
        }
        private void delete_row(object sender, EventArgs e)
        {
            label4.Text = "";
            try
            {
                cn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = cn;
                String[] args;

                if (radioButton1.Checked)
                {
                    args = textBox3.Text.Split('\\');
                    cmd.CommandText = $"DELETE FROM ship WHERE [regnumber] = {args[0]}";
                }
                else if (radioButton2.Checked)
                {
                    args = textBox3.Text.Split('\\');
                    cmd.CommandText = $"DELETE FROM cargo WHERE [customvalue] = {args[0]}";
                }
                else if (radioButton3.Checked)
                {
                    args = textBox3.Text.Split('\\');
                    cmd.CommandText = $"DELETE FROM sender WHERE [innsender] = {args[0]}";
                }
                else if (radioButton4.Checked)
                {
                    args = textBox3.Text.Split('\\');
                    cmd.CommandText = $"DELETE FROM consignees WHERE [innconsignee] = {args[0]}";
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                label4.BackColor = System.Drawing.Color.Red;
                label4.Text = "������!!!";
            }
            finally
            {
                cn.Close();
            }
        }



        private void textbox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == placeholderText1)
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textbox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;

                textBox1.Text = placeholderText1;
            }
        }

        private void textbox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == placeholderText1)
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void textbox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;

                textBox2.Text = placeholderText1;
            }
        }

        private void textbox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == placeholderText2)
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textbox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;

                textBox3.Text = placeholderText2;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
}