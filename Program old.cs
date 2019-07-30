using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        LinkedList<int> list1 = new LinkedList<int>();
        public void RunProgram()
        {

            Console.Write("\nGenerate List (Y/N) ");
            string i;
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                GenerateList();
                DisplayList();
                }

            //This checks the previous answer as if the user said no this next code is pointless
            if (i == "Y" || i == "y")
            {
                Console.Write("\nClear List (Y/N) ");
                i = Convert.ToString(Console.ReadLine());
                if (i == "Y" || i == "y")
                {
                    ClearList();
                    DisplayList();
                }                
            }
         }

        // --------------------------------------------------- Below This point is the working code, above is calling code below ---------------------------------------------------//
        
        


        public void DisplayList()
        {
            // Display the contents of the LinkedList. 
            if (list1.Count > 0)
            {
                //Console.WriteLine("The first item in the list is {0}.", list1.First.Value);
                //Console.WriteLine("The last item in the list is {0}.", list1.Last.Value);

                Console.WriteLine("\nThe LinkedList contains:");
                foreach (int s in list1)
                    Console.WriteLine("   {0}", s);
            }
            else
            {
                Console.WriteLine("\nThe LinkedList is empty.");
            }
        }



        public void GenerateList()
        {
            // Create and initialize a new LinkedList.
            int i;                        
            Console.Write("\nplease enter what number you would like the list to go up to! ");
            i = Convert.ToInt32(Console.ReadLine());

            
            for (int j = 0; j < i; j++)
            {
                list1.AddLast(j + 1);
            }       
        }


        public void SearchList()
        {
            //int s;
            //Console.Write("Please Enter a number in the array you want to search for  ");
            //s = Convert.ToInt32(Console.ReadLine());          
                
            ////this searchs the array starting at 0 running to sum+1 it reports back whether a number is or is not in the array
            //int k = 0;
            //int sumup = sum + 1;
            //for (k = 0; k < sumup; k++)
            //{
            //    if (linear_search(s, sum, sort))
            //    {
            //        Console.WriteLine(s + " is found in the array");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine(s + " is not found in the array");
            //        break;
            //    }
            //}
        }

        static bool linear_search(int searchvalue, int N, int[] array)
        {
            bool isFound = false;
            int i = 0;

            while (i < N)
            {
                if (searchvalue == array[i])
                {
                    isFound = true;
                    break;
                }
                i++;
            }
            return (isFound);
        }

        public void ClearList()
        {            
            int i = 1;
            while (list1.Count > 0)
            {                
                list1.Remove(i);
                i++;
            }
        }

        //This only serves to start and finish code everything else is sent off to RunProgram
        static void Main(string[] args)
        {


            Program myLinkProgram = new Program();
            myLinkProgram.RunProgram();

            string i = "Y";
            while ( i != "Y" || i != "y")
            {
                Console.Write("\nWould you like to test another function? (Y/N) ");

                i = Convert.ToString(Console.ReadLine());
                if (i == "Y" || i == "y")
                {
                    myLinkProgram.RunProgram();
                }
            }

            Console.WriteLine("\n\n===============================");
            Console.WriteLine("Link List: Press any key to finish");
            Console.ReadKey();
        }
    }
}
