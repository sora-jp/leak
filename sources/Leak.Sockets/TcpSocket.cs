﻿using System;
using System.Net;
using System.Threading.Tasks;

namespace Leak.Sockets
{
    public interface TcpSocket : IDisposable
    {
        void Bind();

        void Bind(int port);

        void Bind(IPAddress address);

        TcpSocketInfo Info();

        void Listen(int backlog);

        void Accept(TcpSocketAcceptCallback callback);

        Task<TcpSocketAccept> Accept();

        void Connect(IPEndPoint endpoint, TcpSocketConnectCallback callback);

        Task<TcpSocketConnect> Connect(IPEndPoint endpoint);

        void Disconnect(TcpSocketDisconnectCallback callback);

        Task<TcpSocketDisconnect> Disconnect();

        void Send(TcpSocketBuffer buffer, TcpSocketSendCallback callback);

        Task<TcpSocketSend> Send(TcpSocketBuffer buffer);

        void Receive(TcpSocketBuffer buffer, TcpSocketReceiveCallback callback);

        Task<TcpSocketReceive> Receive(TcpSocketBuffer buffer);
    }
}