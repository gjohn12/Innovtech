using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APitester
{
    public partial class Form1 : Form
    {
        //public static Uri baseURI = new Uri("http://localhost:59443/");
        public static Uri baseURI = new Uri("http://173.248.135.95:8080/");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            //Create a new Person
            using (var client = new HttpClient())
            {
                
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Person = new PersonReceive() { FirstName = "Shameed", LastName = "Sait", Gender = "true", Address = "Hello", PhoneNumber = 314, EmailAddress = "shameedsait@gmail.com", UserName = "shameed", Password = "yard" };
                

                response = client.PostAsJsonAsync("api/friends", Person).Result;
                if (response.IsSuccessStatusCode)
                {
                   
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Get using Persons Unique ID.
            using (var client = new HttpClient())
            {
               
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                int PersonId = 1;
                string url = "api/friends/" + PersonId;
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                   HttpContent Content = response.Content;
                    Person curPersonReceive = new Person();

                    curPersonReceive = (Person)Content.ReadAsAsync(typeof(Person)).Result;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get using Persons Last / First name.
            using (var client = new HttpClient())
            {
              
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string name = "John";
                string url = "api/friends/" + "?" + "InName=" + name;
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    HttpContent Content = response.Content;
                    List<Person> curPersonReceive = new List<Person>();

                    curPersonReceive = (List<Person>)Content.ReadAsAsync(typeof(List<Person>)).Result;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Update Person using the username
            using (var client = new HttpClient())
            {
                // New code:
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Person = new PersonReceive() { FirstName = "Geboy1", LastName = "John", Gender = "true", Address = "Hello", PhoneNumber = 314, EmailAddress = "geboyj@hotmail.com", UserName = "gjohn123", Password = "y" };
                //response = await client.PostAsJsonAsync("api/friends", gizmo);

                response = client.PutAsJsonAsync("api/friends", Person).Result;
                if (response.IsSuccessStatusCode)
                {
                   
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Delete using Persons Unique ID.
            using (var client = new HttpClient())
            {
                
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                int PersonId = 2;
                string url = "api/friends/" + PersonId;
                response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Delete using Persons Unique username.
            using (var client = new HttpClient())
            {
                
                HttpResponseMessage response;
                client.BaseAddress = baseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string name = "gjohn12";
                string url = "api/friends/" + "?" + "name=" + name;
                response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    HttpContent Content = response.Content;
                    List<Person> curPersonReceive = new List<Person>();

                    curPersonReceive = (List<Person>)Content.ReadAsAsync(typeof(List<Person>)).Result;
                }
            }
        }
    }
}
