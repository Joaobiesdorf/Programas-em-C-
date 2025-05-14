using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("🖩 Calculadora Simples em C#\n");

        while (true)
        {
            try
            {
                Console.WriteLine("Escolha uma operação:");
                Console.WriteLine("1 ➕ Soma");
                Console.WriteLine("2 ➖ Subtração");
                Console.WriteLine("3 ✖ Multiplicação");
                Console.WriteLine("4 ➗ Divisão");
                Console.WriteLine("0 ❌ Sair");

                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 0) break;

                Console.Write("Digite o primeiro número: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Digite o segundo número: ");
                double num2 = double.Parse(Console.ReadLine());

                double resultado = 0;
                string operacao = "";

                switch (opcao)
                {
                    case 1:
                        resultado = Calculator.Add(num1, num2);
                        operacao = "+";
                        break;
                    case 2:
                        resultado = Calculator.Subtract(num1, num2);
                        operacao = "-";
                        break;
                    case 3:
                        resultado = Calculator.Multiply(num1, num2);
                        operacao = "×";
                        break;
                    case 4:
                        resultado = Calculator.Divide(num1, num2);
                        operacao = "÷";
                        break;
                    default:
                        Console.WriteLine("Opção inválida!\n");
                        continue;
                }

                Console.WriteLine($"\n🔹 Resultado: {num1} {operacao} {num2} = {resultado}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida. Use apenas números!\n");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}\n");
            }
        }
    }
}