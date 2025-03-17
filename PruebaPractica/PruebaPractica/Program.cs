
using System.Text;

string EsParOImpar(int n)
{
    string resultado = "";
    if(n % 2 == 0)
    {
        resultado = "Es par";
    } else
    {
        resultado = "Es impar";
    }
    return resultado;
}
List<int> lista = new List<int>();
lista.Add(3);
lista.Add(5);
lista.Add(2);
int SumarLista(List<int> lista)
{
    int suma = 0;
    foreach (int numeroLista in lista)
    { 
        suma += numeroLista;
    }
    return suma;
}
int numero = 3;
int Factorial(int num)
{
    int resultado = 0;

    if (num == 0) 
    {
        resultado = 1;
    }
    else
    {
        resultado = num * Factorial(num - 1);
    }

    return resultado;
}

string frase = "Esto es una frase de prueba";
char letra = 'e';
int ContarLetras(string frase, char letra)
{
    int numLetras = 0;
    string fraseFormateada = frase.ToLower();
    for (int i = 0; i < frase.Length; i++)
    {
        if (fraseFormateada[i].Equals(letra))
        {
            numLetras++;
        }
    }
    return numLetras;
}

string InvertirCadena(string str)
{
    StringBuilder sb = new StringBuilder();
    for (int i = str.Length - 1; i >=0 ; i--)
    { 
        sb.Append(str[i]);
    }
    return sb.ToString(); 

}

int ContarPalabras(string str)
{
    if (String.IsNullOrEmpty(str))
    {
        return 0;
    }

    int numPalabra = 0;
    bool enPalabra = false;
    //Esto es una frase de prueba
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == ' ')
        {
            enPalabra = false;
        }
        else
        {
            if (!enPalabra) // Si es falso entra, si no no
            {
                numPalabra++;
                enPalabra = true;
            }
        }
    }

    return numPalabra;
}


bool EsPrimo(int num)
{
    // Los numeros primos son aquellos que unicamente se pueden dividir entre el mismo y 1
    // El 0 y el 1 no son numeros primos

    if (num < 2) 
    {
        return false;
    }

    for (int i = 2; i < num; i++) 
    {
        if (num % i == 0) 
        {
            return false;
        }
    }

    return true; 
}

/*
 *******************************
 ***  PRUEBA DE LOS METODOS  ***
 *******************************
 */

//Console.WriteLine(EsParOImpar(3));
//Console.WriteLine("El resultado de la suma de todos los elementos de la lista es: " + SumarLista(lista));
//Console.WriteLine("El factorial de " + numero + " es " + Factorial(numero));
//Console.WriteLine("La frase " + frase + " tiene un total de " + ContarLetras(frase, letra) + " " + letra); 
//Console.WriteLine(InvertirCadena(frase));
//Console.WriteLine(ContarPalabras(frase));
//Console.WriteLine(EsPrimo(97));
Console.ReadKey();
