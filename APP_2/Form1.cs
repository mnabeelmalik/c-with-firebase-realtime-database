using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace APP_2
{
    public partial class Form1 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "asdasd32423423jajsfasd#@", // your project authsecret
            BasePath = "https://abc.ass.firebaseio.com/" // your project url

        };
        IFirebaseClient my_client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            my_client = new FireSharp.FirebaseClient(config);
            timer1.Start();
            if (my_client == null)
            {
                timer1.Stop();
                MessageBox.Show("Connection Not Established");
            }
            else
            {
                ret_data();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            data_upd("A");
        }
        public async void data_upd(String a)
        {
            var obj = new Data
            {
                r = a,
                //t = "a",
                //m = "a",
            };
            SetResponse resp = await my_client.SetTaskAsync("datar/", obj);
            Data res = resp.ResultAs<Data>();
            //MessageBox.Show("UPD");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            data_upd("D");
        }

        private void reverse_Click(object sender, EventArgs e)
        {
            data_upd("B");
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            data_upd("E");
        }

        private void Left_Click(object sender, EventArgs e)
        {
            data_upd("C");
        }

         private async void ret_data()
        {
            FirebaseResponse resp = await my_client.GetTaskAsync("datas/");
            Data obj = resp.ResultAs<Data>();
            lbl_temp.Text = obj.t+ " °C";
            lbl_hum.Text = obj.h +" %";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ret_data();
        }
    }
}
