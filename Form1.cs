using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.IO;

namespace Amx_Emailing_Service
{
    public partial class Form1 : Form
    {
        private RS232.RS232 mConn;
        private bool mBreakThread = true;
        private bool fatalError = false;
        private string fatalErrorLine = "";
        
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Exits program completely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePort();
            Application.Exit();
        }//end of exitToolStrip

        /// <summary>
        /// opens Getting_Started form and explains on how this program works.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form gtForm = new Getting_Started();
            gtForm.Show();
        }//end of about strip

        /// <summary>
        /// Shows version and that I made it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: v1.0.3 Author: Robert Humphres"+Environment.NewLine + "Fixed issue with doing File -> Exit not letting Comm port go and added a dgx done upgrading dialog.");
        }

        /// <summary>
        /// Checks to see if the information is filled out
        /// if isnt' will fire message boxes on what is needed to be fixed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Submit_Click(object sender, EventArgs e)
        {
            
            if (!(textBox_userEnterEmail.Text.Equals("")) && IsValidEmail(textBox_userEnterEmail.Text))
            {
                Thread thread;
                button_Submit.Enabled = false;
                button_Cancel.Enabled = true;
                mBreakThread = true;// True will have the thread to start looking for the complete string upgrade inside the thread and false will break the thread early.
                StartTheConnection();
                if (mConn.Connected)
                {
                    thread = new Thread(new ThreadStart(waitForKeyWord));
                    thread.Start();
                    //MessageBox.Show("Search has begun.");
                }
                    
            }//end of inner if
            else
            {
                //Could put a local bool that checks if first true and second make a combined mbox
                if(textBox_userEnterEmail.Text.Equals(""))
                    MessageBox.Show("You need to add email address for the program to send to.");
                if(checkBox_AddInfo.Enabled==true)
                    if(textBox_AddAdditionalInfo.Text.Equals(""))
                        MessageBox.Show("Either you need to Add information to the additional info box or uncheck the \"Add Information?\" checkbox");
                if(!(IsValidEmail(textBox_userEnterEmail.Text)))
                    MessageBox.Show("The Email you entered is not valid.");

            }//end of else
        }//end of Submit Click Button

        /// <summary>
        /// Waiting for the DGX to send the Key word of **** System Upgrade Complete, Ready to reboot ****
        /// </summary>
        private void waitForKeyWord()
        {
            System.DateTime timeout, endtime;
            System.TimeSpan duration;
            bool finished = true;
            while (finished == true)
            {
                //This is a of delaying the thread.....
                duration = new System.TimeSpan(0, 0, 0, 0, 1000);
                timeout = System.DateTime.Now;
                endtime = timeout.Add(duration);

                while (timeout < endtime)
                {
                    timeout = System.DateTime.Now;
                }
                //delay timer 

                foreach (string curLine in mConn.getBuffer())
                {
                    //Console.WriteLine(curLine); //this shows me whats being printed out... its like a debug

                    //This is executed when the Cancel button on the Winform is created, this causes the thread to finish before finding the System upgrade string.
                    if (mBreakThread == false)
                    {
                        finished = false;
                        break;
                    }
                        
                    if (curLine.Contains("**** System Upgrade Complete, Ready to reboot ****"))
                    {
                        SendEmail();
                        finished = false;// this takes it out of the while loop of the whole program
                        break;
                    }//end contains is true

                    if (curLine.Contains("fatal"))
                    {
                        // this is a serious error should be reported to the user with the full fatal error.
                        fatalError = true;
                        fatalErrorLine = curLine;
                    }

                }//end of foreach

            }//end of while(true) duration loop
            
            
        }//end of waitingForKeyWord

        /// <summary>
        /// Cancels sending the email. Will Stop the following:
        /// Stop the Comm1 connection
        /// Stop the email service by stopping the thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ClosePort();
            if(mConn.Connected)
            {
                MessageBox.Show("Your Connection was never established in the first place.");
            }

            //This will always need to happen.
            ResetButtons();

        }

        /// <summary>
        /// OnClick Property for Entering Email so once this is clicked the submit button will be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterEmailAddress(object sender, EventArgs e)
        {
            if (!(textBox_userEnterEmail.Text.Equals("")))
                button_Submit.Enabled = true;
        }//end of enterEmailAddress

        

        /// <summary>
        /// Connects to the Rs232 Port
        /// After the rs232 port finds what its looking for it'll fire off an email to the user.
        /// </summary>
        private void StartTheConnection()
        {
            mConn = new RS232.RS232("1", 115200);
            if (mConn.OpenSerialConnection() == false)
                {
                    MessageBox.Show("It looks like your Comm 1 port is tied up somewhere");
                    button_Submit.Enabled = true;
                    button_Cancel.Enabled = false;
                }//end of failing to start comm port

            else 
                mConn.StartListening();

        }//end of StartTheConnection

        /// <summary>
        /// Check and see if its a valid email. By validation it doesn't mean that it'll know if its a real one, but just the simple things like @hotmail etc.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to open an existing outlook, but if there isn't one will open a new instance of it.
        /// Adds information from Additional Added information and who the email is going to get sent to. 
        /// </summary>
        private void SendEmail()
        {
            //Member Variables
            Outlook.Application oApp;
            Outlook.MailItem oMsg;
            Outlook.Recipients oRecips;
            Outlook.Recipient oRecip;


            try
            {
                //Tries to pull open the current open one and if it's not there it'll open a new instance of it
                try
                {
                    oApp = (Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
                }//end of inner try

                //catch exception on instance not open
                catch (Exception)
                {
                    //Tries opening a new instance of outlook if not open.
                    oApp = new Outlook.Application();
                }//end of catch

                //Create new message
                oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                oMsg.HTMLBody = BodyMessage();
                
                oMsg.Subject = "Your DGX upgrade";
                oRecips = (Outlook.Recipients)oMsg.Recipients;
                // Add reciever for email typed by user.
                oRecip = (Outlook.Recipient)oRecips.Add(textBox_userEnterEmail.Text);
                oRecip.Resolve();
                // Send.
                oMsg.Send();

                // Clean up.
                oRecip = null;
                oRecips = null;
                oMsg = null;
                oApp = null;

                MessageBox.Show("Your DGX has finished upgrading.");
                ResetButtons();
            }//end of Try
            catch (Exception e)
            {

                WriteToLog("there was an error sending through outlook.");
                WriteToLog(e.ToString());
                //MessageBox.Show(e.ToString());
            }
        }//end of SendEmail

        /// <summary>
        /// This method decides what the Body Message will be
        /// This will get fired on in SendEmail
        /// </summary>
        /// <returns></returns>
        private string BodyMessage()
        {
            if (checkBox_AddInfo.Enabled == false)
                return "Your machine is done...";

            if (fatalError)
                return fatalErrorLine;

            else
                return readAdditionalInfoLines();
        }//end of BodyMessage

        /// <summary>
        /// If the checkbox Addition info is checked this method will go through the multiple lines that it has and will return a string that will attach into the email.
        /// This method will fire off inside BodyMessage()
        /// </summary>
        /// <returns></returns>
        private string readAdditionalInfoLines()
        {
            string temp = "";
            foreach (string tempBody in textBox_AddAdditionalInfo.Lines)
                temp += tempBody;
            return temp;
        }

        /// <summary>
        /// This is a addInfoCheckboxProperty change event that will either enable the textbox or disable it for editing. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addedInfoCheckBoxChange(object sender, EventArgs e)
        {
            if (checkBox_AddInfo.Enabled == true)
                textBox_AddAdditionalInfo.Enabled = true;
            else
                textBox_AddAdditionalInfo.Enabled = false;
        }

        /// <summary>
        /// Resets the Cancel and Submit Button
        /// </summary>
        private void ResetButtons()
        {
            if(InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(ResetButtons);
                Invoke(method);
                return;
            }

            button_Submit.Enabled = true;
            button_Cancel.Enabled = false;
        }

        /// <summary>
        /// This writes a log that will be able to be sent to me so i can change the error occuring. 
        /// </summary>
        /// <param name="log"></param>
        private void WriteToLog(String log)
        {
            MessageBox.Show("There has been a error. Please Report this error to Robert.Humphres@harman.com so I can find a fix for your error. Thank you." + Environment.NewLine + 
                "The log is called ErrorLogMAILINGSERVICE.txt and it'll be the located in the same area as this .exe");

            using (StreamWriter writetext = new StreamWriter("ErrorLogMAILINGSERVICE.txt"))
            {
                writetext.WriteLine(log);
            }
        }

        private void ClosePort()
        {
            if (mConn.Connected == true)
            {
                mBreakThread = false;
                mConn.StopListening();
                mConn.ClearBuffer();
                mConn.CloseSerialConnection();
            }
        }
    }//end of form
}
