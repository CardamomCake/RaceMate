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
using System.Drawing.Text;
using System.Globalization;
using System.IO.Compression;




namespace RaceMate

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
        

        // this button is for loading from clipboard
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DialogResult result = MessageBox.Show("There already is data loaded. Do you wish to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                
            }

            dataGridView1.Rows.Clear();
            string clipboardstring = Clipboard.GetText();
            

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
            textBox3.Text = clipboardstring; // this so such a dumb way to make a global string, but I dont care to change it to something aqtually sensable
            string type = (string)jObject["gameType"];
            string[] allowedList = {
            "Free Roam",
            "Sprint",
            "Laps",
            "Puzzle"};
            if (!allowedList.Contains(type)) type = "Sprint";
            dropdown.SelectedItem = type;
            JArray checkpointsArray = (JArray)jObject["checkpoints"];
            JArray boostArray = (JArray)jObject["modifiers"];
            JArray billboardArray = (JArray)jObject["billboards"];


            string name = (string)jObject["name"];
            if (name != "")
                textBox1.Text = name;
            
            string author = (string)jObject["author"];
            if (author != "")
                textBox4.Text = author;

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

            if (billboardArray != null)
            {
                foreach (JObject billboard in billboardArray)
                {
                    if (billboard.ContainsKey("customMessage")) { 
                        string[] row = {
                                    "BB",
                                    (string)billboard["customMessage"],
                                    (string)billboard["position"]["x"],
                                    (string)billboard["position"]["y"],
                                    (string)billboard["position"]["z"],
                                    (string)billboard["rotation"]["x"],
                                    (string)billboard["rotation"]["y"],
                                    (string)billboard["rotation"]["z"]
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
                    else
                    {
                        string[] row = {
                                    "BBI",
                                    (string)billboard["type"],
                                    (string)billboard["position"]["x"],
                                    (string)billboard["position"]["y"],
                                    (string)billboard["position"]["z"],
                                    (string)billboard["rotation"]["x"],
                                    (string)billboard["rotation"]["y"],
                                    (string)billboard["rotation"]["z"]
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
            }
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
            jObject["gameType"] = dropdown.SelectedItem?.ToString();;

            jObject.Remove("checkpoints");
            jObject.Remove("modifiers");
            jObject.Remove("billboards");

            savedString =  rebuildJson(jObject, dataGridView1);
            bool active  = false;
            bool instring = false;
            int deaph = 0;
            
            StringBuilder cleanedFileName = new StringBuilder();

            foreach (char charicter in savedString)
            {
                if(charicter == char.Parse("[")){ active = true ;}
                if(charicter == char.Parse("]")){ active = false ;}
                if(charicter == '\"'){ instring = !instring;}

                if(active&&!instring){
                    if (charicter == char.Parse("{")) { deaph++; }
                    else if (charicter == char.Parse("}")) { deaph--; } 
                }

                if (deaph>=1&&!instring)
                {
                    if (charicter != ' ' && charicter != '\n' && charicter != '\r')
                    { cleanedFileName.Append(charicter); }
                }
                else {cleanedFileName.Append(charicter); }
            }

            Clipboard.SetText(cleanedFileName.ToString());

        }



        // This button is for adding a checkpoint
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            if (textBox5.Text == "") 
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }
            (string x_string, string y_string, string z_string, string pitch_string, string yaw_string, string roll_string) = GetCoordinates();

            if (dropdown.SelectedItem.ToString()=="Free Roam") dropdown.SelectedItem = "Sprint";

            string[] newRow = {
                "ChP",
                "1",
                x_string,
                y_string,
                z_string,
                pitch_string,
                yaw_string,
                roll_string};

            dataGridView1.Rows.Add(newRow);
            
        }


        // This button is for adding a boost
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No json level in memory, please load a json scene.");
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }
            (string x_string, string y_string, string z_string, string pitch_string, string yaw_string, string roll_string) = GetCoordinates();
            
            var selector = new OptionSelector(new[] { "Add booster", "Add text billboard", "Add image billboard" });
            selector.TopMost = true;
            if (selector.ShowDialog(this) == DialogResult.OK) 
            {
                string chosen = selector.SelectedOption;
                switch (chosen) {
                    case "Add booster":
                        string[]newBstRow = {
                            "Bst",
                            "3000",
                            x_string,
                            y_string,
                            z_string,
                            pitch_string,
                            yaw_string,
                            roll_string};

                        dataGridView1.Rows.Add(newBstRow);
                        break;
                    case "Add text billboard":
                        string[] newBBRow = {
                            "BB",
                            "Custom Message",
                            x_string,
                            y_string,
                            z_string,
                            ((360f -float.Parse(pitch_string))%360f).ToString(),
                            ((float.Parse(yaw_string)+180f)% 360f).ToString(),
                            ((360f -float.Parse(roll_string))%360f).ToString()
                        };

                        dataGridView1.Rows.Add(newBBRow);
                        break;
                    case "Add image billboard":
                        var selector2 = new OptionSelector(new[] { "Fly Dangerous", "Direction Arrow Single Left", "Direction Arrow Single Right", "Direction Arrow Double Left", "Direction Arrow Double Right", "Squid Cola", "Cope","Newtons Gambit","Eden Prime","Europa","Dopefish",});
                        selector2.TopMost = true;

                        if (selector2.ShowDialog(this) == DialogResult.OK) { 
                            string choise = selector2.SelectedOption;
                            bool flipped = true;
                            if (choise.EndsWith(" Right")){
                                choise = choise.Substring(0, choise.Length - 6);
                            }

                            if (choise.EndsWith(" Left")){
                                choise = choise.Substring(0, choise.Length - 5);
                                flipped = false;
                            }

                            if (flipped)
                            {
                                string[] newBBIRowFlipped = {
                                    "BBI",
                                    choise,
                                    x_string,
                                    y_string,
                                    z_string,
                                    ((360f -float.Parse(pitch_string))%360f).ToString(),
                                    ((float.Parse(yaw_string)+180f)% 360f).ToString(),
                                    ((360f -float.Parse(roll_string))%360f).ToString()
                                };
                                
                                dataGridView1.Rows.Add(newBBIRowFlipped); 
                            }
                            else
                            {
                                string[] newBBIRow = {
                                    "BBI",
                                    choise,
                                    x_string,
                                    y_string,
                                    z_string,
                                    pitch_string,
                                    yaw_string,
                                    roll_string
                                };
                                dataGridView1.Rows.Add(newBBIRow); 
                            }
                        }
                        break;
                }
            }
        }


        //Button to sellect clossest object
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("No live location recorded, please check if game is running and that telemetry is enabled under integration in settings.");
                return;
            }

            (string x_string, string y_string, string z_string, string _pitch_string, string _yaw_string, string _roll_string) = GetCoordinates();

            float x_pos = float.Parse(x_string);
            float y_pos = float.Parse(y_string);
            float z_pos = float.Parse(z_string);

            float dist = new float();
            float smallest_dist = float.PositiveInfinity;
            int smallest_i = 0;
            for (int i = 1; i < dataGridView1.RowCount-1; i++)
            {
                float distx = float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) - x_pos;
                float disty = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) - y_pos;
                float distz = float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) - z_pos;

                dist = (float)Math.Sqrt(distx*distx + disty * disty + distz * distz);
                if (dist < smallest_dist)
                {
                    smallest_dist = dist;
                    Console.WriteLine("{i} {dist}");
                    smallest_i = i;
                };
            }
            dataGridView1.ClearSelection(); 
            dataGridView1.Rows[smallest_i].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[smallest_i].Cells[0]; 
        }


        //Button to remove selected object
        private void button6_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;

            int[] selectedIndices = new int[dataGridView1.SelectedRows.Count];

            if (selectedIndices.Count<int>() == 0)
            {
                MessageBox.Show("No rows selected, select a row by clicking on the leftmost empty cell of a row.");
                return;
            }

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
            jObject["gameType"] = dropdown.SelectedItem?.ToString();;

            jObject.Remove("checkpoints");
            jObject.Remove("modifiers");
            jObject.Remove("billboards");
            savedString = rebuildJson(jObject, dataGridView1);

            string fileName = textBox1.Text;

            StringBuilder cleanedFileName = new StringBuilder();

            foreach (char charicter in fileName)
            {
                if (!Path.GetInvalidFileNameChars().Contains(charicter))
                {
                    cleanedFileName.Append(charicter);
                }
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "ZIP files (*.zip)|*.zip";
            saveDialog.Title = "Save level file";
            saveDialog.DefaultExt = "zip";
            saveDialog.FileName = cleanedFileName.ToString();

            

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream zipToOpen = new FileStream(saveDialog.FileName, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry jsonEntry = archive.CreateEntry("level.json");
                    using (StreamWriter writer = new StreamWriter(jsonEntry.Open()))
                    {
                        writer.Write(savedString);
                    }

                    string resourceName = "RaceMate.Resources.thumbnail.png";

                    using (Stream resourceStream = typeof(Form1).Assembly.GetManifestResourceStream(resourceName))
                    {
                        if (resourceStream != null)
                        {
                            ZipArchiveEntry imageEntry = archive.CreateEntry("thumbnail.png");
                            using (Stream entryStream = imageEntry.Open())
                            {
                                resourceStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

        }


        private string rebuildJson(JObject jObject, DataGridView dataGridView1)
        {
            String Checkpoints = "\n  \"checkpoints\": [ ";

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
            Checkpoints = Checkpoints.Substring(0, Checkpoints.Length - 1);
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
            Boosts = Boosts + "\n  ],";

            String Billboards = "\n  \"billboards\": [ ";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "BB")
                {
                    string value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string posX = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string posY = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string posZ = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string rotX = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string rotY = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string rotZ = dataGridView1.Rows[i].Cells[7].Value.ToString();

                    string billboard = $@"
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
      ""type"": ""Custom Message"",
      ""customMessage"": ""{value}""
    }},";
                    Billboards = Billboards + billboard;
                }

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "BBI")
                {
                    string value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string posX = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string posY = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string posZ = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string rotX = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string rotY = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string rotZ = dataGridView1.Rows[i].Cells[7].Value.ToString();

                    string billboard = $@"
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
      ""type"": ""{value}""
    }},";
                    Billboards = Billboards + billboard;
                }
            }
            Billboards = Billboards.Substring(0, Billboards.Length - 1);
            Billboards = Billboards + "\n  ]";


            string savedstring = jObject.ToString();
            savedstring = savedstring.Substring(0, savedstring.Length - 3);
            savedstring = savedstring + "," + Checkpoints +"," + Boosts + Billboards + "\n}";
            return savedstring;
        }

        private static string getdata()
        {
            string mostRecentData = Program.Receiver.MostRecentData;
            return mostRecentData;
            
        }
        



        private void Timer_Tick(object sender, EventArgs e)
        {
            string x; string y; string z; string pitch; string yaw; string roll;

            try
            {
                (x,y,z,pitch,yaw,roll) = GetCoordinates();
            }
            catch 
            {
                return;
            }

            textBox5.Text = x;
            textBox6.Text = y;
            textBox7.Text = z;

            textBox8.Text = pitch;
            textBox9.Text = yaw;
            textBox10.Text = roll;
        }

        private static (string, string, string, string, string, string) GetCoordinates()
        {
            var jObject = JObject.Parse(Program.Receiver.MostRecentData);
            return (
                (string)jObject["shipWorldPosition"]["x"],
                (string)jObject["shipWorldPosition"]["y"],
                (string)jObject["shipWorldPosition"]["z"],

                (string)jObject["shipWorldRotationEuler"]["x"],
                (string)jObject["shipWorldRotationEuler"]["y"],
                (string)jObject["shipWorldRotationEuler"]["z"]
            );
        }
    }

}



