using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {        
        //I have declared linked lists over LinkedListNode, Lists & arrays because i feel its a simple and elegant way to complete the task, they scale with size so can be increased and decreased when needed.
        LinkedList<int> list1 = new LinkedList<int>();
        LinkedList<int> list2 = new LinkedList<int>();

        //rather then constantly re-create varibles i went though the code taking out redundencies and adding them here so one declaration covers everything.
        string i;
        int n;
        int s;
        public void RunProgram()
        {
            //Because iv laid my code out like this not only does it read well and for someone else to come alter it can follow what each segment does but it allows testing of each individual block of code.
            //i have tried to write this up so it reads very much like english.
            Console.WriteLine("--------- Assignment 2 --------");
            Console.WriteLine("All numbers in the set must be postive integers and not doubles");
            Clear();
            GenerateList();
            DisplayList();
            CopyList();
            SearchList();
            AddItem();
            RemoveItem();            
            CompareList();
            UnionList();
            IntersectList();
            DifferenceList();
            ClearList();                      
         }

        // --------------------------------------------------- Below This point is the working code, above is calling code the below ---------------------------------------------------//
        
        

        //I have done a y/n on all code blocks so you can choose to skip blocks you do not want to load
        //I have not included testing code as the code can self test block by block
        //all code is done in block and broken down to its base levels although this creates more lines of code if this project grows having re-usuable code will save time and speed things up
        //i have not done a check on capacity as a linkedlist can take any number of items
        //I have added 0 to everything that would be converted to an integer, if i hadnt done this it would cause an error and this is a harmless solution

        //This block generates the 2 lists used in the rest off the project
        //To get a good mix of numbers in the set i ask for a size (s) and a value to start from (n)
        public void GenerateList()
        {
            Console.Write("\nGenerate List (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Generate();
            }
        }
        public void Generate()
        {
            List1();
            Console.WriteLine("\n");
            List2();
        }

        public void List1()
        {
            // Create and initialize a new LinkedList.                      
            Console.Write("What Number would you like to start from? ");
            n = Convert.ToInt32(0 + Console.ReadLine());
            if (Error(n, list1) == false)
            {
                Console.WriteLine("\nYou cannot start from that number please pick again");
                List1();
            }
            else
            {
                Console.Write("How large is your first list? ");
                s = Convert.ToInt32(0 + Console.ReadLine());
                for (int j = 0; j < s; j++)
                {
                    list1.AddLast(j + n);
                }
            }
        }

        public void List2()
        {
            // Create and initialize a new LinkedList.                      
            Console.Write("What Number would you like to start from? ");
            n = Convert.ToInt32(0 + Console.ReadLine());
            if (Error(n, list2) == false)
            {
                Console.WriteLine("\nYou cannot start from that number please pick again");
                List2();
            }
            else
            {
                Console.Write("How large is your Second list? ");
                s = Convert.ToInt32(0 + Console.ReadLine());
                for (int j = 0; j < s; j++)
                {
                    list2.AddLast(j + n);
                }
            }
        }

        //This block displays the contents of the list, i can either display one or both lists by default it will display both but i have re-used some of the code to display either of the lists.
        //i use a foreach loop which uses s to cycle though each value in the list then output that for the user to see.
        public void DisplayList()
        {
            Console.Write("\nDisplay List (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                DisplayList1();
                DisplayList2();
            }
        }

        public void DisplayList1()
        {
            // Display the contents of the LinkedList. 
            Console.WriteLine("\n------ Link List 1 Contains ------");
            if (list1.Count > 0)
            {
                foreach (int s in list1)
                    Console.WriteLine("   {0}", s);
            }
            else
            {
                Console.WriteLine("\nThe LinkedList is empty.");
            }
        }

        public void DisplayList2()
        {
            // Display the contents of the LinkedList.
            Console.WriteLine("\n------ Link List 2 Contains ------");

            if (list1.Count > 0)
            {
                foreach (int s in list2)
                    Console.WriteLine("   {0}", s);
            }
            else
            {
                Console.WriteLine("\nThe LinkedList is empty.");
            }
        }

        //Both add and remove item work very similar so would consider this as one block rather then 2 seperate blocks
        //it works very simply by asking the user for a number thats either in the list or not in the list then respectivly adding or removing it.
        public void AddItem()
        {
            Console.Write("\nAdd item to List 1? (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Add();
                DisplayList1();
                Console.Write("\nWould you like to Add another? (Y/N)");
                i = Convert.ToString(Console.ReadLine());
                if (i == "Y" || i == "y")
                {
                    AddItem();
                }
            }
        }

        public void Add()
        {
            Console.Write("What number would you like to add to the list? ");
            n = Convert.ToInt32(0 + Console.ReadLine());
            if (Error(n, list1) == false)
            {
                Console.WriteLine("\nThat is an invalid number please try again");
                Add();
            }
            else
            {
                list1.AddLast(n);
            }
        }

        public void RemoveItem()
        {
            Console.Write("\nRemove Item from List 1? (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Remove();
                DisplayList1();
                Console.Write("\nWould you like to remove another? (Y/N)");
                i = Convert.ToString(Console.ReadLine());
                if (i == "Y" || i == "y")
                {
                    RemoveItem();
                }
            }
        }

        public void Remove()
        {
            Console.Write("What number would you like to remove from the list? ");
            n = Convert.ToInt32(0 + Console.ReadLine());
            list1.Remove(n);
        }


        //In this block it deals with copying list 1 onto list 2.
        //Before i copy any values i clear list 2.
        public void CopyList()
        {
            Console.Write("\nCopy First List into Second List? (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                ClearList2();
                Copy();
                DisplayList2();
            }
        }

        public void Copy()
        {
            foreach (int s in list1)
                list2.AddLast(s);                          
        }


        //This block deals with comparing the 2 lists and confirming if they match or do not match.
        public void CompareList()
        {
            Console.Write("\nWould you like to compare List 1 & 2 (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Compare();
            }
        }
        public void Compare()
        {
            if (list1.SequenceEqual(list2))
            {
                Console.WriteLine("Both Lists Match");
            }
            else
            {
                Console.WriteLine("Not a Match");
            }
        }

        //This block deals with showing the union between the 2 lists.
        public void UnionList()
        {
            Console.Write("\nWould you like to Union List 1 & 2 (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
            Union();
            }
        }

        public void Union()
        {            
            IEnumerable<int> union = list1.Union(list2);
            
            foreach (int num in union)
            {
                Console.WriteLine("{0} ", num);
            }
        }

        //This block deals with showing the intersection between the 2 lists.
        public void IntersectList()
        {
            Console.Write("\nWould you like to Intersect List 1 & 2 (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Intersect();
            }
        }

        public void Intersect()
        {
            IEnumerable<int> Intersect = list1.Intersect(list2);

            foreach (int num in Intersect)
            {
                Console.WriteLine("{0} ", num);
            }
        }

        //This block deals with showing the difference between the 2 lists, i have shown the differences seperate at first but to show them as a union i simply brought them together. I have not to c core for this.
        public void DifferenceList()
        {
            Console.Write("\nWould you like the Differences in List 1 & 2 (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Difference();
            }
        }


        public void Difference()
        {
            Console.WriteLine("\nWhats Not in list 2");
            DiffList1();

            Console.WriteLine("\nWhats Not in list 1");
            DiffList2();

            Console.WriteLine("\nThe Union of the differences in List 1 & 2");
            DiffList1();
            DiffList2();
        }

        public void DiffList1()
        {
            IEnumerable<int> Except = list1.Except(list2);

            foreach (int num in Except)
            {
                Console.WriteLine("{0} ", num);
            }
        }

        public void DiffList2()
        {
            IEnumerable<int> Except2 = list2.Except(list1);

            foreach (int num in Except2)
            {
                Console.WriteLine("{0} ", num);
            }
        }
     
        //I opted to only allow the search function to work with the first list unlike other functions which i originally wrote for both. 
        //The reason i did this is more often then not the second list is a sub set of the first.
        //I originally attempted to apply the linear search function from assignment 1, but after i had trouble 
        public void SearchList()
        {   
            Console.Write("\nSearch List (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Search();
            }
        }

        public void Search()
        {
            int k;
            bool found = false;
            Console.Write("Please Enter a number want to search for  ");
            k = Convert.ToInt32(Console.ReadLine());
            foreach (int s in list1)
                if (s == k)
                {
                    Console.WriteLine("{0} Is in the list", k);
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }

            if (found == false)
            {
                Console.WriteLine("Your Value has not been found in the list");
            }
        }


        //This block deals with clearing the list
        //it works by using list.count, i use a loop and keep going until the count is 0
        //it removes the items by using list.remove() which when you put in a value it removes the first instance of that value it finds
        //to completely clear it the value i always use until the list is empty is the first value in the list
        public void ClearList()
        {    
            Console.Write("\nClear List (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            if (i == "Y" || i == "y")
            {
                Clear();
                DisplayList1();
                DisplayList2();  
            }
        }

        public void Clear()
        {
            ClearList1();
            ClearList2();
        }

        public void ClearList1()
        {
            while (list1.Count > 0)
            {
                list1.Remove(list1.First.Value);
            }
        }

        public void ClearList2()
        {
            while (list2.Count > 0)
            {
                list2.Remove(list2.First.Value);
            }
        }

        //This is an error check to ensure no doubles or negative numbers can be inputted into the set ensuring every set is always valid
        public bool Error(int CheckValue, LinkedList<int> List)
        {
            bool isFound = false;

            if (CheckValue > 0)
            {
                isFound = true;
                foreach (int s in List)
                    if (s == CheckValue)
                    {
                        isFound = false;
                        break;
                    }
                    else
                    {
                        isFound = true;
                    }
            }
            else
            {
                isFound = false;
            }
            return (isFound);
        }

        //This only serves to start and finish code everything else is sent off to RunProgram
        static void Main(string[] args)
        {
            string i;
            Program myLinkProgram = new Program();
            myLinkProgram.RunProgram();
            Console.Write("\nWould you like to test another function? (Y/N) ");
            i = Convert.ToString(Console.ReadLine());
            while ( i == "Y" || i == "y")
            {                                
                if (i == "Y" || i == "y")
                {                    
                    myLinkProgram.RunProgram();
                    Console.Write("\nWould you like to test another function? (Y/N) ");
                    i = Convert.ToString(Console.ReadLine());
                }
            }
            Console.WriteLine("\n\n===============================");
            Console.WriteLine("Link List: Press any key to finish");
            Console.ReadKey();
        }
    }
}
