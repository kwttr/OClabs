using System.Threading;

class program
{

    static void FindAverage(object argument)
    {
        int[] arr = (int[])argument;
        int average = 0;
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
        double average = 0;
        ref double avgRef = ref average;
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
        foreach (int i in arr)
        {
            arr[i] = rand.Next(0, 10000000);
            Console.WriteLine(arr[i]);
        }
        ref int[] arrRef = ref arr;
        //b)Создание потока worker
        ParameterizedThreadStart workerThread = new ParameterizedThreadStart(FindAverage);
        Thread worker = new Thread(workerThread);
        worker.Start(arrRef);

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
        //?????

        //e)	Подсчитать количество элементов в массиве, значение которых
        //больше среднего значения элементов массива, и вывести его на

    }
}