using System;
using System.Drawing;
using System.Windows.Forms;

namespace RaceMate
{
    public class OptionSelector : Form
    {
        public string SelectedOption { get; private set; }
        
        public OptionSelector(string[] options)
        {
            Icon = global::RaceMate.Properties.Resources.logo3;
            Text = "Choose an option";

            var listBox = new ListBox
            {
                Dock = DockStyle.Top,
                IntegralHeight = false 
            };
            listBox.Items.AddRange(options);
            Controls.Add(listBox);

            var okButton = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                Height = 30
            };
            Controls.Add(okButton);

            Load += (s, e) =>
            {
                int itemHeight = listBox.ItemHeight;
                int maxItemsToShow = Math.Min(options.Length, 10); 
                listBox.Height = (itemHeight+2) * maxItemsToShow;

                Height = listBox.Height + okButton.Height + 40; 
                Width = 300;
            };

            okButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null)
                {
                    SelectedOption = listBox.SelectedItem.ToString();
                    DialogResult = DialogResult.OK;
                }
                Close();
            };
        }
    }


    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dropdown = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x_rot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y_rot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z_rot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dropdown
            // 
            this.dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown.Items.AddRange(new object[] {
            "Free Roam",
            "Sprint",
            "Laps",
            "Puzzle"});
            this.dropdown.Location = new System.Drawing.Point(3, 300);
            this.dropdown.Name = "dropdown";
            this.dropdown.Size = new System.Drawing.Size(78, 21);
            this.dropdown.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 120);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load from clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 174);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 123);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save to clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(189, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 42);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add new checkpoint";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(366, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 42);
            this.button4.TabIndex = 7;
            this.button4.Text = "Select closest";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(542, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 42);
            this.button5.TabIndex = 7;
            this.button5.Text = "Save to file";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(454, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 42);
            this.button6.TabIndex = 7;
            this.button6.Text = "Remove selected";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(277, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 42);
            this.button7.TabIndex = 7;
            this.button7.Text = "Add special";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(450, 102);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(3, 25);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(178, 20);
            this.textBox4.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(153, 301);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(76, 20);
            this.textBox5.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(231, 301);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(76, 20);
            this.textBox6.TabIndex = 1;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(309, 301);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(76, 20);
            this.textBox7.TabIndex = 1;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(388, 301);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(76, 20);
            this.textBox8.TabIndex = 1;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(467, 301);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(76, 20);
            this.textBox9.TabIndex = 1;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(546, 301);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(76, 20);
            this.textBox10.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(86, 304);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(70, 13);
            this.label.TabIndex = 8;
            this.label.Text = "Live location:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.value,
            this.x_pos,
            this.y_pos,
            this.z_pos,
            this.x_rot,
            this.y_rot,
            this.z_rot});
            this.dataGridView1.Location = new System.Drawing.Point(85, 50);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 247);
            this.dataGridView1.TabIndex = 4;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.Width = 40;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.Width = 65;
            // 
            // x_pos
            // 
            this.x_pos.HeaderText = "X";
            this.x_pos.MinimumWidth = 6;
            this.x_pos.Name = "x_pos";
            this.x_pos.Width = 65;
            // 
            // y_pos
            // 
            this.y_pos.HeaderText = "Y";
            this.y_pos.MinimumWidth = 6;
            this.y_pos.Name = "y_pos";
            this.y_pos.Width = 65;
            // 
            // z_pos
            // 
            this.z_pos.HeaderText = "Z";
            this.z_pos.MinimumWidth = 6;
            this.z_pos.Name = "z_pos";
            this.z_pos.Width = 65;
            // 
            // x_rot
            // 
            this.x_rot.HeaderText = "Pitch";
            this.x_rot.MinimumWidth = 6;
            this.x_rot.Name = "x_rot";
            this.x_rot.Width = 65;
            // 
            // y_rot
            // 
            this.y_rot.HeaderText = "Yaw";
            this.y_rot.MinimumWidth = 6;
            this.y_rot.Name = "y_rot";
            this.y_rot.Width = 65;
            // 
            // z_rot
            // 
            this.z_rot.HeaderText = "Roll";
            this.z_rot.MinimumWidth = 6;
            this.z_rot.Name = "z_rot";
            this.z_rot.Width = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 324);
            this.Controls.Add(this.dropdown);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label);
            this.Icon = global::RaceMate.Properties.Resources.logo3;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Race Mate V2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox dropdown;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;

        private System.Windows.Forms.Label label;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn x_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn y_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn z_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn x_rot;
        private System.Windows.Forms.DataGridViewTextBoxColumn y_rot;
        private System.Windows.Forms.DataGridViewTextBoxColumn z_rot;
    }
}

