using System.Threading;
class program
{
    static double average = 0;
    static void FindAverage(object argument)
    {
        var arr = argument as int[];
        foreach (int r in arr)
        {
            Console.WriteLine($"i - {r}");
            average = average + r;
            Thread.Sleep(12);
        }
        average = average / arr.Length;
        Console.WriteLine("среднее значение:" + average);
    }

    static void Main()
    {
        //объявление переменных
        int max = 0,min = 0;
        bool key = true;
        int[] arr=null;
        //Ввод размера массива
        Console.WriteLine("Введите размер массива");
        while (key == true)
        {
            try
            {
                string num = Console.ReadLine();
                arr = new int[Int32.Parse(num)];
                key = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Неправильный ввод, введите еще раз");
                key = true;
            }
        }

        //a)Заполнение массива случайными числами
        Random rand = new Random();
        for (int i = 0; i<arr.Length; i++)
        {
            arr[i] = rand.Next(0, 10000000);
            Console.WriteLine(arr[i]);
        }

        //b)Создание потока worker
        ParameterizedThreadStart workerThread = new ParameterizedThreadStart(FindAverage);
        Thread worker = new Thread(workerThread);
        worker.Start(arr);

        //c)	Найти минимальный и максимальный элементы массива и вывести
        //их на консоль.После каждого сравнения элементов «спать» 7
        //миллисекунд(для этого использовать функцию Sleep(время_в_миллисекундах)).
        max = arr[0];
        min = arr[0];
        foreach (int i in arr)
        {
            if (i > max) max = i;
            if (i < min) min = i;
            Thread.Sleep(7);
        }

        //d)Дождаться завершения worker
        worker.Join();
        Console.WriteLine(average);

        //e)	Подсчитать количество элементов в массиве, значение которых
        //больше среднего значения элементов массива, и вывести его на консоль.
        int counter = 0;
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > average) counter++;
        }
        Console.WriteLine("Кол-во значений в массиве больше среднего: "+counter);
    }
}