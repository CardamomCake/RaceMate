using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.textBox8= new System.Windows.Forms.TextBox();
            this.textBox9= new System.Windows.Forms.TextBox();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 131);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load from clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 190);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 135);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save to clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(275, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add new checkpoint";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(505, 6);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 43);
            this.button4.TabIndex = 7;
            this.button4.Text = "Remove closest";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(735, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 43);
            this.button5.TabIndex = 7;
            this.button5.Text = "Save to file";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(620, 6);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 43);
            this.button6.TabIndex = 7;
            this.button6.Text = "Remove selected";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(390, 6);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 43);
            this.button7.TabIndex = 7;
            this.button7.Text = "Add new boost";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(600, 126);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 30);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(252, 22);
            this.textBox4.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(140, 330);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(250, 330);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 1;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(360, 330);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 1;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(470, 330);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 1;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(580, 330);
            this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 1;
            //
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(690, 330);
            this.textBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 1;

            
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(40, 333); // Adjust the location as needed
            this.label.Name = "Label";
            //this.label.ReadOnly = true;
            this.label.Size = new System.Drawing.Size(110, 20); // Adjust the size as needed
            this.label.Text = "Live location:";
            //this.label.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            

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
            //this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(122, 55);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(719, 270);
            this.dataGridView1.TabIndex = 4;
            //this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.value.HeaderText = "value";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.Width = 65;
            // 
            // x_pos
            // 
            this.x_pos.HeaderText = "xpos";
            this.x_pos.MinimumWidth = 6;
            this.x_pos.Name = "x_pos";
            this.x_pos.Width = 65;
            // 
            // y_pos
            // 
            this.y_pos.HeaderText = "ypos";
            this.y_pos.MinimumWidth = 6;
            this.y_pos.Name = "y_pos";
            this.y_pos.Width = 65;
            // 
            // z_pos
            // 
            this.z_pos.HeaderText = "zpos";
            this.z_pos.MinimumWidth = 6;
            this.z_pos.Name = "z_pos";
            this.z_pos.Width = 65;
            // 
            // x_rot
            // 
            this.x_rot.HeaderText = "xrot";
            this.x_rot.MinimumWidth = 6;
            this.x_rot.Name = "x_rot";
            this.x_rot.Width = 65;
            // 
            // y_rot
            // 
            this.y_rot.HeaderText = "yrot";
            this.y_rot.MinimumWidth = 6;
            this.y_rot.Name = "y_rot";
            this.y_rot.Width = 65;
            // 
            // z_rot
            // 
            this.z_rot.HeaderText = "zrot";
            this.z_rot.MinimumWidth = 6;
            this.z_rot.Name = "z_rot";
            this.z_rot.Width = 65;
            // 
            // Form1
            // 
            this.Size = new System.Drawing.Size(865, 400);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //this.ClientSize = new System.Drawing.Size(800, 340);
            

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
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 30);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(252, 22);
            this.textBox4.TabIndex = 1;

            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("logo3")));

            Icon appIcon = RaceMate.Properties.Resources.logo3; // Assuming you have an icon named MyIcon.ico in your Resources

            // Set the form's icon
            this.Icon = appIcon;

            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RaceMate";
            this.Text = "Race Mate V2";

            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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

