using System;
using System.IO.Pipes;
using System.Threading;
using System.IO;
class PipeStreamDemo
{
    static void Main()
    {
        var server = new AnonymousPipeServerStream(PipeDirection.Out);
        Thread reader = new Thread(() =>
        {
            using var client = new AnonymousPipeClientStream(PipeDirection.In, server.GetClientHandleAsString());
            using var sr = new StreamReader(client);
            Console.WriteLine(sr.ReadLine());
        });
        reader.Start();
        using StreamWriter sw = new StreamWriter(server) { AutoFlush = true };
        sw.WriteLine("Pipe message");
        reader.Join();
    }
}