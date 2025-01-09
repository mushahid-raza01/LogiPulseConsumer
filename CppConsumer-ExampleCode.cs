using System;
using System.Runtime.InteropServices;
using System.Threading; // Required for Thread.Sleep

namespace LSL
{
    public static class MonitoringLibrary
    {
        // Set the path to your DLL
        private const string DllPath = @"D:\AIThon\MonitoringLibrary\x64\Release\MonitoringLibrary.dll";

        // Import the functions from the DLL
        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr getServiceUsageMetrics(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr getServicePerformanceMetrics(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr getServiceReliabilityMetrics(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr getAPIReliabilityMetricsAndUsage(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr getAPIPerformanceMetrics(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr startMonitoringService(string serviceName);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stopMonitoringService(string serviceName);

        // Helper method to convert IntPtr to string
        private static string GetStringFromPtr(IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        // Public methods for calling the C++ functions
        public static string GetServiceUsageMetrics(string serviceName)
        {
            return GetStringFromPtr(getServiceUsageMetrics(serviceName));
        }

        public static string GetServicePerformanceMetrics(string serviceName)
        {
            return GetStringFromPtr(getServicePerformanceMetrics(serviceName));
        }

        public static string GetServiceReliabilityMetrics(string serviceName)
        {
            return GetStringFromPtr(getServiceReliabilityMetrics(serviceName));
        }

        public static string GetAPIReliabilityMetricsAndUsage(string serviceName)
        {
            return GetStringFromPtr(getAPIReliabilityMetricsAndUsage(serviceName));
        }

        public static string GetAPIPerformanceMetrics(string serviceName)
        {
            return GetStringFromPtr(getAPIPerformanceMetrics(serviceName));
        }

        public static string StartMonitoringService(string serviceName)
        {
            return GetStringFromPtr(startMonitoringService(serviceName));
        }

        public static string StopMonitoringService(string serviceName)
        {
            return GetStringFromPtr(stopMonitoringService(serviceName));
        }
    }

    class Program
    {
        // Wrapper for the MonitoringLibrary.dll
   
        // Main Program Entry
        static void Main()
        {
            try
            {
                string dllDirectory = @"D:\AIThon\MonitoringLibrary\x64\Release";
                Environment.CurrentDirectory = dllDirectory; // Set working directory for the DLL

                string serviceName = "W32Time";

                // Call methods from the wrapper
                string usageMetrics = MonitoringLibrary.GetServiceUsageMetrics(serviceName);
                string performanceMetrics = MonitoringLibrary.GetServicePerformanceMetrics(serviceName);
                string reliabilityMetrics = MonitoringLibrary.GetServiceReliabilityMetrics(serviceName);
                string apiName = "/api/Security/GetAllEquitiesForToday";
                string apiUsageMetrics = MonitoringLibrary.GetAPIReliabilityMetricsAndUsage(apiName);
                string apiPerformanceMetrics = MonitoringLibrary.GetAPIPerformanceMetrics(apiName);


                // Print the results
                Console.WriteLine($"Service Usage Metrics: {usageMetrics}");
                Console.WriteLine($"Service Performance Metrics: {performanceMetrics}");
                Console.WriteLine($"API Usage Metrics: {apiUsageMetrics}");
                Console.WriteLine($"Service Reliability Metrics: {reliabilityMetrics}");
                Console.WriteLine($"API Performance Metrics: {apiPerformanceMetrics}");


                Thread monitoringThread = new Thread(() =>
                {
                    Console.WriteLine($"Starting Monitoring: {serviceName}");
                    string startServiceMonitor = MonitoringLibrary.StartMonitoringService(serviceName);
                });

                // Start the thread
                monitoringThread.Start();

                Thread.Sleep(10000);
                string stopServiceMonitor = MonitoringLibrary.StopMonitoringService(serviceName);
                // Optionally, wait for the thread to complete (if needed)
                monitoringThread.Join();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }


}
