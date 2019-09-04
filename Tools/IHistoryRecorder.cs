using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNameChange.GlobalObject;

namespace FileNameChange.Tools
{
    public interface IHistoryRecorder
    {
        /// <summary>
        /// Get Recorder's filename / database tablename/....
        /// </summary>
        string RecorderStoredName { get; }
        /// <summary>
        /// Set Recorder's filename / database tablename/....
        /// </summary>
        /// <param name="value"></param>
        void SetRecorderStoredName(string value);

        /// <summary>
        /// Record a message to a file/table/cloudy/....
        /// </summary>
        bool Record(string value);

        /// <summary>
        /// Record a message to a file/table/cloudy/....
        /// </summary>
        bool Record(IEnumerable<string> value);

        void Initial();
        void Open();
        void Close();


    }
}
