﻿

class LastArmyMain
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        Engine engine = new Engine(reader,writer);
        engine.Run();
    }
}
