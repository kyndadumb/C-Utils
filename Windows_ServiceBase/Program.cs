using System.ServiceProcess;

namespace Windows_ServiceBase
{
    class Program : ServiceBase
    {

        // Variablen
        private Thread worker = null;
        private Boolean force_exit = false;
        private static Boolean debug = false;


        // Dienst: OnStart
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            worker = new Thread(new ThreadStart(WorkerThread));
            worker.Start();
        }

        // Dienst: OnStop
        protected override void OnStop()
        {
            base.OnStop();

            force_exit = true;
            while (worker.IsAlive) Thread.Sleep(100);
        }

        static void Main(string[] args)
        {
            // if - args == debug
            if (args.Length == 1 && args[0].ToLower().Equals("debug"))
            {
                debug = true;
            }

#if DEBUG
            debug = true;
#endif

            if (debug)
            {

                // Hinweis-Ausgabe
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hinweis: zum Beenden <ENTER> drücken");
                Console.ForegroundColor = ConsoleColor.White;


                // WorkerThread im Debug-Modus starten
                Program p = new();
                p.OnStart(null);

                // Thread-Abbruch
                Console.ReadLine();
                p.OnStop();
            }

            else
            {
                ServiceBase[] services = new[] { new Program() };
                Run(services);
            }
        }

        // WorkerThread
        private void WorkerThread()
        {
            // Variablen
            int akt_min = -1;

            do
            {
                // neue Minute?
                if (DateTime.Now.Minute != akt_min)
                {
                    // Dienst ausführen
                    Console.WriteLine($"[{DateTime.Now}] Läuft!");

                    // GC aufrufen
                    Tools.GarbageCollector();

                    // aktuelle Minute setzen
                    akt_min = DateTime.Now.Minute;
                
                } // if - neue Minute

                // Thread für 1 Sekunde pausieren
                worker.Join(1000);

            } while (!force_exit);
        }
    }
}