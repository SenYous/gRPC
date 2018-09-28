using Grpc.Core;
using GRPCDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCServer
{
    class gRPCImpl : gRPC.gRPCBase
    {
        // 实现SayHello方法
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override Task<SayHiReply> SayHi(SayHiRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SayHiReply { Message = "Hi " + request.Name });
        }

        public override Task<SayWhat> simpleHello(SayWhat request, ServerCallContext context)
        {
            return Task.FromResult(new SayWhat { Message = "simpleHello " + request.Name, Name = request.Message });
        }
    }
    /// <summary>
    /// 学习博客地址：https://www.cnblogs.com/linezero/p/grpc.html
    /// E:\项目\gRPCDemo>packages\Grpc.Tools.1.14.2\tools\windows_x86\protoc.exe -IgRPCDemo --csharp_out gRPCDemo  gRPCDemo\helloworld.proto --grpc_out gRPCDemo --plugin=protoc-gen-grpc=packages\Grpc.Tools.1.14.2\tools\windows_x86\grpc_csharp_plugin.exe
    /// </summary>
    class Program
    {
        const int Port = 9007;
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { gRPC.BindService(new gRPCImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
