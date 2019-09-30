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
    /// Create different concrete thread by different ThreadName
    /// </summary>
    public class ThreadFactory<T>
    {
        /// <summary>
        /// Create different concrete thread by different ThreadName
        /// </summary>
        public static ParentThread<T> createThread(FileNameChange.Tools.ThreadName threadName, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            ParentThread<T> thread = null;
            switch (threadName)
            {
                case ThreadName.ChangeFileName:
                    thread = new ThreadChangeFileName<T>(_tokenSource, _threadParameter);
                    break;
                case ThreadName.CheckName:
                    thread = new ThreadCheckName<T>(_tokenSource, _threadParameter);
                    break;
                case ThreadName.Traverse:
                    thread = new ThreadTraverse<T>(_tokenSource, _threadParameter);
                    break;
                default:
                    break;
            }
            return thread;
        }
    }
}
