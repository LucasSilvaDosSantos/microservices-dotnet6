using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            /*Using string for educational purposes*/

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)).ToString());

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok((ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber)).ToString());

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplacation/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplacation(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok((ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber)).ToString());

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok((ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)).ToString());

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                return Ok(((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / (decimal)2).ToString()) ;

            return BadRequest("Invalid Input");
        }

        [HttpGet("squareroot/{firstNumber}")]
        public IActionResult Squareroot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
                return Ok(Math.Sqrt((double)ConvertToDecimal(firstNumber)).ToString());

            return BadRequest("Invalid Input");
        }

        private static decimal ConvertToDecimal(string stringNumber)
        {
            if (decimal.TryParse(stringNumber, out var result))
                return result;
            return 0;
        }
            

        private static bool IsNumeric(string stringNumber)
            => double.TryParse(stringNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out _);
    }
}