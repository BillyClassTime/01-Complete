using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace smartDEN_IP_32_IN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool updatingValues = false;

        public void updateStates(string data)
        {
            updatingValues = true;
            string digitalName = "<DigitalInput{0}>\r\n\t<Name>";
            string analogName = "<AnalogInput{0}>\r\n\t<Name>";
            string aoName = "<AnalogOutput{0}>\r\n\t<Name>";
            string relayName = "<Relay{0}>\r\n\t<Name>";
            string value = "<Value>";
            string count = "<Count>";
            string measure = "<Measure>";
            int startIndex = 0;
            int endIndex = 0;
            string thisInput;

            /*Digital Inputs*/
            for (uint i = 0; i < 8; i++)
            {
                thisInput = string.Format(digitalName, (i+1).ToString());
                startIndex = data.IndexOf(thisInput) + thisInput.Length;
                endIndex = data.IndexOf("</", startIndex);
                Label lb = this.Controls.Find("diName" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                    lb.Text =  data.Substring(startIndex, endIndex - startIndex);
                startIndex = data.IndexOf(value, endIndex) + value.Length;
                endIndex = data.IndexOf("</", startIndex);
                lb = this.Controls.Find("diValue" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
                startIndex = data.IndexOf(count, endIndex) + count.Length;
                endIndex = data.IndexOf("</", startIndex);
                lb = this.Controls.Find("diCount" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
            }
            /*Analog & Temperature Inputs*/
            for (uint i = 0; i < 8; i++)
            {
                thisInput = string.Format(analogName, (i + 1).ToString());
                startIndex = data.IndexOf(thisInput) + thisInput.Length;
                endIndex = data.IndexOf("</", startIndex);
                Label lb = this.Controls.Find("aiName" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
                startIndex = data.IndexOf(measure, endIndex) + measure.Length;
                endIndex = data.IndexOf("</", startIndex);
                lb = this.Controls.Find("aiMeasure" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
            }
            /*Analog Outputs*/
            for (uint i = 0; i < 2; i++)
            {
                thisInput = string.Format(aoName, (i + 1).ToString());
                startIndex = data.IndexOf(thisInput) + thisInput.Length;
                endIndex = data.IndexOf("</", startIndex);
                Label lb = this.Controls.Find("aoName" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
                startIndex = data.IndexOf(value, endIndex) + value.Length;
                endIndex = data.IndexOf("</", startIndex);
                TextBox tb = this.Controls.Find("aoValue" + (i + 1).ToString(), true).FirstOrDefault() as TextBox;
                tb.Text = data.Substring(startIndex, endIndex - startIndex);
            }
            /*Relays*/
            for (uint i = 0; i < 8; i++)
            {
                thisInput = string.Format(relayName, (i + 1).ToString());
                startIndex = data.IndexOf(thisInput) + thisInput.Length;
                endIndex = data.IndexOf("</", startIndex);
                Label lb = this.Controls.Find("relayName" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                lb.Text = data.Substring(startIndex, endIndex - startIndex);
                startIndex = data.IndexOf(value, endIndex) + value.Length;
                endIndex = data.IndexOf("</", startIndex);
                CheckBox cb = this.Controls.Find("relayState" + (i + 1).ToString(), true).FirstOrDefault() as CheckBox;
                if (data.Substring(startIndex, endIndex - startIndex).Equals("1"))
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
            /*Device Name*/
            thisInput = "<Device>\r\n\t<Name>";
            startIndex = data.IndexOf(thisInput) + thisInput.Length;
            endIndex = data.IndexOf("</", startIndex);
            TextBox txt = this.Controls.Find("nameTextBox", true).FirstOrDefault() as TextBox;
            txt.Text = data.Substring(startIndex, endIndex - startIndex);

            updatingValues = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Connecting...";
            Application.DoEvents();
            string result = GetStateRequest();
            Console.WriteLine(result);
            //richTextBox1.Text = result;
            if (result != "NULL")
            {
                int wrongPassIndex = result.IndexOf("<LoginKey>");
                int alreadyLoggedIndex = result.IndexOf("Already Logged");
                int currentStateIndex = result.IndexOf("<CurrentState>");
                if (wrongPassIndex >= 0)
                {
                    refreshButton.Text = "Connect";
                    statusLabel.Text = "Wrong password. Try again.";
                    diGroupBox.Visible = false;
                    aiGroupBox.Visible = false;
                    tiGroupBox.Visible = false;
                }
                else if (alreadyLoggedIndex >= 0)
                {
                    refreshButton.Text = "Connect";
                    statusLabel.Text = "Administrator is already logged in.";
                    diGroupBox.Visible = false;
                    aiGroupBox.Visible = false;
                    tiGroupBox.Visible = false;
                }
                else if (currentStateIndex >= 0)
                {
                    updateStates(result);
                    diGroupBox.Visible = true;
                    aiGroupBox.Visible = true;
                    tiGroupBox.Visible = true;
                }
                else
                {
                    diGroupBox.Visible = false;
                    aiGroupBox.Visible = false;
                    tiGroupBox.Visible = false;
                    refreshButton.Text = "Connect";
                    statusLabel.Text = "Failed to get data.";
                }

            }
            else
            {
                diGroupBox.Visible = false;
                aiGroupBox.Visible = false;
                tiGroupBox.Visible = false;
            }


        }

        public string GetStateRequest()
        {
            string url = "http://" + ipTextBox.Text + ":" + portTextBox.Text + "/current_state.xml?pw=" + passwordTextBox.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;
            request.Proxy = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string responseFromServer = "";
                responseFromServer = reader.ReadToEnd();
                refreshButton.Text = "Refresh";
                statusLabel.Text = "Connection Established.";
                response.Close();
                request.Abort();
                if ("http://" + ipTextBox.Text + ":" + portTextBox.Text + "/login_info.xml" == response.ResponseUri.ToString())
                    return "Already Logged";
                return responseFromServer;
            }
            catch (Exception)
            {
                diGroupBox.Visible = false;
                aiGroupBox.Visible = false;
                tiGroupBox.Visible = false;
                refreshButton.Text = "Connect";
                statusLabel.Text = "Failed to connect. Check your Internet connection and IP address/Port.";
                request.Abort();
                return "NULL";
            }
        }

        public void setRelay(int nmr, bool state)
        {
            Console.WriteLine("state: " + (state == true ? "1" : "0"));
            string url = "http://" + ipTextBox.Text + ":" + portTextBox.Text + "/current_state.xml?pw=" + passwordTextBox.Text + "&Relay" + nmr + "=" +(state==true?"1":"0");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;
            request.Proxy = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string responseFromServer = "";
                responseFromServer = reader.ReadToEnd();
                refreshButton.Text = "Refresh";
                statusLabel.Text = "Connection Established.";
                response.Close();
                request.Abort();
                if ("http://" + ipTextBox.Text + ":" + portTextBox.Text + "/login_info.xml" == response.ResponseUri.ToString())
                statusLabel.Text = "Already Logged";
            }
            catch (Exception)
            {
                diGroupBox.Visible = false;
                aiGroupBox.Visible = false;
                tiGroupBox.Visible = false;
                refreshButton.Text = "Connect";
                statusLabel.Text = "Failed to connect. Check your Internet connection and IP address/Port.";
                request.Abort();
            }
        }


        public void setAO(int nmr, string value)
        {
            string url = "http://" + ipTextBox.Text + ":" + portTextBox.Text + "/current_state.xml?pw=" + passwordTextBox.Text + "&AnalogOutput" + nmr + "=" + value;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;
            request.Proxy = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string responseFromServer = "";
                responseFromServer = reader.ReadToEnd();
                refreshButton.Text = "Refresh";
                statusLabel.Text = "Connection Established.";
                response.Close();
                request.Abort();
                if ("http://" + ipTextBox.Text + ":" + portTextBox.Text + "/login_info.xml" == response.ResponseUri.ToString())
                    statusLabel.Text = "Already Logged";
            }
            catch (Exception)
            {
                diGroupBox.Visible = false;
                aiGroupBox.Visible = false;
                tiGroupBox.Visible = false;
                refreshButton.Text = "Connect";
                statusLabel.Text = "Failed to connect. Check your Internet connection and IP address/Port.";
                request.Abort();
            }
        }

        private void aoTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            aoValue1.Text = aoTrackBar1.Value.ToString();
        }

        private void aoTrackBar2_Scroll(object sender, EventArgs e)
        {
            aoValue1.Text = aoTrackBar1.Value.ToString();
        }

        private void aoValue1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                aoTrackBar1.Value = Int32.Parse(aoValue1.Text);
                statusLabel.Text = "";
                if (aoTrackBar1.Value > 1023)
                    statusLabel.Text = "Invalid Number!";
            }
            catch (Exception)
            {
                statusLabel.Text = "Invalid Number!";
            }
        }

        private void aoValue2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                aoTrackBar2.Value = Int32.Parse(aoValue2.Text);
                statusLabel.Text = "";
                if (aoTrackBar2.Value > 1023)
                    statusLabel.Text = "Invalid Number!";
            }
            catch (Exception)
            {
                statusLabel.Text = "Invalid Number!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setAO(1, aoValue1.Text);
        }

        private void aoSet2_Click(object sender, EventArgs e)
        {
            setAO(2, aoValue2.Text);
        }

        private void relayState1_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(1, relayState1.Checked);
        }

        private void relayState2_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(2, relayState2.Checked);
        }

        private void relayState3_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(3, relayState3.Checked);
        }

        private void relayState4_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(4, relayState4.Checked);
        }

        private void relayState5_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(5, relayState5.Checked);
        }

        private void relayState6_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(6, relayState6.Checked);
        }

        private void relayState7_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(7, relayState7.Checked);
        }

        private void relayState8_CheckedChanged(object sender, EventArgs e)
        {
            setRelay(8, relayState8.Checked);
        }

    }
}
