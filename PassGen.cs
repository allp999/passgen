using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace PassGen
{
    class Program
    {       
        static void Main(string[] args)
        { 
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false); 
         Application.Run(new MainForm());        
        }
    }

    public class MainForm : Form
    {
        Random rand = new Random();
        Button startgen = new Button();
        TextBox result = new TextBox();
        CheckBox upper = new CheckBox();
        CheckBox lower = new CheckBox();
        CheckBox digit = new CheckBox();
        CheckBox spec = new CheckBox();
        Label label1 = new Label();
        NumericUpDown count = new NumericUpDown();
        
        List<char[]> list = new List<char[]>();
        
        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "PassGen";
            this.Size = new Size(260,220);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            
            result.Size = new Size(210, 30);
            result.Location = new Point(20, 20);
            result.ReadOnly = true;
            result.BackColor = Color.White;
            this.Controls.Add(result);
            
            startgen.Size = new Size(210, 30);
            startgen.Location = new Point(20, 140);
            startgen.Text = "Сгенерировать";
            startgen.Click += generate;
            this.Controls.Add(startgen);
            
            count.Size = new Size(60, 30);
            count.Location = new Point(170, 70);
            count.Value = 12;
            this.Controls.Add(count);
            
            label1.Size = new Size(60, 30);
            label1.Location = new Point(166, 52);
            label1.Text = "Длина";
            this.Controls.Add(label1);
            
            upper.Size = new Size(150, 20);
            upper.Location = new Point(20,50);
            upper.Text = "Заглавные буквы";
            this.Controls.Add(upper);
            
            lower.Size = new Size(150, 20);
            lower.Location = new Point(20,70);
            lower.Text = "Маленькие буквы";
            this.Controls.Add(lower);
            
            digit.Size = new Size(150, 20);
            digit.Location = new Point(20,90);
            digit.Text = "Цифры";
            this.Controls.Add(digit);
            
            spec.Size = new Size(150, 20);
            spec.Location = new Point(20,110);
            spec.Text = "Спецсимволы";
            this.Controls.Add(spec);
        }
    
        private void AddArrays()
        {
            if(upper.Checked) list.Add(new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'});
            if(lower.Checked) list.Add(new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'});
            if(digit.Checked) list.Add(new char[] {'0','1','2','3','4','5','6','7','8','9'});
            if(spec.Checked) list.Add(new char[] {'!','@','#','$','%','^','&','*','(',')','-','+'});
        }
        
        private char GetSymbol(Random rnd)
        {
            int arr = rnd.Next(0,list.Count);
            int smb = rnd.Next(0,list[arr].Length);
            return list[arr][smb];
        }
    
        private void generate(object sender, EventArgs e)
        {
            result.Clear();
            list.Clear();
            AddArrays();
            if(list.Count > 0)
            {
              for(int i = 0; i < count.Value; i++)
              {
                  result.AppendText(GetSymbol(rand).ToString());
              }
            }
        }
        
        
    }

}
    