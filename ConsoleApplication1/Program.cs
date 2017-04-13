using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Node
    {
        public static int sum = 1;
        public int data;
        public Node next;

        //constructor
        public Node(int input)
        {
            this.data = input;
            this.next = null; 
        }

        //methods
        //add data to end
        public void AddToEnd(int input)
        {

            //first check are we at the end of the nodes
            if (next == null)
            {
                //we are at the end so next gets a new Node containing our data
                next = new Node(input);
            }
            //if there are more nodes 
            //call our method again (RECURSION) passing in the next node
            else
            {

                next.AddToEnd(input);
            }

        }

        //this method will print a node
        public void PrintNode()
        {
            Console.Write("|" + data + "|-> ");
            //check if the next node is not null and print 
            //each node prints the next node if it contains a value
            //use of RECURSION 
            if(next != null)
            {
                next.PrintNode();
            }

        }

        public void CountNodes()
        {
            if(next != null)
            {
                sum++;
                next.CountNodes();
            }

            Console.WriteLine(sum);
            
            
        }
    }

    public class MyLinkedList
    {
        // a referenece to the first node
        public Node headNode;
        //constructor
        public MyLinkedList()
        {
            //remember we check for null to identify the next available node
            //so initially our list contains a node set to null
            headNode = null;

        }
        //methods
        //add data to end
        public void AddToEnd(int data)
        {
            if(headNode == null)
            {
                //if headNode is null create a new node
                headNode = new Node(data);
            }
            else
            {
                //if headnode has another node
                //call the addtoEnd Method in the node class
                headNode.AddToEnd(data);
            }    
        }

        //add data to beginning
        public void AddToBeginning(int data)
        {
            if (headNode == null)
            {
                //if headNode is null create a new node
                headNode = new Node(data);
            }
            else
            {
                //if headnode has another node
                //create a temp node to hold the data
                Node tempNode = new Node(data);
                //this in effect places tempnode before headnode (at the beginning)
                tempNode.next = headNode;
                headNode = tempNode;
                
            }
        }

        //method to print list
        //check if headNOde is not null if so 
        //call the print node method from the node class
        public void PrintMyLinkedList()
        {
            if (headNode != null)
            {            
                headNode.PrintNode();
            }

        }

        //method to print list
        //check if headNOde is not null if so 
        //call the print node method from the node class
        public int CountMyNodes()
        {

            int count = 1;
            if (headNode == null)
            {
                Console.WriteLine("This list is empty! ");
            }
            else
            {

                //here we use the count method in the Node class
                //beware because of recursion the count int is static
                //and incremental. i.e. the method only works once
                //the alternative below is much better
                //headNode.CountNodes();

                //alternative + Better

                //store a copy of the headnode in temp Node
                Node temp = headNode;

                //check that next is not null and increment count
                while(temp.next != null)
                {
                    count++;

                    //assign temp.next to temp and move along the list
                    temp = temp.next;
                }
                
                
            }
            return count;

        }


    }
       

   
    class Program
    {
        static void Main(string[] args)
        {
        //simple way to add new nodes
            //Node myNode = new Node(1);
            //myNode.next = new Node(2);
            //myNode.next.next = new Node(3);
            //myNode.next.next.next = new Node(4);
            //myNode.next.next.next.next = new Node(5);

           
            ////calling our method to add a node to the end of the nodes
            //myNode.AddToEnd(6);
            //myNode.AddToEnd(6);



            MyLinkedList myList = new MyLinkedList();
            myList.AddToEnd(1);
            myList.AddToEnd(2);
            myList.AddToEnd(3);
            myList.AddToEnd(4);
            myList.AddToEnd(5);
            myList.AddToEnd(6);
            myList.AddToEnd(7);
            myList.AddToEnd(8);
            //myList.PrintMyLinkedList();
            myList.AddToBeginning(15);
            myList.PrintMyLinkedList();
            Console.WriteLine();
            Console.WriteLine(  "There are: " + myList.CountMyNodes() + " nodes in this list");
            Console.ReadLine();













        }
    }
}
