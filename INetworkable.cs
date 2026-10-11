/* 
Nguyễn Minh Tuấn
202419010 
*/
// Interface 
using System;
public interface INetworkable
{
    string? IpAddress { get; }
    bool IsConnected { get; }
    void Connect(string ipAddress);
    void Disconnect();
}