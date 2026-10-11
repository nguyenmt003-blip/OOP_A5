/* 
 Nguyễn Minh Tuấn
 202419010 
 */
using System;
public class NetworkPrinter : Printer, INetworkable
{
    public string? IpAddress { get; private set; }
    public bool IsConnected => !string.IsNullOrEmpty(IpAddress);

    public NetworkPrinter(string deviceId, string deviceName, int yearOfUsage, decimal purchasePrice,
                          PrinterTechnology tech, int printedPages, bool isColor, DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, deviceName, yearOfUsage, purchasePrice, tech, printedPages, isColor, status)
    {
    }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            throw new ArgumentException("Địa chỉ IP không được rỗng.");
        if (IsConnected)
            throw new InvalidOperationException("Máy in đang kết nối, không thể kết nối lại.");

        IpAddress = ipAddress;
    }

    public void Disconnect()
    {
        IpAddress = null;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Mạng: {(IsConnected ? IpAddress : "Chưa kết nối")}";
    }
}