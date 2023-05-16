using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Probability
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of numbers");
        int size = Convert.ToInt32(Console.ReadLine());
        double[] arr = new double[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("Number " + (i+1) + " :");
            arr[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        // الترتيب
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (arr[j] < arr[i])
                {
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        int n = 1;
         int max = 1;
        int max2;

        double median = 0;  //الوسيط  
        double mode = arr[0]; //المنوال 

        //المنوال
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                n++;
            }

            else
            {
                if (n > max)
                {
                    
                    max = n;
                    mode = arr[i - 1];
                }
               
                n = 1;
                

            }



        }
        //1,2,3,4,5,6,7
        //1,2,3,4,5,6,7,8
        //الوسيط

        if (size % 2 == 0)
            median = (arr[size / 2 - 1] + arr[size / 2]) / 2;

        if (size % 2 != 0)
            median = arr[(size / 2)];

        //range
        double max_value = arr[size - 1];
        double min_value = arr[0];
        double range = max_value - min_value;

        double q1, q3, iq;
        if((size/2) % 2 != 0)
        {
            if (size % 2 == 0)
            {
                q1 = arr[(size + 1) / 4];
            }
            else
            {
                q1 = arr[((size + 1) / 4) - 1];
            }
            //if(size/2 != 0)
            q3 = arr[(3 * (size + 1) / 4) - 1];
        }
        else
        {
            if (size % 2 == 0)
            {
                q1 = (arr[((size + 1) / 4) -1] + arr[(size+1) / 4]) / 2;
            }
            else
            {
                q1 = (arr[((size + 1) / 4) - 1] + arr[(size + 1) / 4]) / 2;
            }
            q3 = (arr[(3 * (size + 1) / 4) - 1] + arr[3*(size + 1)/4]) / 2 ;
        }
        
        
        
        iq = q3 - q1;
        double upper_fence = q3 + 1.5 * iq;
        double lower_fance = q1 - 1.5 * iq;



        int index = (int)Math.Ceiling(arr.Length * 0.9) - 1;
        double p90 = arr[index];
        bool is_outlier = false;

        
        void show_details()
        {
            Console.WriteLine("Median : " + median);

            if (max == 1)
            {
                Console.WriteLine("Mode: no mode ");
            }
            else
              Console.WriteLine("Mode : " + mode);
            
            Console.WriteLine("Range : " + range);
            Console.WriteLine("First quaritle : " + q1);
            Console.WriteLine("Third quaritle : " + q3);
            Console.WriteLine("p90 : " + p90);
            Console.WriteLine("Interquartile : " + iq);
            Console.WriteLine("Upper fence : " + upper_fence);
            Console.WriteLine("Lower fence : " + lower_fance);
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > upper_fence || arr[i] < lower_fance)
                {
                    is_outlier = true;
                }
                Console.WriteLine(arr[i] + "   ,Outlier : " + is_outlier);

                is_outlier=false;

            }
            

        }
        show_details();
        }


    
    }

     




