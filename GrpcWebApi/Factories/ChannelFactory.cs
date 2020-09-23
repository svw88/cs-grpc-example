using Grpc.Core;
using Grpc.Net.Client;
using GrpcProtos.Client;
using System;

namespace GrpcWebApi.Factories
{
    public class ChannelFactory<T> :IDisposable where T: ClientBase<T>
    {
        private readonly GrpcChannel _grpcChannel;

        public ChannelFactory(string address)
        {
            _grpcChannel = GrpcChannel.ForAddress(address);
        }
       public T CreateChannel()
        {

            return new Greeter.GreeterClient(_grpcChannel) as T;
        }

        public void Dispose()
        {
            _grpcChannel.ShutdownAsync();
            _grpcChannel.Dispose();
        }
    }
}
