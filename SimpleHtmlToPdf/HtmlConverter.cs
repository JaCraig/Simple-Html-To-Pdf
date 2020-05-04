using SimpleHtmlToPdf.BaseClasses;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.UnmanagedHandler;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleHtmlToPdf
{
    /// <summary>
    /// Html converter
    /// </summary>
    /// <seealso cref="SimpleHtmlToPdf.BaseClasses.ConverterBaseClass"/>
    public class HtmlConverter : ConverterBaseClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlConverter"/> class.
        /// </summary>
        /// <param name="bindingWrapper">The binding wrapper.</param>
        public HtmlConverter(BindingWrapper bindingWrapper)
            : base(bindingWrapper)
        {
        }

        /// <summary>
        /// The conversions
        /// </summary>
        private readonly BlockingCollection<Task> conversions = new BlockingCollection<Task>();

        /// <summary>
        /// The start lock
        /// </summary>
        private readonly object startLock = new object();

        /// <summary>
        /// The conversion thread
        /// </summary>
        private Thread conversionThread;

        /// <summary>
        /// The kill
        /// </summary>
        private bool kill = false;

        /// <summary>
        /// Converts the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>The document as a PDF byte array.</returns>
        public override byte[] Convert(IDocument document)
        {
            return Invoke(() => base.Convert(document));
        }

        /// <summary>
        /// Invokes the specified @delegate.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="delegate">The @delegate.</param>
        /// <returns></returns>
        public TResult Invoke<TResult>(Func<TResult> @delegate)
        {
            StartThread();

            Task<TResult> task = new Task<TResult>(@delegate);

            lock (task)
            {
                //add task to blocking collection
                conversions.Add(task);

                //wait for task to be processed by conversion thread
                Monitor.Wait(task);
            }

            //throw exception that happened during conversion
            if (!(task.Exception is null))
            {
                throw task.Exception;
            }

            return task.Result;
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        private void Run()
        {
            while (!kill)
            {
                //get next conversion taks from blocking collection
                Task task = conversions.Take();

                lock (task)
                {
                    //run taks on thread that called RunSynchronously method
                    task.RunSynchronously();

                    //notify caller thread that task is completed
                    Monitor.Pulse(task);
                }
            }
        }

        /// <summary>
        /// Starts the thread.
        /// </summary>
        private void StartThread()
        {
            lock (startLock)
            {
                if (conversionThread is null)
                {
                    conversionThread = new Thread(Run)
                    {
                        IsBackground = true,
                        Name = "wkhtmltopdf worker thread"
                    };

                    kill = false;

                    conversionThread.Start();
                }
            }
        }
    }
}