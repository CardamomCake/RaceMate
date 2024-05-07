using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;




namespace WindowsFormsApp1

{

    public partial class Form1 : Form

    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public Form1()
        {
            InitializeComponent();
            this.Text = "RaceMate";

            //this.SizeChanged += Form1_SizeChanged;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += Timer_Tick; 
            timer.Start(); 
        }   
        

        public void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            textBox1.Text = "Race name";
            textBox4.Text = "Author name";
        }
        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    textBox5.Height =this.Height - 30; 
        //    textBox1.Height = this.Height - 100; 
        //}



        // this button is for loading from clipboard
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string clipboardstring = Clipboard.GetText();
            textBox3.Text = clipboardstring;

            JObject jObject = new JObject();

            try
            {
                jObject = JObject.Parse(clipboardstring);
            }
            catch 
            {
                MessageBox.Show("Invalid JSON format.");
                return;
            }
            JArray checkpointsArray = (JArray)jObject["checkpoints"];
            JArray boostArray = (JArray)jObject["modifiers"];
            JArray billboardArray = (JArray)jObject["billboards"];


            string name = (string)jObject["name"];
            textBox1.Text = name;
            string author = (string)jObject["author"];
            textBox4.Text = author;

            //if (!jObject.ContainsKey("checkpoints"))
            //{
            //    return;
            //}


            if (checkpointsArray != null) 
            {
                foreach (JObject checkpoint in checkpointsArray)
                {
                    string[] row = {
                                "ChP",
                                (string)checkpoint["type"],
                                (string)checkpoint["position"]["x"],
                                (string)checkpoint["position"]["y"],
                                (string)checkpoint["position"]["z"],
                                (string)checkpoint["rotation"]["x"],
                                (string)checkpoint["rotation"]["y"],
                                (string)checkpoint["rotation"]["z"]
                };

                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] == null)
                        {
                            row[i] = "0";
                        }
                    }

                    dataGridView1.Rows.Add(row);
                }
            }

            if (boostArray != null)
            {
                foreach (JObject boost in boostArray)
                {
                    string[] row = {
                                "Bst",
                                (string)boost["boostTrailLengthMeters"],
                                (string)boost["position"]["x"],
                                (string)boost["position"]["y"],
                                (string)boost["position"]["z"],
                                (string)boost["rotation"]["x"],
                                (string)boost["rotation"]["y"],
                                (string)boost["rotation"]["z"]
                };

                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] == null)
                        {
                            row[i] = "0";
                        }
                    }

                    dataGridView1.Rows.Add(row);
                }
            }

            //foreach (JObject billboard in billboardArray)
            //{
            //    string[] row = {
            //                    "BlB",
            //                    (string)billboard["type"],
            //                    (string)billboard["position"]["x"],
            //                    (string)billboard["position"]["y"],
            //                    (string)billboard["position"]["z"],
            //                    (string)billboard["rotation"]["x"],
            //                    (string)billboard["rotation"]["y"],
            //                    (string)billboard["rotation"]["z"]
            //    };

            //    for (int i = 0; i < row.Length; i++)
            //    {
            //        if (row[i] == null)
            //        {
            //            row[i] = "0";
            //        }
            //    }

            //    dataGridView1.Rows.Add(row);
            //}

        }



        // This button is for saving to clipboard 
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            string savedString = textBox3.Text;
            JObject jObject = new JObject();

            try
            {
                jObject = JObject.Parse(savedString);
            }
            catch 
            {
                MessageBox.Show("No valid file to save to clipboard.");
                return;
            }
            jObject["name"] = textBox1.Text;
            jObject["author"] = textBox4.Text;
            jObject["gameType"] = "Time Trial";

            jObject.Remove("checkpoints");
            jObject.Remove("modifiers");
            savedString =  rebuildJson(jObject, dataGridView1);

            Clipboard.SetText(savedString);

        }



        // This button is for adding a checkpoint
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            if (textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }

            string[] newRow = {
                "ChP",
                "1",
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text};

            dataGridView1.Rows.Add(newRow);
            
        }



        // This button is for adding a checkpoint
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            if (textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }

            string[] newRow = {
                "Bst",
                "3000",
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text};

            dataGridView1.Rows.Add(newRow);

        }



        //Button to remove clossest object
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }

            double x_pos = double.Parse(textBox5.Text);
            double y_pos = double.Parse(textBox6.Text);
            double z_pos = double.Parse(textBox7.Text);

            double dist = new double();
            double smallest_dist = double.PositiveInfinity;
            int smallest_i = 0;
            for (int i = 1; i < dataGridView1.RowCount-1; i++)
            {
                double distx = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) - x_pos;
                double disty = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) - y_pos;
                double distz = double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) - z_pos;

                dist = Math.Sqrt(distx*distx + disty * disty + distz * distz);
                if (dist < smallest_dist)
                {
                    smallest_dist = dist;
                    Console.WriteLine("{i} {dist}");
                    smallest_i = i;
                };

            }

            dataGridView1.Rows.RemoveAt(smallest_i);
            Console.WriteLine(smallest_dist);
        }



        //Button to remove selected object
        private void button6_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            int[] selectedIndices = new int[dataGridView1.SelectedRows.Count];

            foreach (DataGridViewRow row in selectedRows)
            {
                int rowIndex = row.Index; 
                if (rowIndex < dataGridView1.RowCount-1)
                {
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
        }



        // This button is for saving to a file 
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            string savedString = textBox3.Text;
            JObject jObject = new JObject();

            try
            {
                jObject = JObject.Parse(savedString);
            }
            catch 
            {
                MessageBox.Show("No valid file to save:\n");
                return;
            }

            jObject["name"] = textBox1.Text;
            jObject["author"] = textBox4.Text;
            jObject["gameType"] = "Time Trial";

            jObject.Remove("checkpoints");
            jObject.Remove("modifiers");
            savedString = rebuildJson(jObject, dataGridView1);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = (textBox1.Text +".json");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, savedString);
            }
        }


        private string rebuildJson(JObject jObject, DataGridView dataGridView1)
        {
            String Checkpoints = "\n  \"checkpoints\": [";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "ChP")
                {

                    string type = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string posX = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string posY = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string posZ = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string rotX = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string rotY = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string rotZ = dataGridView1.Rows[i].Cells[7].Value.ToString();

                    string checkpoint = $@"
    {{
      ""type"": {type},
      ""position"": {{
        ""x"": {posX},
        ""y"": {posY},
        ""z"": {posZ}
      }},
      ""rotation"": {{
        ""x"": {rotX},
        ""y"": {rotY},
        ""z"": {rotZ}
      }}
    }},";
                    Checkpoints = Checkpoints + checkpoint;
                }
            }
            //Checkpoints = Checkpoints.Substring(0, Checkpoints.Length - 1);
            Checkpoints = Checkpoints + "\n  ]";
            


            String Boosts = "\n  \"modifiers\": [ ";


            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "Bst")
                {
                    string value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string posX = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string posY = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string posZ = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string rotX = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string rotY = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string rotZ = dataGridView1.Rows[i].Cells[7].Value.ToString();

                    string boost = $@"
    {{
      ""position"": {{
        ""x"": {posX},
        ""y"": {posY},
        ""z"": {posZ}
      }},
      ""rotation"": {{
        ""x"": {rotX},
        ""y"": {rotY},
        ""z"": {rotZ}
      }},
      ""type"": ""Boost"",
      ""boostTrailLengthMeters"": {value}
    }},";
                    Boosts = Boosts + boost;
                }
            }
            Boosts = Boosts.Substring(0, Boosts.Length - 1);
            Boosts = Boosts + "\n  ]";


            string savedstring = jObject.ToString();
            savedstring = savedstring.Substring(0, savedstring.Length - 3);
            savedstring = savedstring + "," + Checkpoints +"," + Boosts +"\n}";
            return savedstring;
        }

        private static string getdata()
        {
            //This function was basicaly written by ChatGPT because I dont understand this shit. 
            const int RECEIVE_TIMEOUT_MS = 100; // 0.1 seconds

            string message = string.Empty;

            UdpClient udpClient = null;
            IPEndPoint remoteEndPoint = null;
            try
            {
                // Create UDP client and specify local port to listen on
                udpClient = new UdpClient(11000);
                // Set the receive timeout
                udpClient.Client.ReceiveTimeout = RECEIVE_TIMEOUT_MS;
                // Create endpoint for the sender's IP address and port
                remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                // Receive data from the UDP socket
                byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);
                // Convert received bytes to string
                string receivedData = Encoding.ASCII.GetString(receivedBytes);
                // Process received data (e.g., display it, save it to a file, etc.)
                message = receivedData;          

            }
            catch (SocketException ex)
            {
                // Handle socket exception (e.g., timeout, connection reset, etc.)
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    message = ("Receive operation timed out.");
                }
                else
                {
                    message = ("Socket exception: " + ex.Message);
                }
            }
            finally
            {
                if (udpClient != null)
                    udpClient.Close();
            }

            return message;
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            string data = getdata();
            JObject jObject = new JObject();

            try
            {
                jObject = JObject.Parse(data);
            }
            catch 
            {
                return;
            }

            textBox5.Text = (string)jObject["shipWorldPosition"]["x"];
            textBox6.Text = (string)jObject["shipWorldPosition"]["y"];
            textBox7.Text = (string)jObject["shipWorldPosition"]["z"];

            textBox8.Text = (string)jObject["shipWorldRotationEuler"]["x"];
            textBox9.Text = (string)jObject["shipWorldRotationEuler"]["y"];
            textBox10.Text = (string)jObject["shipWorldRotationEuler"]["z"];
        }


    }



}


