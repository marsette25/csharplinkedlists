using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
        public SinglyLinkedList()

        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for(var i =0; i< values.Length; i++)
            {
                this.AddLast(values[i] as String);
            }

        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set
            {
                var newList = new SinglyLinkedList();
             

                for (var x = 0; x < this.Count(); x++)
                {
                    if (x == i)
                    {
                        newList.AddLast(value);
                    }
                    else
                    {
                        newList.AddLast(this.ElementAt(x));
                    }
                }
                    first_node = new SinglyLinkedListNode(newList.First());
                    for (var w = 1; w < newList.Count(); w++)
                {
                    this.AddLast(newList.ElementAt(w));

                }
                }
            }
        public void AddAfter(string existingValue, string value)
        {
            
            {
                var node = this.first_node;

                while (node.Value != existingValue && node != null)
                {
                    node = node.Next;
                    if (node == null)
                    {
                        throw new ArgumentException();
                    }

                }

                if (node.IsLast() && node.Value == existingValue)
                {
                    this.AddLast(value);
                    return;  

                }
    
                var newNode = new SinglyLinkedListNode(value);
                newNode.Next = node.Next;
                node.Next = newNode;
            }
        }

        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var newFirstNode = new SinglyLinkedListNode(value); //feeding value of new first node
                //keeping track of rest of the list
                var currentFirstNode = this.first_node;
                //put newfirstnode into first position
                this.first_node = newFirstNode;
                //making a pointer to the rest of everything else
                this.first_node.Next = currentFirstNode;

            }
          
        }

        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            } else
            {
                var node = this.first_node;
                while (!node.IsLast())
                {
                    node = node.Next;   //skips this when it gets to the last  
                }
                node.Next = new SinglyLinkedListNode(value);
            }
     
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            //If the list is empty
            //this.Count == 0
            if (this.First() == null)
            {
                return 0;
            }
            else
            {
                int length = 1;
                var node = this.first_node;
                //Complexity is 0(n)
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }
                return length;
            }

            //Provide a second implementation
        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var node = this.first_node;

                for (var i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        break;
                    }
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            } else
            {
                return this.first_node.Value;
            }
            // return this.first_node ? null : this.first_node.Value;
        }

        public int IndexOf(string value)
        {
            var node = this.first_node;
            int index = -1;

            if (this.First() == null) { return index; }

            for (var i = 0; i < this.Count(); i++)
            {
                if (node.Value == value)
                {
                    index = i;
                    break;
                }
                node = node.Next;
        }
            return index;
        }

        public bool IsSorted()
        {
            var sorted = true;
            var thisNode = this.first_node;
            for (int i = 0; i < this.Count() - 1; i++)
            {
                if (thisNode.CompareTo(thisNode.Next) > 0)
                {
                    sorted = false;
                    break;
                }
                thisNode = thisNode.Next;
            }
            return sorted;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            var node = this.first_node;
            if (node == null)
            {
                return null;
            } else
            //Step1: Do I need to loop?????
            //Step 2: If yes, Do I already have an example of how???
            //Step 3: How can I modify the previous examples?
            //Step 4: Write what I think works.
            // Step 5: rebuid/Rerun tests
            //Step 6: Rinse and repeat

            {
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public void Remove(string value)
        {
            int number = this.IndexOf(value);
            var newList = new SinglyLinkedList();
            for (var i = 0; i < this.Count(); i++)
            {
                if (i != number)
                {
                    newList.AddLast(this.ElementAt(i));
                }
            }
            first_node = new SinglyLinkedListNode(newList.First());
            for (var j = 1; j < newList.Count(); j++)
            {
                this.AddLast(newList.ElementAt(j));
            }
        }

        //insertion sort??? http://www.csharpens.com/2014/02/insertion-sorting-algorithm-in-c-sharp-with-example-code-of-Array.html
        public void Sort()
        {
            while (!this.IsSorted())

                {
                    var node = first_node;
                    var node2 = node.Next;


                    for (int i = 1; i < this.Count(); i++)
                    {
                        if (node.CompareTo(node2) > 0)
                        {
                        var temp = node2.Value;
                        node2.Value = node.Value;
                        node.Value = temp;

                    }

                        node = node.Next;
                        node2 = node.Next;

                    }
                }
            }
        
        
        public string[] ToArray()
        {
           
            string[] newArray = new string[this.Count()];
            string[] emptyArray = new string[] { };
            var node = first_node;

            if (this.Count() == 0) { return emptyArray; }

            else
            {
                for (int i = 0;  i < this.Count(); i++) 
                {
                    newArray[i] = node.Value;
                    node = node.Next;
                }
            }

            return newArray.ToArray();  
           
 }



        public override string ToString()
        {
            StringBuilder MyStringBuilder = new StringBuilder();
            var node = first_node;

            MyStringBuilder.Append("{ ");

            if (this.Count() == 1 || this.Count() == 0)
            {
                while (node != null)
                {

                    MyStringBuilder.Append("\"").Append(node.Value).Append("\" ").ToString();
                    node = node.Next;
                }
                MyStringBuilder.Append('}');
            } else
            {
                while (!node.IsLast())
                {
                    MyStringBuilder.Append("\"").Append(node.Value).Append("\", ").ToString();
                    node = node.Next;
                }
                MyStringBuilder.Append("\"").Append(this.Last()).Append("\" }").ToString();

            }
           // MyStringBuilder.Append('}');
            return MyStringBuilder.ToString();
        }
    }
}


