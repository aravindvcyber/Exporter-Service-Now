using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exporter_Service_Now
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exporter started successfully");
            // Call to DownloadFile method supplying the URL and location to save CSV file locally
            string ToDownload = "";
            Console.WriteLine("Please enter the download file url : ");
            ToDownload = Console.ReadLine();
            int read = DownloadFile(ToDownload, @"d:\ps\test\Report.xls");
            Console.WriteLine("Exporter ended successfully ");
        }
        public static int DownloadFile(String url,
                                       String localFilename)
        {
            // Function will return the number of bytes processed
            // to the caller. Initialize to 0 here.
            int bytesProcessed = 0;
            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;
            // Use a try/catch/finally block as both the WebRequest and Stream
            // classes throw exceptions upon error
            try
            {
                // Create a request for the specified remote file name
                WebRequest request = WebRequest.Create(url);
                // Create the credentials required for Basic Authentication
                string login = "";
                string pass = "";
                Console.WriteLine("Please enter your service-now login id : ");
                login = Console.ReadLine();
                Console.WriteLine("Please enter your service-now login password : ");
                pass = Console.ReadLine();
                System.Net.ICredentials cred = new System.Net.NetworkCredential(login, pass);
                // Add the credentials to the request
                request.Credentials = cred;
                if (request != null)
                {
                    // Send the request to the server and retrieve the
                    // WebResponse object 
                    response = request.GetResponse();
                    if (response != null)
                    {
                        // Once the WebResponse object has been retrieved,
                        // get the stream object associated with the response's data
                        remoteStream = response.GetResponseStream();
                        // Create the local file
                        localStream = File.Create(localFilename);
                        // Allocate a 1k buffer
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        // Simple do/while loop to read from stream until
                        // no bytes are returned
                        do
                        {
                            // Read data (up to 1k) from the stream
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                            // Write the data to the local file
                            localStream.Write(buffer, 0, bytesRead);
                            // Increment total bytes processed
                            bytesProcessed += bytesRead;
                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
            // Return total bytes processed to caller.
            return bytesProcessed;
        }
    }
}
