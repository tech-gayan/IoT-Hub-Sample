using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace IOT_Device_App
{
    public class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=Tiqri-IOT-Hub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=e+LNZHtCuSUgdsQ4Fq9mvvDq542dsK4SNzEo+mBAuoU=";

        private static async Task AddDeviceAsync()
        {
            string deviceId = "firstDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }

        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }
    }
}
