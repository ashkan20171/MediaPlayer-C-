using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rwmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showabout()
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog(this);
        }

       private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            this.Text = axWindowsMediaPlayer1.currentMedia.name;
            
            int m=(int)axWindowsMediaPlayer1.currentMedia.duration;
            int i = m / 60;
            int s = m % 60;
            label3.Text = i.ToString()+":"+s.ToString();
            trackBar2.Maximum =m;
            trackBar2.Value = 0;
            timer1.Enabled = true;
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialog1.FileNames)
                    axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(filename));
                axWindowsMediaPlayer1.Ctlcontrols.play();
                int m = (int)axWindowsMediaPlayer1.currentMedia.duration;
                int i = m / 60;
                int s = m % 60;
                label3.Text = i.ToString() + ":" + s.ToString();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
            trackBar1.Value = 90;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar2.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                if (trackBar2.Value < trackBar2.Maximum)
                    trackBar2.Value++;
            
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.currentPlaylist.clear();
            timer1.Enabled = false;
            trackBar2.Value = 0;
            trackBar2.Maximum = 0;
            label3.Text = " ";
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentPlaylist.count > 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.previous();
                trackBar2.Value = 0;
                int m = (int)axWindowsMediaPlayer1.currentMedia.duration;
                int i = m / 60;
                int s = m % 60;
                label3.Text = i.ToString() + ":" + s.ToString();
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentPlaylist.count > 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.next();
                trackBar2.Value = 0;
                int m = (int)axWindowsMediaPlayer1.currentMedia.duration;
                int i = m / 60;
                int s = m % 60;
                label3.Text = i.ToString() + ":" + s.ToString();
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            timer1.Enabled = false;

        }

        private void btnPause_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Ctlcontrols.pause();
            timer1.Enabled = false;
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            trackBar2.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                     
        }

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
           
            btnNext.Text = "Next";
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.Text = " ";
        }

        private void btnMute_MouseEnter(object sender, EventArgs e)
        {
            btnMute.Text = "Mute";
        }

        private void btnMute_MouseLeave(object sender, EventArgs e)
        {
            btnMute.Text = " ";
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Text = "Play";
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Text = " ";
        }

        private void btnPause_MouseLeave(object sender, EventArgs e)
        {
            btnPause.Text = " ";
        }

        private void btnPause_MouseEnter(object sender, EventArgs e)
        {
            btnPause.Text = "Pause";
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            btnStop.Text = "Stop";
        }

        private void btnStop_MouseLeave(object sender, EventArgs e)
        {
            btnStop.Text = " ";
        }

        private void btnPre_MouseEnter(object sender, EventArgs e)
        {
            btnPre.Text = "Previous";
        }

        private void btnPre_MouseLeave(object sender, EventArgs e)
        {
            btnPre.Text = " ";
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.Text = "Clear List";
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.Text = " ";
        }

        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            btnOpen.Text = "Open Files";
        }

        private void btnOpen_MouseLeave(object sender, EventArgs e)
        {
            btnOpen.Text = " ";
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.settings.volume != 0)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
            }
            else if (axWindowsMediaPlayer1.settings.volume == 0)
            { axWindowsMediaPlayer1.settings.volume = trackBar1.Value; }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            int time = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            if (time < 60)
            {
                label1.Text = time.ToString() + " Second";
            }
            else
            {
                int m = time / 60;
                label1.Text = m.ToString()+ " Min"+"  Or "+time.ToString()+" Sec";
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            showabout();
        }

        private void btnAbout_MouseEnter(object sender, EventArgs e)
        {
            btnAbout.Text = "About";
        }

        private void btnAbout_MouseLeave(object sender, EventArgs e)
        {
            btnAbout.Text = " ";
        }
       
    }
}