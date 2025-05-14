using System;

class ConversorTemperatura
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONVERSOR DE TEMPERATURA");
        Console.WriteLine("------------------------");
        
        bool continuar = true;
        
        while (continuar)
        {
            Console.WriteLine("\nEscolha a conversão desejada:");
            Console.WriteLine("1. Celsius para Fahrenheit");
            Console.WriteLine("2. Fahrenheit para Celsius");
            Console.WriteLine("3. Celsius para Kelvin");
            Console.WriteLine("4. Kelvin para Celsius");
            Console.WriteLine("5. Fahrenheit para Kelvin");
            Console.WriteLine("6. Kelvin para Fahrenheit");
            Console.WriteLine("0. Sair");
            
            Console.Write("\nOpção: ");
            int opcao;
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }
            
            if (opcao == 0)
            {
                continuar = false;
                continue;
            }
            
            if (opcao < 1 || opcao > 6)
            {
                Console.WriteLine("Opção inválida. Escolha entre 1 e 6 ou 0 para sair.");
                continue;
            }
            
            Console.Write("\nDigite a temperatura a ser convertida: ");
            double temperatura;
            
            if (!double.TryParse(Console.ReadLine(), out temperatura))
            {
                Console.WriteLine("Valor inválido. Digite um número.");
                continue;
            }
            
            double resultado = 0;
            string from = "", to = "";
            
            switch (opcao)
            {
                case 1: // Celsius para Fahrenheit
                    resultado = CelsiusParaFahrenheit(temperatura);
                    from = "Celsius";
                    to = "Fahrenheit";
                    break;
                case 2: // Fahrenheit para Celsius
                    resultado = FahrenheitParaCelsius(temperatura);
                    from = "Fahrenheit";
                    to = "Celsius";
                    break;
                case 3: // Celsius para Kelvin
                    resultado = CelsiusParaKelvin(temperatura);
                    from = "Celsius";
                    to = "Kelvin";
                    break;
                case 4: // Kelvin para Celsius
                    resultado = KelvinParaCelsius(temperatura);
                    from = "Kelvin";
                    to = "Celsius";
                    break;
                case 5: // Fahrenheit para Kelvin
                    resultado = FahrenheitParaKelvin(temperatura);
                    from = "Fahrenheit";
                    to = "Kelvin";
                    break;
                case 6: // Kelvin para Fahrenheit
                    resultado = KelvinParaFahrenheit(temperatura);
                    from = "Kelvin";
                    to = "Fahrenheit";
                    break;
            }
            
            Console.WriteLine("\n{0} graus {1} = {2:F2} graus {3}", temperatura, from, resultado, to);
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
    // Métodos de conversão
    static double CelsiusParaFahrenheit(double celsius)
    {
        return (celsius * 9/5) + 32;
    }
    
    static double FahrenheitParaCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5/9;
    }
    
    static double CelsiusParaKelvin(double celsius)
    {
        return celsius + 273.15;
    }
    
    static double KelvinParaCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }
    
    static double FahrenheitParaKelvin(double fahrenheit)
    {
        return CelsiusParaKelvin(FahrenheitParaCelsius(fahrenheit));
    }
    
    static double KelvinParaFahrenheit(double kelvin)
    {
        return CelsiusParaFahrenheit(KelvinParaCelsius(kelvin));
    }
}