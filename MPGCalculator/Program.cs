using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace MPGCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionSelector actionSelector = new ActionSelector();
            actionSelector.CreateList();
            actionSelector.GetSelectedOption();
        }
    }  
}
