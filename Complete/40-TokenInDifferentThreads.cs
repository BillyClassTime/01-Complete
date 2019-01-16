using System; using System.Threading.Tasks; using System.Threading;
namespace _01_Complete {
    class myTokenInDifferentThreads {
        public static void Main()   {
            Console.WriteLine("Token in different threads");
            var tokenSource = new CancellationTokenSource();
            var task = Task.Factory.StartNew<int>(() => RunTimer(tokenSource.Token));
            Console.WriteLine("Press [Enter] to stop the thimer.");
            Console.ReadLine();
            tokenSource.Cancel();
            //tokenSource.Token.Register(() => tokenSource.Cancel());
            //tokenSource.Dispose();
            //tokenSource.IsCancellationRequested = true; //Property or indexer 'CancellationTokenSource.IsCancellationRequested' cannot be assigned to -- it is read only	
            Console.WriteLine("Timer stopped at {0}", task.GetAwaiter().GetResult());
            Console.ReadLine();
        }
        static int RunTimer(CancellationToken cancellationToken)        {
            var time = 0;
            while (!cancellationToken.IsCancellationRequested)
                time++;
            return time;
        }
    }
}
