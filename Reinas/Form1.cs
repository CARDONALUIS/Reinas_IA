using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Reinas
{
    public partial class Form1 : Form
    {
        int r = 0;
        int x = 100;
        int y = 50;
        string strButtonName = "btn_Tablero";  //Nombre que van a tener los botones del tablero

        public Form1()
        {
            List<int> tab;
            InitializeComponent();
            
            tab = creaTablero();
            int contTab = 0;
            //creaPaneles();
            MessageBox.Show("Buscare la solucion, dame unos segundos, click en aceptar");
            while(!esValido(tab))
            {
                tab = creaTablero();
                //if(contTab < 10)
                
                r = 0;
                contTab++;
            }
            creaPaneles(tab);
            MessageBox.Show("!!!Encontre la solucion en la iteracion: " + contTab+"\nClick en aceptar para ver tablero\nSi las reinas no se ven, direccionar a la carpeta donde esta la imagen");
            r = 0;
        }

        public bool esValido(List<int> tabPru)
        {
            int indCom = 0;

            /*
            //Solucion
            tabPru.Clear();
            tabPru.Add(1);
            tabPru.Add(3);
            tabPru.Add(5);
            tabPru.Add(7);
            tabPru.Add(2);
            tabPru.Add(0);
            tabPru.Add(6);
            tabPru.Add(4);*/
            
            /*
            //Falla 1
            tabPru.Clear();
            tabPru.Add(0);
            tabPru.Add(3);
            tabPru.Add(2);
            tabPru.Add(1);
            tabPru.Add(4);
            tabPru.Add(7);
            tabPru.Add(6);
            tabPru.Add(5);
            */

            /*foreach(int a in tabPru.ElementAt(0))
            {                
                foreach (int b in tabPru.ElementAt(1))
                {
                    for(int i =0; i < 8; i++)
                    {

                    }
                }               
            }*/
            bool band = true;


            for (int i = 0; i < 8 && band; i++)
            {
                r = 0;
                for(int j = 0; j<8 && band; j++)
                {

                    r = 0;
                    if(i!=j)
                    {
                        r = 0;
                        if (tabPru.ElementAt(i)+j == tabPru.ElementAt(j)+i || tabPru.ElementAt(i) - j == tabPru.ElementAt(j) - i)
                        {
                            r = 0;
                            band = false;
                            

                        }
                        //if (tabPru.ElementAt(0).ElementAt(i) != tabPru.ElementAt(0).ElementAt(j)+j && tabPru.ElementAt(1).ElementAt(i) != tabPru.ElementAt(1).ElementAt(i - j)) ;
                    }
                    
                }
            }

            r = 0;


            return band;
        }

        public List<int> creaTablero()
        {
            //List<List<int>> ListTabl = new List<List<int>>();

            Random rnd = new Random();
            List<int> lisCol = new List<int>();
            //List<int> lisRen = new List<int>();

            //RellenaTabl()
            int numCol;
            int numRen;

            while(lisCol.Count!=8)
            {
                numCol = rnd.Next(8);

                if(lisCol.Count == 0)
                {
                    lisCol.Add(numCol);
                }
                else
                    if(!lisCol.Contains(numCol))
                    {
                    lisCol.Add(numCol);
                    }

            }
            //ListTabl.Add(lisCol);

            /*
            while (lisRen.Count != 8)
            {
                numRen = rnd.Next(8);

                if (lisRen.Count == 0)
                {
                    lisRen.Add(numRen);
                }
                else
                    if (!lisRen.Contains(numRen))
                {
                    lisRen.Add(numRen);
                }

            }
            ListTabl.Add(lisRen);*/

            return (lisCol);
        }

        public void creaPaneles(List<int>tab)
        {
            int nBoton = 0; //Almaceno el numero de boton
            for (int i = 0; i <  8; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 0; j < 8; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackColor = Convert.ToInt32(btn.Tag) % 2 == 0 ? Color.White : Color.Black; //Loas ares de un color, los impares de otro
                                                                                                   //por 
                    btn.BackColor = Convert.ToInt32(btn.Tag) % 2 == 0 ? Color.Black : Color.White; //Loas ares de un color, los impares de otro

                    if (j == tab.ElementAt(i))//Aqui poner la ruta a la imagen, la imagen esta en la carpeta "bin\debug" del proyecto  
                        btn.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Reinas.png");
                        
                    panel1.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 100;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            /*int nBoton = 0; //Almaceno el numero de boton
            for (int i = 1; i <= 10; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 10; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 100;
            }*/
        }

        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
