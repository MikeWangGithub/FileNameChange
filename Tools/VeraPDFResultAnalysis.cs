using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileNameChange.Tools
{
    public class VeraPDFResultAnalysis
    {
        private static object XMLLock=new object();
        public static bool ValidatePDF(string filefullpath)
        {
            lock (XMLLock)
            {
                if (!System.IO.File.Exists(filefullpath)) {
                    return false;
                }
                int failNumber = -1;
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(filefullpath);
                string LayerName = "/report/batchSummary/validationReports";//read a certain node
                XmlNode xmlNode = xmldoc.SelectSingleNode(LayerName);
                    
                try
                {
                    failNumber = System.Convert.ToInt32(xmlNode.Attributes["nonCompliant"].Value);
                }
                catch
                {

                }
                
                return (failNumber == 0);

            }
            
        }
    }
}
