class FuncionesSwitch
{
    static Reglas reglas = new Reglas();

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("SISTEMA ACADEMICO");
            Console.WriteLine("1. Agregar Estudiante\n2. Listar Estudiantes\n3. Agregar Materia\n4. Editar Nota\n5. Eliminar Estudiante\n0. Salir");
            Console.Write("Seleccione: ");
            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1:
                Console.Write("Nombre: "); string nombre = Console.ReadLine();
                Console.Write("Codigo: "); int codigo = int.Parse(Console.ReadLine());
                reglas.AgregarEstudiante(nombre, codigo);
                break;
                case 2:
                reglas.ListarEstudiantes();
                break;
                case 3:
                Console.Write("Codigo Estudiante: "); int codEst = int.Parse(Console.ReadLine());
                Console.Write("Nombre Materia: "); string nomMat = Console.ReadLine();
                Console.Write("Nota: "); double nota = double.Parse(Console.ReadLine());
                Console.WriteLine(reglas.AgregarMateriaEstudiante(codEst, nomMat, nota));
                break;
                case 4:
                Console.Write("Codigo Estudiante: "); codEst = int.Parse(Console.ReadLine());
                Console.Write("Nombre Materia: "); nomMat = Console.ReadLine();
                Console.Write("Nota: "); nota = double.Parse(Console.ReadLine());
                Console.WriteLine(reglas.EditarNota(codEst, nomMat, nota));
                break;
                case 5:
                Console.Write("Codigo Estudiante: "); codEst = int.Parse(Console.ReadLine());
                Console.WriteLine(reglas.EliminarEstudiante(codEst));
                break;
            }
            
        } while (opcion != 0);
    }
}
