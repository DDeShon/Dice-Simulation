//Damon DeShon
//April 15, 2013
//Dice Simulation program

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DICE_SIMULATION
{
    
    //Initialize the form
    public partial class Form1 : Form   
    {
        List<Dicesim> lstDice = new List<Dicesim>();
        string[] content = new string[100];    
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            
            //Initialize variables
            int[] DiceUno = new int[100];
            int[] DiceDos = new int[100];
            Random rnd = new Random();           
            int counter = 0;

            
            //Code for random number generator to roll two dice
            try        
            {
                for (int i = 0; i < 100; i++)
                {
                    Dicesim dice = new Dicesim();
                    int diceRoll = 0;
                    diceRoll = rnd.Next(6);
                    if (diceRoll == 0)
                    {
                        diceRoll = 6;
                    }
                    dice.Dice1 = diceRoll;
                    DiceUno[i] = diceRoll;

                    diceRoll = rnd.Next(6);
                    if (diceRoll == 0)
                    {
                        diceRoll = 6;
                    }
                    dice.Dice2 = diceRoll;
                    DiceDos[i] = diceRoll;
                    dice.Total = dice.Dice1 + dice.Dice2;
                    lstDice.Add(dice);
                  }
                               
                
                //Write dice results to file
                string DirPath = string.Empty;          
                foreach (Dicesim dice in lstDice)
                {
                    content[counter] = dice.Dice1 + " " + dice.Dice2 + " " + dice.Total;
                    counter = counter + 1;
                }
                DirPath = System.IO.Directory.GetCurrentDirectory() + "\\Dice Totals.txt";
                System.IO.File.WriteAllLines(@DirPath, content);
            }
            catch
            {
                MessageBox.Show("Error Occured");

            }
            
            //Pop up message box to alert the user when 100 dice rolls have been completed
            if (counter == 100)
                        {
                           MessageBox.Show("100 dice rolls have been completed.");
                        }
       

        
          
        }
        
        
        //Initialize button to display data from file
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lstDice;
            
        }


        //Initialize button to clear the data display
        private void button3_Click(object sender, EventArgs e)
        {
            lstDice.Clear();
            Array.Clear(content, 0, 100);
            dataGridView1.DataSource = null;
        }        
    }
}
