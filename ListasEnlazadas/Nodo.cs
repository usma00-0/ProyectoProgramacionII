using System.Reflection.Metadata.Ecma335;

namespace Listas;

public class Nodo<T>
{
    private T valor;

    private Nodo<T> siguiente;
    public Nodo(T valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }

    public T valor
    {
            get (return this.valor;)
            set (this.valor = value;)
    }

    public Nodo<T> siguiente
    {
            get (return this.siguiente;)
            set (this.siguiente = value;)
    }
}