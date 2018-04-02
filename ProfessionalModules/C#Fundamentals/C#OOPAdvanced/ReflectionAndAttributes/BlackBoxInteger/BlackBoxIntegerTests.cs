namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var input = "";
            var type = typeof(BlackBoxInteger);
            var blackboxObj = Activator.CreateInstance(type,true);
            var blackbox = (BlackBoxInteger)blackboxObj;

            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split('_');
                var operation = cmdArgs[0];
                var param = int.Parse(cmdArgs[1]);

                switch (operation)
                {
                    case "Add":
                        var addMethod = type.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        addMethod.Invoke(blackbox, new object[] { param });
                        break;

                    case "Subtract":
                        var subtractMethod = type.GetMethod("Subtract", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        subtractMethod.Invoke(blackbox, new object[] { param });
                        break;

                    case "Multiply":
                        var multyplyMethod = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        multyplyMethod.Invoke(blackbox, new object[] { param });
                        break;

                    case "Divide":
                        var divideMethod = type.GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        divideMethod.Invoke(blackbox, new object[] { param });
                        break;

                    case "LeftShift":
                        var leftShiftMethod = type.GetMethod("LeftShift", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        leftShiftMethod.Invoke(blackbox, new object[] { param });
                        break;

                    case "RightShift":
                        var righttShiftMethod = type.GetMethod("RightShift", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                        righttShiftMethod.Invoke(blackbox, new object[] { param });
                        break;

                    default:
                        break;
                }

                Console.WriteLine(type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public|BindingFlags.Static).GetValue(blackbox));
            }
        }
    }
}
