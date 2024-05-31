using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Caro
{
    public class SocketManager
    {
        Socket client;
        public bool IsConnected()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), Port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                client.Connect(ipep);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Socket Sever;
        public void createSever() 
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), Port);
            Sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Sever.Bind(ipep);
            Sever.Listen(10); //doi ket noi trong 10s 

            Thread appceptClient = new Thread(() =>
            {
                client = Sever.Accept();

            });

            appceptClient.IsBackground = true;
            appceptClient.Start();
            
        }


        public string IP = "127.0.0.1";
        public int Port = 9000;
        public bool isSever = true;

        public bool Send<T>(T data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        public T Receive<T>()
        {
            byte[] receiveData = new byte[1024];
            int receivedBytes = ReceiveData(client, receiveData);

            // Chỉ lấy phần dữ liệu thực nhận được (loại bỏ các byte thừa)
            byte[] actualData = new byte[receivedBytes];
            Array.Copy(receiveData, actualData, receivedBytes);

            return DeserializeData<T>(actualData);
        }

        private bool SendData(Socket target, byte[] data)
        {
            try
            {
                int sentBytes = target.Send(data);
                return sentBytes > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int ReceiveData(Socket target, byte[] data)
        {
            try
            {
                return target.Receive(data);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // Nén đối tượng thành mảng byte[]
        public byte[] SerializeData<T>(T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        // Giải nén mảng byte[] thành đối tượng
        public T DeserializeData<T>(byte[] byteArray)
        {
            string jsonString = Encoding.UTF8.GetString(byteArray);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    

    // Lấy ra IP V4 của card mạng đang dùng
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
