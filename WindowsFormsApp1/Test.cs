using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Test : Form
    { 
        Thread firstThreadBackground = null;
        Thread secondThreadBackground = null;
         
        TestLongestRun run = new TestLongestRun();
         
        delegate void ThreadedAction(object[] parameters);


        void refreshProgressBar(object[] parameters)
        {
            if (progressBar1.InvokeRequired == false)
            {
                progressBar1.Maximum = (int)parameters[0];
                progressBar1.Value = (int)parameters[1];
                label1.Text = (int)parameters[1] + "/" + (int)parameters[0];
            }
            else
            {
                ThreadedAction refreshP = new ThreadedAction(refreshProgressBar);
                this.Invoke(refreshP, parameters);
            }
        } 

        void ThreadUI()
        { 
            secondThreadBackground = new Thread(new ThreadStart(run.runTest));
            secondThreadBackground.Start();
             
            while (!run.workFinished)
            {
                try
                { 
                    ThreadedAction refreshP = new ThreadedAction(refreshProgressBar);
                    this.Invoke(refreshP, new object[] { new object[] { (int)run.maxLength, (int)run.actually } });
                }
                catch (Exception ex)
                {

                }
            } 
        }


        public Test()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {

            firstThreadBackground = new Thread(new ThreadStart(ThreadUI));
            firstThreadBackground.Start(); 
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {

            if (secondThreadBackground != null)
            {
                secondThreadBackground.Abort();
            }
            if (firstThreadBackground!= null)
            {
                firstThreadBackground.Abort();  
            }
        }
    }
}
