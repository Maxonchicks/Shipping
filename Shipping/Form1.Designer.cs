namespace Shipping
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components=new System.ComponentModel.Container();
            listBox1=new ListBox();
            radioButton1=new RadioButton();
            radioButton2=new RadioButton();
            radioButton3=new RadioButton();
            radioButton4=new RadioButton();
            button1=new Button();
            textBox1=new TextBox();
            button2=new Button();
            textBox2=new TextBox();
            button3=new Button();
            textBox3=new TextBox();
            button4=new Button();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            toolTip1=new ToolTip(components);
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font=new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled=true;
            listBox1.ItemHeight=20;
            listBox1.Location=new Point(297, 64);
            listBox1.Margin=new Padding(3, 4, 3, 4);
            listBox1.Name="listBox1";
            listBox1.Size=new Size(1602, 544);
            listBox1.TabIndex=7;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize=true;
            radioButton1.Location=new Point(12, 64);
            radioButton1.Margin=new Padding(3, 4, 3, 4);
            radioButton1.Name="radioButton1";
            radioButton1.Size=new Size(59, 24);
            radioButton1.TabIndex=8;
            radioButton1.TabStop=true;
            radioButton1.Text="Ship";
            radioButton1.UseVisualStyleBackColor=true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize=true;
            radioButton2.Location=new Point(12, 96);
            radioButton2.Margin=new Padding(3, 4, 3, 4);
            radioButton2.Name="radioButton2";
            radioButton2.Size=new Size(70, 24);
            radioButton2.TabIndex=9;
            radioButton2.TabStop=true;
            radioButton2.Text="Cargo";
            radioButton2.UseVisualStyleBackColor=true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize=true;
            radioButton3.Location=new Point(12, 129);
            radioButton3.Margin=new Padding(3, 4, 3, 4);
            radioButton3.Name="radioButton3";
            radioButton3.Size=new Size(82, 24);
            radioButton3.TabIndex=10;
            radioButton3.TabStop=true;
            radioButton3.Text="Senders";
            radioButton3.UseVisualStyleBackColor=true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize=true;
            radioButton4.Location=new Point(12, 161);
            radioButton4.Margin=new Padding(3, 4, 3, 4);
            radioButton4.Name="radioButton4";
            radioButton4.Size=new Size(105, 24);
            radioButton4.TabIndex=11;
            radioButton4.TabStop=true;
            radioButton4.Text="Consignees";
            radioButton4.UseVisualStyleBackColor=true;
            // 
            // button1
            // 
            button1.Location=new Point(43, 221);
            button1.Margin=new Padding(3, 4, 3, 4);
            button1.Name="button1";
            button1.Size=new Size(207, 40);
            button1.TabIndex=14;
            button1.Text="Показать";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=show_Click;
            // 
            // textBox1
            // 
            textBox1.Location=new Point(382, 656);
            textBox1.Margin=new Padding(3, 4, 3, 4);
            textBox1.Name="textBox1";
            textBox1.Size=new Size(1392, 27);
            textBox1.TabIndex=25;
            textBox1.MouseEnter+=textbox1_Enter;
            textBox1.MouseLeave+=textbox1_Leave;
            // 
            // button2
            // 
            button2.Location=new Point(1795, 652);
            button2.Margin=new Padding(3, 4, 3, 4);
            button2.Name="button2";
            button2.Size=new Size(104, 34);
            button2.TabIndex=26;
            button2.Text="Добавить";
            button2.UseVisualStyleBackColor=true;
            button2.Click+=add_new_row;
            // 
            // textBox2
            // 
            textBox2.Location=new Point(382, 721);
            textBox2.Margin=new Padding(3, 4, 3, 4);
            textBox2.Name="textBox2";
            textBox2.Size=new Size(1392, 27);
            textBox2.TabIndex=27;
            textBox2.MouseEnter+=textbox2_Enter;
            textBox2.MouseLeave+=textbox2_Leave;
            // 
            // button3
            // 
            button3.Location=new Point(1795, 718);
            button3.Margin=new Padding(3, 4, 3, 4);
            button3.Name="button3";
            button3.Size=new Size(105, 30);
            button3.TabIndex=28;
            button3.Text="Изменить";
            button3.UseVisualStyleBackColor=true;
            button3.Click+=change_row;
            // 
            // textBox3
            // 
            textBox3.Location=new Point(382, 792);
            textBox3.Margin=new Padding(3, 4, 3, 4);
            textBox3.Name="textBox3";
            textBox3.Size=new Size(1392, 27);
            textBox3.TabIndex=29;
            textBox3.MouseEnter+=textbox3_Enter;
            textBox3.MouseLeave+=textbox3_Leave;
            // 
            // button4
            // 
            button4.Location=new Point(1795, 784);
            button4.Margin=new Padding(3, 4, 3, 4);
            button4.Name="button4";
            button4.Size=new Size(105, 35);
            button4.TabIndex=30;
            button4.Text="Удалить";
            button4.UseVisualStyleBackColor=true;
            button4.Click+=delete_row;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(391, 640);
            label2.Name="label2";
            label2.Size=new Size(0, 20);
            label2.TabIndex=31;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(391, 710);
            label3.Name="label3";
            label3.Size=new Size(0, 20);
            label3.TabIndex=32;
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(391, 772);
            label4.Name="label4";
            label4.Size=new Size(0, 20);
            label4.TabIndex=33;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon=ToolTipIcon.Info;
            toolTip1.ToolTipTitle="Формат ввода";
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1911, 864);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(listBox1);
            Margin=new Padding(3, 4, 3, 4);
            Name="Form1";
            Text="Form1";
            Load+=Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        /*  private System.Windows.Forms.RadioButton radioButton5;
          private System.Windows.Forms.RadioButton radioButton6;*/
        private Button button1;
        /* private System.Windows.Forms.RadioButton radioButton7;*/
        /*  private Label label1;*/
        /*private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;*/
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox2;
        private Button button3;
        private TextBox textBox3;
        private Button button4;
        private Label label2;
        private Label label3;
        private Label label4;
        private ToolTip toolTip1;
    }
}