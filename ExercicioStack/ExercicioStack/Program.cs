// See https://aka.ms/new-console-template for more information
Console.WriteLine("## Exercicio Stack ##");

// Criando um objeto editor usando a instancia da classe EditorTexto
EditorTexto editor = new EditorTexto();

Console.WriteLine("\nDigitando ...\n");

editor.DigitarChar('s');
editor.DigitarChar('t');
editor.DigitarChar('a');
editor.DigitarChar('c');
editor.DigitarChar('q');


Console.WriteLine("\nFazendo o Undo...\n");
editor.Undo();

Console.WriteLine("\nArrumando a palavra stack\n");
editor.DigitarChar('k');

Console.ReadKey();

// Classe
public class EditorTexto
{
    // Criando uma coleção tipo Stack que recebe apenas char
    private Stack<char> undoStack = new Stack<char>(); 

    // variavel tipo string que se inicia vazia
    private string texto = "";

    // Metodos
    public void DigitarChar(char dado)
    {
        texto += dado; // recebe o dado do parametro e adiciona na variavel texto

        undoStack.Push(dado); // adiciona o dado do parametro a coleção undoStack

        Console.WriteLine($"Texto : " + texto); // imprimi na tela a variavel texto
    }

    public void Undo()
    {
        // se existir dado na coleção undoStack
        if(undoStack.Count > 0)
        {
            // Removendo o ultimo elemento da pilha e adicionando o dado na variavel ultimoChar
            char ultimoChar = undoStack.Pop();

            // reajustando a string texto retirando a ultimo caracter usando o metodo Substring
            texto = texto.Substring(0, texto.Length - 1);

            // Exibindo o resultado da alteração da string texto 
            Console.WriteLine($"Texto : {texto}");
        }
    }
}