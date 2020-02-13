﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using HslCommunication;
using System.Net;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormHttpServer : HslFormContent
    {
        public FormHttpServer( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            comboBox1.DataSource = new string[]
            {
                "text/html",
                "text/plain",
                "text/xml",
                "application/xml",
                "application/json"
            };

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
            }
            else
            {
            }
        }

        HttpServer httpServer;
        private void button1_Click( object sender, EventArgs e )
        {
            // 启动服务
            try
            {
                httpServer = new HttpServer( );
                httpServer.Start( int.Parse( textBox2.Text ) );
                httpServer.HandleRequestFunc = HandleRequest;
                httpServer.IsCrossDomain = checkBox1.Checked;             // 是否跨域的设置

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Started Failed:" + ex.Message );
            }
        }

        private Dictionary<string, string> returnWeb = new Dictionary<string, string>( );
        private Dictionary<string, string> postWeb = new Dictionary<string, string>( );

        private string HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )
        {
            if(request.HttpMethod == "GET")
            {
                if (returnWeb.ContainsKey( request.RawUrl ))
                {
                    response.AddHeader( "Content-type", $"Content-Type: {comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                    return returnWeb[request.RawUrl];
                }
            }
            else if(request.HttpMethod == "POST")
            {
                // POST示例，在data中可以上传复杂的数据，长度不限制的
                if (postWeb.ContainsKey( request.RawUrl ))
                {
                    response.AddHeader( "Content-type", $"Content-Type: {comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                    return postWeb[request.RawUrl];
                }
            }
            else
            {

            }
            return string.Empty;
        }

        private void button3_Click( object sender, EventArgs e )
        {
            // 设置GET
            if (returnWeb.ContainsKey( textBox5.Text ))
            {
                returnWeb[textBox5.Text] = textBox4.Text;
            }
            else
            {
                returnWeb.Add( textBox5.Text, textBox4.Text );
            }
        }

        private void Button7_Click( object sender, EventArgs e )
        {
            // 设置POST
            if (postWeb.ContainsKey( textBox5.Text ))
            {
                postWeb[textBox5.Text] = textBox4.Text;
            }
            else
            {
                postWeb.Add( textBox5.Text, textBox4.Text );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 请求
            webBrowser1.Url = new Uri( textBox1.Text );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            httpServer?.Close( );
            panel2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {

        }
    }


    #endregion
}
