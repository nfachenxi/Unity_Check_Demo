using System.Threading.Tasks;
using UnityEngine;

namespace Unity_Check_Demo
{
    public class NetworkManager : MonoBehaviour
    {
        public string serverUrl = "http://localhost:3000";

        void Start()
        {
            ConnectToServer();
        }

        public async void ConnectToServer()
        {
            await ConnectAsync();
        }

        // CA2007: Do not directly await a Task — consider ConfigureAwait
        private async Task ConnectAsync()
        {
            Debug.Log("Connecting to server: " + serverUrl);

            // Simulate async network connection
            await Task.Delay(2000);
        }
    }
}
