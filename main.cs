using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RemoteProcessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
			int y=3;
			Process process = new Process();
            process.StartInfo.FileName = @"Wmic.exe";
            process.StartInfo.Arguments = "process list brief /format:table";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
			process.WaitForExit();
			//
            if (process.ExitCode==0) 
			{
				  Console.WriteLine("Добро пожаловать в самодельный менеджер процессов ( Task Manager ) !");
			      Console.WriteLine("Чтобы  закрыть процесс из списка выше, выберите следующее:");
				  do {
				  Console.WriteLine( "1) - полное название процесса. Например - notepad.exe.");
				  Console.WriteLine( "2) - ID процесса. Например -   notepad.exe  - ProcessID 7892.");
				  Console.WriteLine( "3) - выход");
	     		  y = Convert.ToInt32(System.Console.ReadLine());
				  } while (y>3 || y<1);
				  if (y==1)
				  {
							Console.WriteLine( "Введите полное название процесса:");
							string str =Console.ReadLine();
			      			Process.Start( "wmic.exe","process  where \"Name=\'"+str+"\'\" call terminate");
							process.WaitForExit();
				  }
				  if (y==2)
				  {
							Console.WriteLine( "Введите ProcessID процесса (четвертая колонка):");
							string str =Console.ReadLine();
							Process.Start( "wmic.exe","process  where \"ProcessID=\'"+str+"\'\" call terminate");
							process.WaitForExit();
				  }
			} else Console.WriteLine( "Произошла ошибка в ходе выполнения внешнего процесса. Программа будет завершена.");
        
        
        
        }
    }
}