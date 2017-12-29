using Calculator_CSharp.Models;
using System.Web.Mvc;

namespace Calculator_CSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Calculator calc)
        {
            return View(calc);
        }

        [HttpPost]
        public ActionResult Calculate(Calculator calc)
        {
            calc.Result = CalculateResult(calc);

            return RedirectToAction("Index", calc);
        }

        private decimal CalculateResult(Calculator calc)
        {
            var result =0m;

            switch (calc.Operator)
            {
                case "+":
                    result = calc.LeftOperand + calc.RightOperand;
                    break;
                case "-":
                    result = calc.LeftOperand - calc.RightOperand;
                    break;
                case "*":
                    result = calc.LeftOperand * calc.RightOperand;
                    break;
                case "/":
                    result = calc.LeftOperand / calc.RightOperand;
                    break;
            }
            return result;
        }
    }
}