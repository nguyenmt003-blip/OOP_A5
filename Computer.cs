/* 
Nguyễn Minh Tuấn
202419010 
*/
using System;
public class Computer : Device, INetworkable // INetworkable (máy tính luôn hỗ trợ mạng)
{
    public int RamGb { get; set; }
    public string ProcessorType { get; set; }
    public bool HasDedicatedGpu { get; set; }

    // Hiện thực INetworkable
    public string? IpAddress { get; private set; }
    public bool IsConnected => !string.IsNullOrEmpty(IpAddress);

    public Computer(string deviceId, string deviceName, int yearOfUsage, decimal purchasePrice, int ramGb, string processorType, bool hasDedicatedGpu, DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, deviceName, yearOfUsage, purchasePrice, status)
    {
        RamGb = ramGb;
        ProcessorType = processorType;
        HasDedicatedGpu = hasDedicatedGpu;
    }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            throw new ArgumentException("Địa chỉ IP không được rỗng.");
        if (IsConnected)
            throw new InvalidOperationException("Thiết bị đang kết nối mạng, không thể kết nối lại.");

        IpAddress = ipAddress;
    }

    public void Disconnect()
    {
        IpAddress = null; // Huỷ IP đang hoạt động sau khi ngắt kết nối
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal rate = 0.05m; // Mặc định 5%
        if (HasDedicatedGpu) rate += 0.02m;
        if (DateTime.Now.Year - YearOfUsage > 5) rate += 0.01m;

        return PurchasePrice * rate;
    }

    public override string ToString()
    {
        return base.ToString() + $" | RAM: {RamGb}GB, CPU: {ProcessorType}, GPU rời: {(HasDedicatedGpu ? "Có" : "Không")} | IP: {(IsConnected ? IpAddress : "Chưa kết nối")}";
    }
}