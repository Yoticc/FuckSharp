using static FuckSharp;
DateTime startBF = DateTime.Now;
byte[] bytes = new SBF().Excute("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.", 5);
TimeSpan timeBF = TimeSpan.FromTicks(DateTime.Now.Ticks - startBF.Ticks);

DateTime startSC = DateTime.Now;
Console.Write("Hello World!");
TimeSpan timeSC = TimeSpan.FromTicks(DateTime.Now.Ticks - startSC.Ticks);

CC();
WL = $"bf: {timeBF.Ticks}\nst: {timeSC.Ticks}";