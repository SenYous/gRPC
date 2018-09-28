﻿using Grpc.Core;
using GRPCDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);

            var client = new gRPC.gRPCClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "LineZero" });
            Console.WriteLine("来自" + reply.Message);

            var reply2 = client.SayHi(new SayHiRequest { Name = "CK" });
            Console.WriteLine("来自" + reply2.Message);

            var reply3 = client.simpleHello(new SayWhat { Name = "CK", Message = "成功" });
            Console.WriteLine("来自" + reply3.Message + "---:" + reply3.Name);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}