class FuncionesSwitch
{
    static Reglas reglas = new Reglas();

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("SISTEMA ACADEMICO");
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Listar Estudiantes");
            Console.WriteLine("3. Buscar estudiante");
            Console.WriteLine("4. Eliminar Estudiante");
            Console.WriteLine("5. Gestionar Materias");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione: ");
            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1:
                MenuRegistrarEstudiante();
                break;
                case 2:
                reglas.ListarEstudiantes();
                Pausa();
                break;
                case 3:
                MenuBuscarEstudiante();
                break;
                case 4:
                MenuEliminarEstudiante();
                break;
                case 5:
                MenuGestionMaterias();
                break;
            }
            
        } while (opcion != 6);
    }

    static void MenuRegistrarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("REGISTRAR ESTUDIANTE");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Direccion: ");
        string direccion = Console.ReadLine();
        Console.Write("Celular: ");
        string celular = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        reglas.AgregarEstudiante(nombre, apellido, direccion, celular, email);
        Pausa();
    }

    static void MenuBuscarEstudiante()
    {
        Console.WriteLine("BUSCAR ESTUDIANTE");
        Console.Write("Codigo: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            var estudiante = reglas.BuscarEstudiante(codigo);
            if (estudiante != null)
            {
                Console.WriteLine(estudiante.Codigo + " - " + estudiante.Nombre + " " + estudiante.Apellido + " - Email: " + estudiante.Email);
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
            }
            Pausa();
        }
    }

    static void MenuEliminarEstudiante()
    {
        Console.Write("Codigo a eliminar: ");
        if(int.TryParse(Console.ReadLine(), out int codigo))
        {
            if (sistema.EliminarEstudiante(codigo))
            {
                Console.WriteLine("Estudiante eliminado");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
            }
            Pausa();
        }
    }

    static void MenuGestionarMaterias()
    {
        Console.Write("Ingrese codigo del estudiante: ");
        if(!int.TryParse(Console.ReadLine(), out int codigo)) return;

        NodoEstudianre estudiante = reglas.BuscarEstudiante(codigo);
        if(estudiante == null)
        {
            Console.WriteLine("Estudiante no encontrado");
            Pausa();
            return;
        }
        int opcionMateria;
        do
        {
            Console.Clear();
            Console.WriteLine("Gestionar materias de: " + estudiante.Nombre + " " + estudiante.Apellido);
            Console.WriteLine("1. Agregar Materia");
            Console.WriteLine("2. Listar Materias y Notas");
            Console.WriteLine("3. Modificar nota");
            Console.WriteLine("4. Eliminar materia");
            Console.WriteLine("5. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out opcionMateria);

            switch (opcionMateria)
            {
                case 1:
                Console.Write("Materia: ");
                string nomMat = Console.ReadLine();
                Console.Write("Nota: ");
                double nt = double.Parse(Console.ReadLine());
                Console.WriteLine(SocketsHttpPlaintextStreamFilterContext.AgregarMateriaEstudiante(codigo, nomMat, nt));
                Pausa();
                break;
                case 2:
                ListarMaterias(estudiante);
                Pausa();
                break;
                case 3:
                Console.Write("Nombre materia: ");
                string nomMatEdit = Console.ReadLine();
                Console.Write("Nueva nota: ");
                double nuevaNota = double.Parse(Console.ReadLine());
                if(reglas.EditarNota(codigo, nomMatEdit, nuevaNota))
                {
                    Console.WriteLine("Nota actualizada");
                }
                else
                {
                    Console.WriteLine("Materia no encontrada");
                }
                Pausa();
                break;
                case 4:
                Console.Write("Nombre materia para borrar: ");
                string nomMatElim = Console.ReadLine();
                if(reglas.EliminarMateria(codigo, nomMatElim))
                {
                    Console.WriteLine("Materia eliminada");
                }
                else
                {
                    Console.WriteLine("Materia no encontrada");
                }
                Pausa();
                break;
            }
        }while (opcionMateria != 5);
    }

    static void ListarMaterias(NodoEstudiante estudiante)
    {
        NodoMateria temp = estudiante.CabezaMaterias;
        if (mTemp == null)
        {
            Console.WriteLine("No hay materias registradas para este estudiante");
            return;
        }
        while (temp != null)
        {
            Console.WriteLine(temp.Nombre + " - Nota: " + temp.Nota);
            temp = temp.Siguiente;
        }
    }

    static void Pausa()
    {
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
}

