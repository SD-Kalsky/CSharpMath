namespace Static;

class DRV
{
    protected double[] values = new double [1];
    protected decimal[] probabilities = new decimal [1];
    protected int number=1;
    public double accuracy = 0.0001; //Default - 0.0001

    public bool checkingDRV(int n, double[,] arr)
    {
        bool b = true;
        int i = 0;
        double sum = 0;
        while(( i < number ) && ( sum < 1 ))
        {
            sum +=  arr[1, i];
            i++;
        }
        if ( Math.Abs(sum) - 1 > this.accuracy ) b=false;
        GC.Collect();
        GC.WaitForPendingFinalizers();   
        return b;
    }

    public void exepProbSum(int n, double[,] arr) 
    {
        int i = 0;
        double sum = 0;
        try
        {
            while(( i < number ) || ( sum < 1 ))
            {
                sum +=  arr[1, i];
                i++;
            }
            if ( Math.Abs(sum) - 1 > this.accuracy ) throw new Exception($"The DRV probability sum is not equal to 1 ");  
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();   
    }
// This must have checking
    // public void inputDRV()
    // {
    //     Console.WriteLine("Укажите число элементов ");
    //     this.number = Convert.ToInt32(Console.ReadLine());
    //     int i=0;
    //     this.values =  new double[number];
    //     this.probabilities =  new decimal[number];
    //     while( i < number )
    //     {
    //         Console.WriteLine("Введите элемент ");
    //         this.values[i] = Convert.ToDouble(Console.ReadLine());
    //         Console.WriteLine("Введите вероятность ");
    //         this.probabilities[i] = Convert.ToDecimal(Console.ReadLine());
    //         i++;
    //     }
    //     GC.Collect();
    //     GC.WaitForPendingFinalizers();   
    // }

    public void setDRV(int n, double[,] arr)
    {
        this.number = n;
        int i = 0;
        
        this.values = new double[number];
        this.probabilities =  new decimal[number];
        try
        {
            if (this.checkingDRV(n, arr ))
                while( i < this.number )
                {
                    this.values[i] = arr[0,i];
                    this.probabilities[i] =  Convert.ToDecimal(arr[1,i]);
                    i++;
                }
            else throw new Exception($"The DRV probability sum is not equal to 1 ");  
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();    
    }
    public double ExpectedValue()
    {
        double ev=0;
        int i=0;
        while( i < this.number )
        {
            ev += ( this.values[i] * Convert.ToDouble(this.probabilities[i]));
            i++;
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        return ev;
    }
    public double Variance()
    {
        double v=0;
        double ev = 0;
        int i=0;
        while( i < this.number )
        {
            v += ( this.values[i] * this.values[i] * Convert.ToDouble(this.probabilities[i]));
            ev += ( this.values[i] * Convert.ToDouble(this.probabilities[i]));
            i++;
        }
        v -= (ev * ev);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        return v;
    }
};

