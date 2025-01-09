using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LSL;

namespace monitor
{
    public class monitor_avi
    {
        
        public string meramethod(string s)
        {
            string var = MonitoringLibrary.GetServiceUsageMetrics(s);
            return var;
        }        
        public string meramethod4(string s)
        {
            string var = MonitoringLibrary.StartMonitoringService(s);
            return var;
        }        
        public string meramethod3(string s)
        {
            string var = MonitoringLibrary.GetServicePerformanceMetrics(s);
            return var;
        }
        public int meramethod2()
        {
            return 0;
        }
    }
}
