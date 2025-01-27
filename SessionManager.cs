using System;

public class SessionManager
{
    private static SessionManager _instance;
    private User _currentUser;

    // Constructor privado para el patrón Singleton
    private SessionManager()
    {
        _currentUser = null;
    }

    // Propiedad para obtener la instancia única (Singleton)
    public static SessionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SessionManager();
            }
            return _instance;
        }
    }

    // Guardar información del usuario en la sesión
    public void SaveUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
        }
        _currentUser = user;
    }

    // Obtener información del usuario de la sesión
    public User GetUser()
    {
        if (_currentUser == null)
        {
            throw new InvalidOperationException("No hay un usuario en la sesión.");
        }
        return _currentUser;
    }

    // Eliminar la información del usuario de la sesión
    public void ClearSession()
    {
        _currentUser = null;
    }

    // Verificar si hay un usuario en la sesión
    public bool HasActiveUser => _currentUser != null;
}

// Clase de ejemplo para representar un usuario
public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Email: {Email}";
    }
}



class Program
{
    static void Main(string[] args)
    {
        var user = new User
        {
            Id = "123",
            Name = "Juan Pérez",
            Email = "juan.perez@example.com"
        };

        // Guardar el usuario en la sesión
        SessionManager.Instance.SaveUser(user);

        // Verificar si hay un usuario activo
        if (SessionManager.Instance.HasActiveUser)
        {
            // Obtener y mostrar información del usuario
            var currentUser = SessionManager.Instance.GetUser();
            Console.WriteLine("Usuario en la sesión:");
            Console.WriteLine(currentUser);
        }

        // Limpiar la sesión
        SessionManager.Instance.ClearSession();

        Console.WriteLine("Sesión eliminada.");
    }
}

