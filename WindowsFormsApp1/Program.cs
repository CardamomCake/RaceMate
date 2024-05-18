using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Program
    { 
        public static UdpReceiver Receiver { get; private set; }
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            Receiver = new UdpReceiver();
            var receivingTask = Receiver.StartReceivingAsync();

            // Start the receiver task in the background without blocking the main thread
            _ = Task.Run(async () =>
            {
                await receivingTask;
            });

            // Run the Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}

public class UdpReceiver
{
    private const int RECEIVE_TIMEOUT_MS = 100; // 0.1 seconds
    private const int LOCAL_PORT = 11000;
    private const string LOCAL_IP = "127.0.0.1";
    private volatile string _mostRecentData;

    public string MostRecentData => _mostRecentData;

    public async Task StartReceivingAsync()
    {
        using (UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(LOCAL_IP), LOCAL_PORT)))
        {
            udpClient.Client.ReceiveTimeout = RECEIVE_TIMEOUT_MS;

            while (true)
            {
                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    _mostRecentData = Encoding.ASCII.GetString(result.Buffer); 
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.TimedOut)
                    {
                        Console.WriteLine("Receive operation timed out.");
                    }
                    else
                    {
                        Console.WriteLine("Socket exception: " + ex.Message);
                    }
                }
            }
        }
    }
}
