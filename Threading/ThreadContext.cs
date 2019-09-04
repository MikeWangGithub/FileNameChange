using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNameChange.Tools;
using System.Threading;

namespace FileNameChange.Threading
{
    /// <summary>
    /// Thread Context Class
    /// Hide ThreadFactory and all of the concrete ThreadClass
    /// </summary>
    public class ThreadContext<T>
    {
        /// <summary>
        /// Thread object
        /// </summary>
        private ParentThread<T> superThread = null;
        /// <summary>
        /// Create conrete thread by ThreadFactory
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <param name="_tokenSource"></param>
        /// <param name="_threadParameter"></param>
        public ThreadContext(FileNameChange.Tools.ThreadName threadName,
                             CancellationTokenSource _tokenSource,
                             ICloneable _threadParameter)
        {
            superThread = ThreadFactory<T>.createThread(threadName,
                                                     _tokenSource,
                                                     _threadParameter);
        }
        /// <summary>
        /// Execute Concrete Class
        /// </summary>
        /// <returns></returns>
        public Task<T> ThreadRun()
        {
            if (superThread != null)
            {
                return superThread.Run();
            }
            else { return null; }
        }
    }
}
