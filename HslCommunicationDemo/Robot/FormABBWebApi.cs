﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;

namespace HslCommunicationDemo.Robot
{
    public partial class FormABBWebApi : HslFormContent
    {
        public FormABBWebApi( )
        {
            InitializeComponent( );
        }

        private ABBWebApiClient webApiClient;

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                webApiClient = new ABBWebApiClient( textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text );
                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
            }
        }

        private async void Button2_Click( object sender, EventArgs e )
        {
            if(comboBox1.SelectedIndex == 0)
            {
                OperateResult<string> read = await webApiClient.ReadStringAsync( textBox5.Text );
                if (read.IsSuccess)
                {
                    textBox6.Text = read.Content;
                    webBrowser1.DocumentText = read.Content;
                }
                else
                {
                    MessageBox.Show( "Read Failed:" + read.Message );
                }
            }
            else
            {
                OperateResult write = await webApiClient.WriteAsync( textBox5.Text, textBox7.Text );
                if (write.IsSuccess)
                {
                    MessageBox.Show( "Write Success" );
                }
                else
                {
                    MessageBox.Show( "Read Failed:" + write.Message );
                }
            }
        }

        private void FormABBWebApi_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
        }

        private void RadioButton2_CheckedChanged( object sender, EventArgs e )
        {
            if (radioButton2.Checked)
            {
                textBox6.Visible = false;
                webBrowser1.Visible = true;
            }
        }

        private void RadioButton1_CheckedChanged( object sender, EventArgs e )
        {
            if (radioButton1.Checked)
            {
                textBox6.Visible = true;
                webBrowser1.Visible = false;
            }
        }

        private async void Button3_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetErrorStateAsync( );
            if(!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button4_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetJointTargetAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button5_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetSpeedRatioAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button6_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetOperationModeAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button7_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetCtrlStateAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button8_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetIOInAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button9_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetIOOutAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button11_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetIO2InAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button10_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetIO2OutAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private async void Button12_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = await webApiClient.GetLogAsync( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }
    }
}
