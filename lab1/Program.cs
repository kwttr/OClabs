using System.Threading;

class program
{
    public void FindAverage()
    {
        Interlocked.Exchange(ref average, i);//ref average = ссылка на double average (по идее), i - число (элемент массива) которое будет прибавлено к average. Как это заставить работать?
    }
    public static void Main()
    {
        Console.WriteLine("Введите размер массива");
        string num = Console.ReadLine();
        int[] arr = new int[Int32.Parse(num)];

        //a)Заполнение массива случайными числами
        Random rand = new Random();
        foreach (int i in arr)
        {
            arr[i] = rand.Next(0, 10000000);
        }

        //b)Создание потока worker
        double average = 0;
        Thread worker = new Thread();        //не знаю как подписаться на функцию. пойду спать.
        worker.Start();

        //c)	Найти минимальный и максимальный элементы массива и вывести
        //их на консоль.После каждого сравнения элементов «спать» 7
        //миллисекунд(для этого использовать функцию Sleep(время_в_миллисекундах)).

        int max = arr[0];
        int min = arr[0];
        foreach (int i in arr)
        {
            if (i > max) max = i;
            if (i < min) min = i;
            Thread.Sleep(7);
        }
    }
}