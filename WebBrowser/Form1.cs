using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        // Home page URL
        private string homepageUrl = "https://www.google.com";
        public double result = 0.0;
        public double number1 = 0.0;
        public double number2 = 0.0;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If there is a possibility of going backward then go backward
            if(webBrowser1.CanGoBack)
            { 
                webBrowser1.GoBack(); 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // If there is a possibility of going forward, then go forward
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Refresh the webpage
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userInput = TextBox1.Text.Trim();
            string url = "";
            // Checking that user input is not empty
            if (!string.IsNullOrEmpty(userInput))
            {
                // If user input ends with .com , we will create the url
                if (userInput.EndsWith(".com"))
                {
                    if (!userInput.StartsWith("http://") && !userInput.StartsWith("https://"))
                    {
                        url = "https://" + userInput;
                    }
                    webBrowser1.Navigate(userInput);
                }
            }
            else
            {
                // If user input does not end in .com , we create a search engine(Google) URL with the query parameter
                string searchEngineUrl = "https://www.google.com/search?q=" + Uri.EscapeDataString(userInput);
                webBrowser1.Navigate(searchEngineUrl);
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            // Navigate to the home page
            webBrowser1.Navigate(homepageUrl);
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Calculate_Click(object sender, EventArgs e)
        {

        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            result = number1 + number2;
            textBox5.Text = result.ToString();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Getting first number from user
            try
            {
                number1 = Double.Parse(textBox3.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid input.", "Please enter a float value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Getting second number from user
            try
            {
                number2 = Double.Parse(textBox4.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid input.", "Please enter a float value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            result = number1 - number2;
            textBox5.Text = result.ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            result = number1 * number2;
            textBox5.Text = result.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            result = number1 / number2;
            textBox5.Text = result.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Calling the stock service API and putting the value in the result textbox
            try
            {
                StockService.ServiceClient serviceClient = new StockService.ServiceClient();
                textBox15.Text = serviceClient.getStockquote(textBox16.Text).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input.", "Please enter correct stock code.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
