using Microsoft.AspNetCore.Mvc;
using System.IO.Ports;

namespace DrinksWebsite.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerService : ControllerBase, IDisposable
    {
        private static SerialPort _serialPort;

        static ControllerService()
        {
            try
            {
                _serialPort = new SerialPort("/dev/ttyACM0", 115200); // Adjust the port name and baud rate as needed
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to open serial port: {ex.Message}");
            }
        }

        [HttpPost("send")]
        public IActionResult SendCommand([FromBody] string command)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.WriteLine(command);
                    return Ok("Command sent");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to send command: {ex.Message}");
                }
            }
            return StatusCode(500, "Serial port is not open");
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
        }
    }
}